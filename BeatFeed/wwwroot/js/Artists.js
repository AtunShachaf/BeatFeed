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
function playVid(str) {
    $(".url_holder").attr("data-media", str);
    $(".popup").attr("style", "")
    $('.modal').modal({ show: true })
    $(".url_holder")[0].click();
}
function popUp() {
    $("[data-media]").on("click", function (e) {
        e.preventDefault();
        var $this = $(this);
        var videoUrl = $this.attr("data-media");
        var popup = $this.attr("href");
        var $popupIframe = $(popup).find("iframe");
        $popupIframe.attr("src", videoUrl);

        $this.closest(".test").addClass("show-popup");
    });

    $(".popup").on("click", function (e) {
        e.preventDefault();
        e.stopPropagation();

        $(".test").removeClass("show-popup");
    });

    $(".popup > iframe").on("click", function (e) {
        e.stopPropagation();
    });
}

function LoadConcerts(res) {

    if (res.errorCode) {
        content = '<h3>Upcoming concert</h3>';
    }

    else {
        content = '<a href="/Concerts/Show/' + $("#ArtistId").val() + '">' + '<h3>Upcoming concert</h3>' + '</a>';
        content += '<ul>'
        res.concerts.forEach(x => {
            content +=
                '<a href="/Concerts/Show/' + $("#ArtistId").val() + '"</a>' +
                '<li><strong>' + x.name + ', ' + x.country + ', ' + x.city + ', ' + x.address + '</strong>' +
                '<div class="clearfix"></div>';

            var date = new Date(x.date);

            content += '<span>' + date.getMonth() + '/' + date.getDay() + '/' + date.getFullYear() + '</span></li>';
        });
        content += '</ul>';
    }
    $('#concertDetails').html(content);
}


function fetchSongs() {
    artist_id = $("#ArtistId").val();
    $.ajax({
        type: 'GET',
        url: '/Songs/GetSongsOfArtistAjax?id=' + artist_id,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: fetchPlaylists
    });
}

function fetchPlaylists(songs) {
    $.ajax({
        type: 'GET',
        url: '/Playlists/List',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (res) {

            dropdown = '<div id="dropdowntoreplace" class="dropdown"><ul>';

            res.playlists.forEach(x => {
                dropdown += '<li>' +
                    '<a onclick="addSongToPlaylist(' + x.playlistId + ', song_id' +', dropdowntoreplace2' + ')">' + x.name + '</a>' +
                    '</li>';
            });

            dropdown += '</ul></div>';
            LoadSongs(songs, dropdown)
        }
    });

}
function LoadSongs(res, dropdown) {
    content = ''
   
    if (res.errorCode) {
        content = '<h3>No songs for this artist :/</h3>';
    }

    else {
        var count_from_zero = 0;
        var count_from_one = 1;
        res.songs.forEach(x => {
            content += '    <div class="container">' +
                '        <!-- song -->' +
                '        <div class="song-item small-bg">' +
                '            <div class="row">' +
                '                <div class="col-lg-4">' +
                '                    <div class="song-info-box">' +
                '                        <img src="' + x.imgLink + '" alt="">' +
                '                        <div class="song-info">' +
                '                            <h5>' + x.name + '</h5>' +
                '                            <p>' + x.album + '</p>' +
                '                        </div>' +
                '                    </div>' +
                '                </div>' +
                '                <div class="col-lg-6">' +
                '                    <div class="single_player_container">' +
                '                        <div class="single_player">' +
                '                            <div class="jp-jplayer jplayer" data-ancestor=".jp_container_' + count_from_one + '" data-url="' + x.songLink + '"></div>' +
                '                            <div class="jp-audio jp_container_' + count_from_one + '" role="application" aria-label="media player">' +
                '                                <div class="jp-gui jp-interface">' +

                '                                    <!-- Player Controls -->';
            if (x.clipURL != null) {
                var embed = x.clipURL.replace("watch?v=", "embed/");
                embed = embed.replace("https:", "");
                content += '                         <div class="player_controls_box">' +
                    '                                        <button onclick="playVid(\'' + embed + '\')" class="jp-clip player_button" tabindex="' + count_from_zero + '"></button>';
            }
            else
                content += '                              <div class="player_controls_box">';
            content +='                                        <button class="jp-prev player_button" tabindex="' + count_from_zero + '"></button>' +
                '                                        <button class="jp-play player_button" tabindex="' + count_from_zero + '"></button>' +
                '                                        <button class="jp-next player_button" tabindex="' + count_from_zero + '"></button>' +
                '                                        <button class="jp-stop player_button" tabindex="' + count_from_zero + '"></button>' +
                '                                        <button onclick="openDropDown(' + count_from_zero + ')" class="jp-add player_button" tabindex="' + count_from_zero + '">+</button>' + dropdown.replaceAll('dropdowntoreplace2', count_from_zero).replace('dropdowntoreplace', count_from_zero).replaceAll('song_id', x.songId) +
                '                                        </div>' +
                '                                    <!-- Progress Bar -->' +
                '                                    <div class="player_bars">' +
                '                                        <div class="jp-progress">' +
                '                                            <div class="jp-seek-bar">' +
                '                                                <div>' +
                '                                                    <div class="jp-play-bar"><div class="jp-current-time" role="timer" aria-label="time">0:00</div></div>' +
                '                                                </div>' +
                '                                            </div>' +
                '                                        </div>' +
                '                                        <div class="jp-duration ml-auto" role="timer" aria-label="duration">00:00</div>' +
                '                                    </div>' +
                '                                </div>' +
                '                            </div>' +
                '                        </div>' +
                '                    </div>' +
                '                </div>' +
                '            </div>' +
                '        </div>' +
                '    </div>';

            count_from_zero ++;
            count_from_one ++;
        });

        $('#LoadSongs').html(content);

        paint();
        initSinglePlayer();
    }

}

function addSongToPlaylist(playlist_id, song_id, dropdown_id) {
    $.ajax({
        type: 'GET',
        url: '/SongToPlaylists/AddSongToPlaylistAjax?playlistId=' + playlist_id + '&songId=' + song_id,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (res) {
            openDropDown(dropdown_id);

            if (res.success != true) {
                openDropDown(dropdown_id);
                alert('song already exists');
                
            }

        }
    });
}

function openDropDown(id_of_dropdown) {
    $('.dropdown').eq(id_of_dropdown).toggleClass('active');
}



$(document).ready(function () {
    fetchConcerts();
    fetchSongs();
    popUp();
})