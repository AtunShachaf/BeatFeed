function fetchConcerts() {
    artist_id = $("#ArtistId").val();
    $.ajax({
    type: 'GET',
        url: '/Concerts/GetConcerts?id=' + artist_id,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: LoadConcerts
    });
}

function LoadConcerts(res) {
    if (res.errorCode) {
        const uluru = { lat: 40.70027290768944, lng: -74.0442543305885 };

        // The map, centered at Uluru
        const map = new google.maps.Map(document.getElementById("MapDiv"), {
            zoom: 4,
            center: uluru,
        });

        // The marker, positioned at Uluru
        const marker = new google.maps.Marker({
            position: uluru,
            map: map,
        });
    }
    else {
        const uluru = { lat: 40.70027290768944, lng: -74.0442543305885 };
        const pMarker = '/img/done.png';
        const uMarker = '/img/marker.png';
        // The map, centered at Uluru
        const map = new google.maps.Map(document.getElementById("MapDiv"), {
            zoom: 2.5,
            center: uluru
        });

        var content = '';
        var prevContent = '';

        res.concerts.forEach(x => {
            var coords = { lat: x.lat, lng: x.lng };
            var date = new Date(x.date);
            if (checkDate(date)) { // Upcoming Concerts
                var test = new google.maps.LatLng(x.lat, x.lng);
                map.panTo(test);
                new google.maps.Marker({
                    position: coords,
                    map: map,
                    icon: uMarker
                });
                content +=
                    '<li><strong>Concert Title : </strong>' + x.name + '</br>' +
                    '<strong>Address : </strong>' + x.address + ', ' + x.city + ', ' + x.country + '</br>' +
                    '<strong>Date : </strong>' + date.getDate() + '/' + (date.getMonth()+1) + '/' + date.getFullYear() + '</li>' + '</br>' +
                    '<div class="clearfix"></div>';
            }
            else { // Previous Concerts
                var test = new google.maps.LatLng(x.lat, x.lng);
                map.panTo(test);
                new google.maps.Marker({
                    position: coords,
                    map: map,
                    icon: pMarker
                });
                prevContent +=
                    '<li><strong>Concert Title : </strong>' + x.name + '</br>' +
                    '<strong>Address : </strong>' + x.address + ', ' + x.city + ', ' + x.country + '</br>' +
                    '<strong>Date : </strong>' + date.getDate() + '/' + (date.getMonth()+1) + '/' + date.getFullYear() + '</li>' + '</br>' +
                    '<div class="clearfix"></div>';
            }
        });

        if (content != '')
        $('#concertDetails').html(content);
        else {
            $('#concertDetails').parent().css("text-align", "center");
            $('#concertDetails').html('<strong>There are no upcoming concerts. :(</strong>')
        }

        if (prevContent != '')
        $('#concert-prev').html(prevContent);
        else {
            $('#concert-prev').parent().css("text-align", "center");
            $('#concert-prev').html('<strong>There were no upcoming concerts. :(</strong>');
        }

    }

}

function initMap() {
    fetchConcerts();
}

//returns false if date already occured
function checkDate(date) {
    var curDate = new Date();
    var curYear = curDate.getFullYear();
    var curMonth = curDate.getMonth()+1;
    //var curDay = curDate.getDay();
    var curDay = curDate.getDate();
    var tYear = date.getFullYear();
    var tMonth = date.getMonth()+1;
    var tDay = date.getDate();
    //alert('date = ' + date + '\ncurDate = ' + curDate + '\nCurYear = ' + curYear + '\nCurMonth = ' + curMonth + '\nCurDay = ' + curDay + '\n\ntYear = ' + tYear + '\ntMonth = ' + tMonth + '\n tDay = ' + tDay);
    if (curYear < tYear || (curYear == tYear && curMonth < tMonth) || (curYear == tYear && curMonth == tMonth && curDay < tDay))
        return true
    return false
}


// Initialize and add the map
function initMapBackup() {
    // The location of Uluru

    const uluru = { lat: 51.502201219453774, lng: -0.14011938911621313};
    //const uluru = { lat: -25.344, lng: 131.036 };
    // The map, centered at Uluru
    const map = new google.maps.Map(document.getElementById("MapDiv"), {
        zoom: 4,
        center: uluru,
    });
    // The marker, positioned at Uluru
    const marker = new google.maps.Marker({
        position: uluru,
        map: map,
    });
}