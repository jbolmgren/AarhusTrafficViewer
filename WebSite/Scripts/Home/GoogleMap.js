function initMap() {
    var center = { lat: 56.15653, lng: 10.20747 };
    var mapComponentFactory = new GoogleMapComponentFactory(document.getElementById('map'), center);
    var serviceCaller = new ServiceCaller();
    new TraficInfoMapRenderer(mapComponentFactory, serviceCaller).renderMap(center);
}


var MapState = function () {
    this.removeHandles = [];

    this.addRemoveHandle = function(handle) {
        this.removeHandles.push(handle);
    }

    this.runRemoveHandles = function () {
        for (var index in this.removeHandles) {
            this.removeHandles[index].remove();
        }
        this.clear();
    };

    this.clear = function() {
        this.removeHandles = [];
    };
};

var TraficInfoMapRenderer = function (mapComponentFactory, serviceCaller) {
    this.state = new MapState();
    this.defaultSearchRadius = 800;
    this.mapComponentFactory = mapComponentFactory;
    this.serviceCaller = serviceCaller;

    this.renderMap = function (pos) {
        this.state.clear();
        
        var marker = mapComponentFactory.createMarker(pos, this.defaultSearchRadius);
        var instance = this;
        marker.addPositionListener(function (position) { instance.updatePosition(position); });
    };

    this.updatePosition = function (pos) {
        var query = { Lat: pos.lat(), Lng: pos.lng(), RadiusInMeters: this.defaultSearchRadius };
        var instance = this;
        this.serviceCaller.callTraficInfoService(query, function (traficData) { instance.updateMapWithTraficInfo(traficData); });
    };

    this.updateMapWithTraficInfo = function(traficInfo) {
        this.state.runRemoveHandles();

        var instance = this;

        for (var index in traficInfo) {
            var info = traficInfo[index];
            var startPos = {
                lat: info.StartPosition.Latitude,
                lng: info.StartPosition.Longitude
            };
            var endPos = {
                lat: info.EndPosition.Latitude,
                lng: info.EndPosition.Longitude
            };
            this.serviceCaller.callRouteService(startPos, endPos, function(response) { instance.createRouteOnMap(startPos, info, response); });
        }
    };

    this.createRouteOnMap = function(infoWindowPos, info, response) {
        var name = "";
        if (response.routes && response.routes.length > 0)
            name = "<b>" + response.routes[0].summary + "</b>";

        var infoText = name + "<br />";
        infoText += "Car count:" + info.CarCount + ", ";
        infoText += "Average Speed: " + info.AverageSpeed + "<br />";
        infoText += "Last updated: " + info.RecordTime;

        var windowRemoveHandle = this.mapComponentFactory.createInfoWindow(infoText, infoWindowPos);
        this.state.addRemoveHandle(windowRemoveHandle);

        var displayRemoveHandle = this.mapComponentFactory.createDirectionMarking(response);
        this.state.addRemoveHandle(displayRemoveHandle);
    }

}

var ServiceCaller = function () {

    this.callTraficInfoService = function(query, callback) {
        var apiurl = 'api/trafic/?' + $.param(query);
        $.ajax({
            url: apiurl,
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(data) {
                if (data.TraficPositions)
                    callback(data.TraficPositions);
            }
        });
    };

    this.callRouteService = function (startPos, endPos, callback) {
        var directionsService = new google.maps.DirectionsService();
        directionsService.route({
            origin: startPos,
            destination: endPos,
            travelMode: 'DRIVING'
        }, function (response, status) {
            if (status === 'OK') {
                callback(response);
            } else {
                window.alert('Directions request failed due to ' + status);
            }
        });
    };
}

var GoogleMapComponentFactory = function(elm, position) {
    this.map = new google.maps.Map(elm, {
        center: position,
        zoom: 15
    });

    this.getMap = function() {
        return this.map;
    };

    this.createMarker = function (pos, radiusInMeters) {
        var marker = new google.maps.Marker({
            map: this.getMap(),
            draggable: true,
            animation: google.maps.Animation.DROP,
            position: pos
        });
        
        var circle = this.createCircle(pos, radiusInMeters);
        marker.addListener('drag', function () { circle.setCenter(marker.position); });

        return {
            addPositionListener : function(callback) {
                marker.addListener('mouseup', function () { callback(marker.position); });
            }
        };
    };

    this.createCircle = function(pos, radius) {
        return new google.maps.Circle({
            strokeColor: '#FF0000',
            strokeOpacity: 0.6,
            strokeWeight: 1,
            fillColor: '#FF0000',
            fillOpacity: 0.2,
            map: this.getMap(),
            center: pos,
            radius: radius
        });
    };

    this.createInfoWindow = function(infoText, infoWindowPos) {
        var win = new google.maps.InfoWindow({
            map: this.getMap(),
            content: infoText,
            position: infoWindowPos
        });
        return {
            remove : function() {
                win.close();
            }
        };
    };

    this.createDirectionMarking = function(response) {
        var directionsDisplay = new google.maps.DirectionsRenderer({
            draggable: false,
            map: this.getMap(),
            suppressMarkers: true,
            preserveViewport: true
        });
        directionsDisplay.setDirections(response);
        return {
            remove : function() {
                directionsDisplay.setMap(null);
            }
        };
    }
};
