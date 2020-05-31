import glob, os
import pandas as pd
from tqdm import tqdm
from pathlib import Path
import requests
import gdal



def build_queries(query_folder, base_url):
    ''' returns a dict mapping filename to a list of queries for the entries in that csv file
    '''
    print(f"Building queries from CSV files in {query_folder}, using base download url {base_url}")

    queries = {}
    for file in glob.glob(os.path.join(query_folder,"*.csv")):
        print(f"Generating queries for {file}")
        df = pd.read_csv(file)
        queries[os.path.basename(file)] = [base_url + s for s in df["fileUrls for custom selected"].tolist()]

    print(f"Finished building queries; {len(queries)} csv files and {sum(len(v) for v in queries.values())} files to download.")
    return queries


def process(queries, target_dir, api_key):
    ''' accepts a dict mapping filename to a list of download URLs and saves the downloaded file into the specified subfolder, then initiates a conversion to GeoTiff.
    '''
    # prepare header information to insert API access key (to satisfy NASA EarthData access controls - API key is hardcoded to the value assigned to 'nightmoves' key in... someone's... EarthData profile)
    # headers = {'Authorization': 'Bearer 4FCD2DE2-A2FD-11EA-8090-EA5D4723ACD5'}
    headers = {'Authorization': 'Bearer ' + api_key}
    
    # create the target download folder if it does not exist
    Path(target_dir).mkdir(parents=True, exist_ok=True)

    # iterate throught the files
    for collection in queries:
        # make a subfolder for this collection
        collection_target_dir = os.path.join(target_dir,collection)
        Path(collection_target_dir).mkdir(parents=True, exist_ok=True)

        # download each file into that subfolder
        for url in queries[collection]:
            hdf_filename = os.path.join(collection_target_dir,url.split('/')[-1])

            # don't download if the file already exists
            my_file = Path(hdf_filename)
            if my_file.is_file():
                print(f"Skipping download for {url} : {hdf_filename} already exists.")
            else:             
                print(f"Downloading file at {url} to {hdf_filename}")
                # urllib.request.urlretrieve(url,hdf_filename)
                with requests.get(url, headers=headers, stream=True) as r:
                    total_size = int(r.headers.get('content-length', 0))
                    block_size = 8192
                    t=tqdm(total=total_size, unit='iB', unit_scale=True)
                    r.raise_for_status()
                    with open(hdf_filename, 'wb') as f:
                        for chunk in r.iter_content(chunk_size=block_size): 
                            t.update(len(chunk))
                            f.write(chunk)
                t.close()

            # attempt to convert to geotiff, whether skipped or downloaded
            convert_to_geotiff(hdf_filename, collection_target_dir)


def convert_to_geotiff(input_filename, output_dir):
    print(f"Beginning conversion of {input_filename} to geotiff")

    #Get File Name Prefix
    rasterFilePre = os.path.splitext(input_filename)[0]
    # print(rasterFilePre)

    fileExtension = "_BBOX.tif"

    ## Open HDF file
    hdflayer = gdal.Open(input_filename, gdal.GA_ReadOnly)

    #print (hdflayer.GetSubDatasets())

    # Open raster layer
    #hdflayer.GetSubDatasets()[0][0] - for first layer
    #hdflayer.GetSubDatasets()[1][0] - for second layer ...etc
    subhdflayer = hdflayer.GetSubDatasets()[0][0]
    rlayer = gdal.Open(subhdflayer, gdal.GA_ReadOnly)
    #outputName = rlayer.GetMetadata_Dict()['long_name']

    #Subset the Long Name
    outputName = subhdflayer[92:]

    outputNameNoSpace = outputName.strip().replace(" ","_").replace("/","_")
    outputNameFinal = outputNameNoSpace + os.path.basename(rasterFilePre) + fileExtension
    # print(outputNameFinal)

   # skip if the geotiff file already exists
    geotiff_file = Path(os.path.join(output_dir, outputNameFinal))
    if geotiff_file.is_file():
        print(f"Skipping conversion for {input_filename}; GeoTiff already exists as {outputNameFinal}")
        return


    outputRaster = os.path.join(output_dir, outputNameFinal)

    #collect bounding box coordinates
    #-a_ullr <ulx> <uly> <lrx> <lry>
    WestBoundCoord = rlayer.GetMetadata_Dict()["HDFEOS_GRIDS_VNP_Grid_DNB_WestBoundingCoord"]
    EastBoundCoord = rlayer.GetMetadata_Dict()["HDFEOS_GRIDS_VNP_Grid_DNB_EastBoundingCoord"]
    NorthBoundCoord = rlayer.GetMetadata_Dict()["HDFEOS_GRIDS_VNP_Grid_DNB_NorthBoundingCoord"]
    SouthBoundCoord = rlayer.GetMetadata_Dict()["HDFEOS_GRIDS_VNP_Grid_DNB_SouthBoundingCoord"]


    EPSG = "-a_srs EPSG:4326" #WGS84

    translateOptionText = EPSG+" -a_ullr " + WestBoundCoord + " " + NorthBoundCoord + " " + EastBoundCoord + " " + SouthBoundCoord

    translateoptions = gdal.TranslateOptions(gdal.ParseCommandLine(translateOptionText))
    gdal.Translate(outputRaster,rlayer, options=translateoptions)
    #gdal.Warp(outputRaster,rlayer)

    #Display image in QGIS (run it within QGIS python Console) - remove comment to display
    #iface.addRasterLayer(outputRaster, outputNameFinal)



# ----------------------------------------------------------------------------------------------

print("Downloading from LAADS")

# read environment values for configuration
queries_folder = os.environ.get('LAADS_CSV_FOLDER')
url = os.environ.get('LAADS_BASE_DOWNLOAD_URL')
target_dir = os.environ.get('TARGET_DIRECTORY')
api_key = os.environ.get('API_KEY')


queries = build_queries(queries_folder, url)

process(queries, target_dir, api_key)


print("Finished!")


