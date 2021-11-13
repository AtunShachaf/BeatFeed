// jPlayer Initialization
var current_time;
function initSinglePlayer() {
    var players = $('.jplayer');
    players.each(function (e) {
        var player = $(this);
        var ancestor = player.data('ancestor');
        var songUrl = player.data('url');
        player.jPlayer({
            ready: function () {
                $(this).jPlayer("setMedia", {
                    mp3: songUrl
                });
            },
            play: function () { // To avoid multiple jPlayers playing together.
                $(this).jPlayer("pauseOthers");
                var temp = $(this).closest('.song-item').find(".jp-current-time");
                temp.attr("style", "background-color:lightgreen")
                $(this).closest('.song-item').toggleClass("playing-item");
                try {
                    wavesurfer.pause();
                } catch (err) {
                    return;
                }
            },
            pause: function () {
                var temp = $(this).closest('.song-item').find(".jp-current-time");
                temp.attr("style", "background-color:white")
                $(this).closest('.song-item').toggleClass("playing-item");
            },
            swfPath: "jPlayer",
            supplied: "mp3",
            cssSelectorAncestor: ancestor,
            wmode: "window",
            globalVolume: false,
            useStateClassSkin: true,
            autoBlur: false,
            smoothPlayBar: true,
            keyEnabled: true,
            //preload: 'metadata',
            solution: 'html',
            volume: 0.7,
            muted: false,
            backgroundColor: '#000000',
            errorAlerts: false,
            warningAlerts: false,
            timeupdate: function (e) {
                current_time = e.jPlayer.status.currentTime;
            },
            ended: function (e) {
                $(this).closest(".container").next().find(".jp-play").click();
            }
        });
    });
}


$(document).ready(function (e) {
    $('#LoadSongs').on('click', '.jp-next', function (e) {
        var player = $(this).closest('.single_player').find('.jp-jplayer');
        player.jPlayer("play", parseInt(current_time) + 15);

    })

    $('#LoadSongs').on('click', '.jp-prev', function (e) {
        //Rewind
        var player = $(this).closest('.single_player').find('.jp-jplayer');
        if (current_time > 15) {
            player.jPlayer("play", parseInt(current_time) - 15);
        }
    })
})