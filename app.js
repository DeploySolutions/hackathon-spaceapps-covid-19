const express = require('express')
const app = express()
const port = 3000
const fs = require('fs');
const path = require('path');

app.use(express.static("public"));
app.get('/', (req, res) => {
    res.sendFile(path.join(__dirname, "public", "index.html"));
});

app.listen(port, () => console.log(`Example app listening at http://localhost:${port}`))

// mapbox docs: https://docs.mapbox.com/