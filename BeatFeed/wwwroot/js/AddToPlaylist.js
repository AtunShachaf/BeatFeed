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

function fetchPlaylists2() {
    $.ajax({
        type: 'GET',
        url: '/Playlists/List',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (res) {

            dropdown = '<div id="dropdowntoreplace" class="dropdown"><ul>';

            res.playlists.forEach(x => {
                dropdown += '<li>' +
                    '<a onclick="addSongToPlaylist(' + x.playlistId + ', song_id' + ', dropdowntoreplace2' + ')">' + x.name + '</a>' +
                    '</li>';
            });

            dropdown += '</ul></div>';
            LoadSongs(dropdown)
        }
    });

}

function openDropDown(id_of_dropdown) {
    $('.dropdown').eq(id_of_dropdown).toggleClass('active');
}

$(document).ready(function () {
    fetchPlaylists2();
})