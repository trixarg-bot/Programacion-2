let map;
let markers = [];

window.initializeDetentionMap = function (element, detentions) {
    // Centrar el mapa en República Dominicana
    map = L.map(element).setView([18.7357, -70.1627], 8);

    // Agregar el mapa base
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '© OpenStreetMap contributors'
    }).addTo(map);

    // Agregar marcadores para cada detención
    detentions.forEach(detention => {
        const marker = L.marker([detention.latitud, detention.longitud])
            .bindPopup(`
                <strong>${detention.nombreCompleto}</strong><br>
                Fecha: ${new Date(detention.fechaDetencion).toLocaleDateString()}<br>
                Pasaporte: ${detention.numeroPasaporte}
            `)
            .addTo(map);

        marker.on('click', () => {
            DotNet.invokeMethodAsync('APPMigracion', 'OnMarkerClick', detention.id);
        });

        markers.push(marker);
    });

    // Ajustar la vista para mostrar todos los marcadores
    if (markers.length > 0) {
        const group = new L.featureGroup(markers);
        map.fitBounds(group.getBounds().pad(0.1));
    }
};
