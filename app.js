const express = require('express')
const app = express()
const port = 3000
const fs = require('fs');
const path = require('path');
// const mapbox = require('mapbox-gl');


// mapboxgl.accessToken = mapbox_token;
// const map = new mapboxgl.Map({
// container: 'mapbox-container',
// style: 'mapbox://styles/mapbox/streets-v9'
// });
    // let mapbox_token = process.env.MAPBOX_TOKEN;

app.use(express.static("public"));
app.get('/', (req, res) => {
    res.sendFile(path.join(__dirname, "public", "index.html"));
});

app.listen(port, () => console.log(`Example app listening at http://localhost:${port}`))

// mapbox docs: https://docs.mapbox.com/