const express = require('express')
const app = express()
const port = 3000
const fs = require('fs');
const path = require('path');
const got = require("got");

const getCovidCases = async (req, res) => {
    try {
        console.log('getCovidCases');
        const result = await got.get("https://covid19-admin.deploy.solutions/api/services/app/covidcase/getall", {
            responseType: 'json',
        });
        const body = result.body;
        res.json(body);
    } catch (error) {
        console.log(error);
        res.send(error);
    }
}

const getEnvironmentalFactors = async (req, res) => {
    try {
        console.log('getCovidCases');
        const result = await got.get("https://covid19-admin.deploy.solutions/api/services/app/environmentfactor/GetAll", {
            responseType: 'json',
        });
        const body = result.body;
        res.json(body);
    } catch (error) {
        console.log(error);
        res.send(error);
    }
}

app.use(express.static("public"));
app.get('/', (req, res) => {
    res.sendFile(path.join(__dirname, "public", "index.html"));
});
app.get('/cases', getCovidCases);
app.get('/env', getEnvironmentalFactors);



app.listen(port, () => console.log(`Example app listening at http://localhost:${port}`))

// mapbox docs: https://docs.mapbox.com/