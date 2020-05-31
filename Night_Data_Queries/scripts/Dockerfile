FROM osgeo/gdal

RUN apt-get update -y \
    && apt-get install -y \
    python3-pip

COPY requirements.txt /
RUN pip3 install -r requirements.txt


