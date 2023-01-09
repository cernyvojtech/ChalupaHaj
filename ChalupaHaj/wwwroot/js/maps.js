//inicialization of map
function initMap() {

    //pointer on chalupa
    var chalupa = {
        lat: 50.254917,
        lng: 12.605003
    };

    //new map
    var map = new google.maps.Map(
        document.getElementById('map'), {
        zoom: 14,
        center: chalupa,
        mapTypeControl: true,
        mapTypeControlOptions: {
            style: google.maps.MapTypeControlStyle.HORIZONTAL_BAR,
            position: google.maps.ControlPosition.BOTTOM_CENTER,
        },
        zoomControl: true,
        zoomControlOptions: {
            position: google.maps.ControlPosition.LEFT_CENTER,
        },
        scaleControl: true,
        streetViewControl: true,
        streetViewControlOptions: {
            position: google.maps.ControlPosition.RIGHT_CENTER,
        },
        fullscreenControl: true,
        fullscreenControlOptions: {
            position: google.maps.ControlPosition.RIGHT_CENTER,
        },
    });

    //assign marker
    var marker = new google.maps.Marker({
        position: chalupa,
        map: map
    });
}