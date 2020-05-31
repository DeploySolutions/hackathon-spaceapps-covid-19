import mapbox from '/mapbox-gl';

mapboxgl.accessToken = 'pk.eyJ1IjoiYWRhbWpzaW0iLCJhIjoiY2thdmF0Ym9kMGNhbTJ6a3l5dzl3ZmdrcCJ9.YcSMrFRPTc7hCZgYkJeoSQ';
const map = new mapboxgl.Map({
container: 'mapbox-container',
style: 'mapbox://styles/mapbox/streets-v9'
});