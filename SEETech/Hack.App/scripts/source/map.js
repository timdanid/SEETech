var _map;
var _geolocation;
var _mapoptions;
var _collection = [];


function geolocationEnabled(position)
{
    _geolocation = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
    setMapOptions(_geolocation,15);
    _map = new google.maps.Map(document.getElementById('map-canvas'), _mapoptions);
    createMarker(position.coords.latitude, position.coords.longitude,"yayya", "<p style=\"width: 50px; height:50px;\">gospodo ođe ste</p>");
    
}
function geolocationDisabled()
{
    _geolocation = new google.maps.LatLng(45.466980, 16.162551);
    setMapOptions(_geolocation, 8);
    _map = new google.maps.Map(document.getElementById('map-canvas'), _mapoptions);
}

function setDefaultOptions()
{
    _mapoptions = {
        center: _geolocation,
        streetViewControl: false
    };
}
function setMapOptions(geolocation,zoom)
{
    _mapoptions = {
        zoom: zoom,
        center: geolocation,
        streetViewControl: false
    }
}

function createMarker(_lat, _lng)
{
    var _mPosition = new google.maps.LatLng(_lat,_lng);
    var _marker = new google.maps.Marker({
        position: _mPosition
    });
    _marker.setMap(_map);
}
function createMarker(_lat, _lng, _title)
{
    var _mPosition = new google.maps.LatLng(_lat, _lng);
    var _marker = new google.maps.Marker({
        position: _mPosition,
        title: _title
    });
    _marker.setMap(_map);
}
function createMarker(_lat, _lng, _title, _infoText)
{
    var _infoWindow = new google.maps.InfoWindow({
        content: _infoText
    });
    var _mPosition = new google.maps.LatLng(_lat, _lng);
    var _marker = new google.maps.Marker({
        position: _mPosition,
        title: _title
    });
   
    google.maps.event.addListener(_marker, 'click', function () {
        _infoWindow.open(_map, _marker);
    });
}
function createMarker(_lat, _lng, _title, _infoText,_icon) {
    var _infoWindow = new google.maps.InfoWindow({
        content: "<a src=\"/#/details/" + _title + "\"style=\"width: auto; height:uto;\" >" +_infoText + "</a>"
    });
    
    var _mPosition = new google.maps.LatLng(_lat, _lng);
    var _marker = new google.maps.Marker({
        position: _mPosition,
        title: _title,
        icon: _icon,
        animation: google.maps.Animation.DROP,
        map: _map
        
    });
    
    google.maps.event.addListener(_marker, 'click', function () {
        _infoWindow.open(_map, _marker);
        if (_marker.getAnimation() != null) {
            _marker.setAnimation(null);
        } else {
            _marker.setAnimation(google.maps.Animation.BOUNCE);
        }
    });
    
    _collection.push(_marker);
}

function createMarker(_lat, _lng, _title, _infoText, _icon, _id,_patientCount) {
    var _infoWindow = new google.maps.InfoWindow({
        content: "<a src=\"/#/details/" + _title + "\"style=\"width: auto; height:uto;\" >" + _infoText + "</a>"
    });

    var _mPosition = new google.maps.LatLng(_lat, _lng);
    var _marker = new google.maps.Marker({
        position: _mPosition,
        title: _id,
        icon: _icon,
        animation: google.maps.Animation.DROP,
        map: _map,
        patientCount: _patientCount

    });

    google.maps.event.addListener(_marker, 'click', function () {
        _infoWindow.open(_map, _marker);
        if (_marker.getAnimation() != null) {
            _marker.setAnimation(null);
        } else {
            _marker.setAnimation(google.maps.Animation.BOUNCE);
        }
    });

    _collection.push(_marker);
}

function addToCollection(_mcollection)
{
    createMarker(_lat, _lng, _title, _infoText, _icon);
}
function createMarketCluster(_collection)
{
    var clusterStyles = [
      {
          textColor: 'white',
          url: '/images/market-icons/base2-rec.png',
          height: 30,
          width: 30
      },
     {
         textColor: 'white',
         url: '/images/market-icons/base1-rec.png',
         height: 30,
         width: 30
     },
     {
         textColor: 'white',
         url: '/images/market-icons/base3-rec.png',
         height: 30,
         width: 30
     }
        ];
        var mcOptions = {
            gridSize: 30,
            maxZoom: 15,
            styles: clusterStyles
        };
    var cluster = new MarkerClusterer(_map, _collection,mcOptions);
}
function getData()
{
    router.getMarkers(function (data) {
        data.forEach(function (t)
        { //_lat, _lng, _title, _infoText, _icon, _id , _patientCount
            createMarker(t.x_coordinate, t.y_coordinate, t.title, t.location, t.icon, t.id, t.patientCount)
        });
    });
}
function markerCollectionTest()
{
    createMarker(45, 15.454, "title", "neki infač", '/images/market-icons/marker-64-base1.png');
    createMarker(45.4747, 15.454, "title", "neki info", '/images/market-icons/marker-64-base2.png');
    createMarker(45.4747, 15, "title", "neki info", '/images/market-icons/marker-64-base1.png');
    createMarker(43.47, 15, "title", "neki info", '/images/market-icons/marker-64-base2.png');

}
function markerClusterTest()
{
    createMarketCluster(_collection);
}

function initialize()
{
    navigator.geolocation.getCurrentPosition(geolocationEnabled, geolocationDisabled);
    getData();
}

