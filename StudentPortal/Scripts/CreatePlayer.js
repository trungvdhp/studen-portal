function CreatePlayer(file, streamer) {
    agent = navigator.userAgent.toLowerCase();
    if (agent.indexOf("iphone") >= 0 || agent.indexOf("ipad") >= 0 || agent.indexOf("ipod") >= 0) {
        $('.playerpopcon').append("<audio id='mediaRadio' controls='controls'><source src='http://vov.radiovietnam.vn:1935/live/" + file + ".stream/playlist.m3u8?timestamp=" + timestamp + "&signature=" + signature + "'></audio>");
        $("#playerpop").html("<div class='rdo-player-tool onleft'><div class='rdo-player-play onleft'></div><div class='rdo-player-pause onleft'></div><div class='rdo-player-timevalue onleft'> 00:00 </div><div class='rdo-player-timer onleft'><div class='rdo-player-timepass onleft'></div></div></div><div class='rdo-player-status onleft rdo-player-statusloading'></div>");
        $('.rdo-player-timer').width(160);
    }
    else {
        if (FlashDetect.installed) {
            jwplayer('playerpop').setup({
                flashplayer: '/media/RadioPlayer.swf',
                controlbar: 'bottom',
                width: '300',
                height: '42',
                volume: 100,
                timestamp: timestamp,
                signature: signature,
                skin: '/media/radiovietnam/radiovietnam.xml',
                autostart: 'true',
                modes: [{ type: 'flash', src: '/media/RadioPlayer.swf', config: { streamer: streamer, provider: "rtmp", file: file + ".stream" } }, { type: 'html5', config: { width: 300, height: 42, file: streamer.replace("rtmp", "rtsp") + '/' + file + '.stream?timestamp=' + timestamp + '&signature=' + signature, provider: 'sound' } }],
                events: {
                    onReady: function () {
                        var h = $('.playerpop-row').outerHeight(true) + $('.playerpop-lower').outerHeight(true) + 75;
                        var w = 360;
                        self.resizeTo(w, h);
                        self.moveTo(0, screen.availHeight - $(window).height());
                    },
                    onError: function () {
                    }
                }
            });
        }
        else {
            $('.playerpopcon').append("<audio id='mediaRadio' autoplay controls='controls'><source src='rtsp://vov2.radiovietnam.vn:1935/live/" + file + ".stream?timestamp=" + timestamp + "&signature=" + signature + "' type='audio/mpeg'></audio>");
            $("#playerpop").html("<div class='rdo-player-tool onleft'><div class='rdo-player-play onleft'></div><div class='rdo-player-pause onleft'></div><div class='rdo-player-timevalue onleft'> 00:00 </div><div class='rdo-player-timer onleft'><div class='rdo-player-timepass onleft'></div></div><div id='btnMute' class='rdo-player-mute onright'></div></div><div class='rdo-player-status onleft'></div>");
        }
    }
    if ($('#mediaRadio').length > 0) {
        audio = document.getElementById('mediaRadio');
        $('.rdo-player-play').click(function () {
            playMusic();
            $('.rdo-player-play').hide();
            $('.rdo-player-pause').show();
            isPlay = true;
        });
        $('.rdo-player-pause').click(function () {
            pauseMusic();
            $('.rdo-player-play').show();
            $('.rdo-player-pause').hide();
            isPlay = false;
        });
        $('#btnMute').click(function () {
            if ($(this).hasClass("rdo-player-mute")) {
                $(this).removeClass("rdo-player-mute").addClass("rdo-player-loud");
                audio.volume = 0.0;
            }
            else {
                $(this).removeClass("rdo-player-loud").addClass("rdo-player-mute");
                audio.volume = 1.0;
            }
        });
        audio.addEventListener('timeupdate', function (e) {
            getDuration();
            if ($('.rdo-player-timevalue').text().indexOf("00:00") >= 0) {
                $('.rdo-player-status').html("Vui lòng xin chờ lưu tín hiệu vào bộ đệm...");
                $('.rdo-player-status').addClass("rdo-player-statusloading");
            }
            else if ($('.rdo-player-timevalue').text().indexOf("Infinity:NaN") >= 0) {
                window.location.reload(true);
            }
            else {
                $('.rdo-player-status').html("Tín hiệu đang phát...");
                $('.rdo-player-status').removeClass("rdo-player-statusloading");
            }
        }, false);
        if (agent.indexOf("iphone") < 0 && agent.indexOf("ipad") < 0 && agent.indexOf("ipod") < 0) {
            $('.rdo-player-play').hide();
            $('.rdo-player-pause').show();
            isPlay = true;
            $(window).unload(function () {
                removeMusic();
            });
        }
        else {
            $('.rdo-player-status').html("Vui lòng nhấn vào nút Play để chạy");
        }
    }
}