function playVid(str) {
    $(".url_holder").attr("data-media", str);
    $(".popup").attr("style", "")
    $('.modal').modal({show:true})
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
function fetchSongs() {
    $.ajax({
        type: 'GET',
        url: '/Playlists/GetPlaylistSongsAjax?playlistId=' + $("#playlist_id").val(),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: LoadSongs
    });
}
function LoadSongs(res) {
    content = ''
    playlistId = $("#playlist_id").val();

    console.log(res.songs.length);

    if (res.errorCode) {
        content = '<h3>Error Occur.</h3>';
    }
    else if (res.songs.length == 0) {
        content = '<h3>There are no songs in this playlist :/</h3><strong style="position:relative;left:9px;font-size:17px;">Please use the search bar and add some songs to the list.</strong>';
        $('#LoadSongs').html(content);
        return;
    }

    else {
        var count_from_zero = 0;
        var count_from_one = 1;
        res.songs.forEach(x => {

            content += '    <div class="container ">' +
                '        <!-- song -->' +
                '        <div class="song-item">' +
                '            <div class="row justify-content-center">' +
                '                <div class="col-lg-4">' +
                '                    <div class="song-info-box">' +
                '                       <a href="/Artists/Artist/' + x.artistId + '">' +
                '                        <img src="' + x.imgLink + '" alt="">' +
                '                        <div class="song-info">' +
                '                            <a href="/Artists/Artist/' + x.artistId + '">' +
                '                            <h4>' + x.name + '</h4>' +
                '                            <p>' + x.album + '</p>' +
                '                            </a>' +
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
                content += '                         <div class="player_controls_box" style="width:218px;position:relative;right:5px">' +
                    '                                        <button onclick="playVid(\'' + embed + '\')" class="jp-clip player_button" tabindex="' + count_from_zero + '"></button>';
            }
            else
                content += '                         <div class="player_controls_box">';
            content += '                                  <button class="jp-prev player_button" tabindex="' + count_from_zero + ' onClick="RewindTrack()"></button>' +
                '                                        <button class="jp-play player_button" tabindex="' + count_from_zero + '"></button>' +
                '                                        <button class="jp-next player_button" tabindex="' + count_from_zero + '"></button>' +
                '                                        <button class="jp-stop player_button" tabindex="' + count_from_zero + '"></button>' +
                '                                        <button onclick="deleteSong(' + playlistId + ',' + x.songId + ')" class="jp-remove player_button" tabindex="' + count_from_zero + '"></button>' +
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

            count_from_zero++;
            count_from_one++;

        });

        $('#LoadSongs').html(content);

        initSinglePlayer();
    }

}


function deleteSong(playlist_id, song_id) {
    $.ajax({
        type: 'GET',
        url: '/SongToPlaylists/DeleteSongFromPlaylistAjax?playlistId=' + playlist_id + '&songId=' + song_id,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (res) {
            fetchSongs();

            if (res.success != true) {
                alert('Cannot delete the song')
            }

        }
    });
}

$(document).ready(function () {
    fetchSongs();
    popUp();
})