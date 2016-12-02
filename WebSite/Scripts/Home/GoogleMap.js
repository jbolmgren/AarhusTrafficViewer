function initMap() {
    var map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 56.15653, lng: 10.20747 },
        zoom: 15
    });

    var pos = map.getCenter();

    updateMapCenter(map, pos);

    // Try HTML5 geolocation.
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };

        }, function () {
            handleLocationError(true, map, pos);
        });
    } else {
        // Browser doesn't support Geolocation
        handleLocationError(false, map, pos);
    }
}

function updateMapCenter(map, pos) {
    map.setCenter(pos);

    var marker = new google.maps.Marker({
        map: map,
        draggable: true,
        animation: google.maps.Animation.DROP,
        position: pos
    });

    var circle = new google.maps.Circle({
        strokeColor: '#FF0000',
        strokeOpacity: 0.6,
        strokeWeight: 1,
        fillColor: '#FF0000',
        fillOpacity: 0.2,
        map: map,
        center: pos,
        radius: 400
    });

    marker.addListener('drag', function () { circle.setCenter(marker.position); });
    marker.addListener('mouseup', function() { updatePosition(map, marker.position); });
}


function updatePosition(map, pos) {
    var data = { Lat: pos.lat(), Lng: pos.lng(), Radius: 400 };
    var apiurl = 'api/trafic/?' + $.param(data);
    $.ajax({
        url:apiurl,
        type:"GET",
        contentType:"application/json; charset=utf-8",
        dataType:"json",
        success: function(data){
            alert(data);
        }
    })
}

function handleLocationError(browserHasGeolocation, map, pos) {
    var infoWindow = new google.maps.InfoWindow({ map: map });
    infoWindow.setPosition(pos);
    infoWindow.setContent(browserHasGeolocation ?
                          'Error: The Geolocation service failed.' :
                          'Error: Your browser doesn\'t support geolocation.');
}