// wwwroot/js/map.js
let map;
let markers = [];

window.initializeMap = function (element, locations) {
    // Centrar el mapa en República Dominicana
    map = L.map(element).setView([18.7357, -70.1627], 8);

    // Agregar el mapa base de OpenStreetMap
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '© OpenStreetMap contributors'
    }).addTo(map);

    // Agregar marcadores para cada ubicación
    locations.forEach(location => {
        const marker = L.marker([location.lat, location.lng])
            .bindPopup(`
                <strong>${location.name}</strong><br>
                ${location.description}
            `)
            .addTo(map);
        
        markers.push(marker);
    });

    // Agregar los límites de República Dominicana (simplificado)
    const dominicanBounds = [
        [[19.9320, -71.9451],
         [19.8800, -70.6299],
         [19.6500, -69.9289],
         [19.2273, -69.5893],
         [18.6150, -68.3428],
         [18.2050, -68.6168],
         [18.0109, -71.7833],
         [19.9320, -71.9451]]
    ];

    L.polygon(dominicanBounds, {
        color: '#2b5797',
        weight: 2,
        fillColor: '#88c9f9',
        fillOpacity: 0.2
    }).addTo(map);
};

// Función para cambiar el tipo de mapa
window.changeMapLayer = function (layerType) {
    if (map) {
        map.eachLayer((layer) => {
            if (layer instanceof L.TileLayer) {
                map.removeLayer(layer);
            }
        });

        let tileLayer;
        switch (layerType) {
            case 'satellite':
                tileLayer = L.tileLayer('https://server.arcgisonline.com/ArcGIS/rest/services/World_Imagery/MapServer/tile/{z}/{y}/{x}');
                break;
            case 'terrain':
                tileLayer = L.tileLayer('https://{s}.tile.opentopomap.org/{z}/{x}/{y}.png');
                break;
            default:
                tileLayer = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png');
        }
        tileLayer.addTo(map);
    }
};