

$(document).ready(function () {

    // Check if the current page is the home page ("/" or "/home")
    if (window.location.pathname === '/' || window.location.pathname === '/home' || window.location.pathname === "/en") {
        // Remove the animationDiv after 5 seconds
        $('#main-content').hide();

        setTimeout(function () {
            $('#container').css('display', '');
            $('#container').remove();
            // Add the newDiv after removing animationDiv
            $('#main-content').show();
            $('#intro-sound').remove();

            // Pause and reset the audio
            //$('#intro-sound').get(0).pause();
            //$('#intro-sound').get(0).currentTime = 0;
        }, 5000);
    }
    else {
        $('#intro-sound').show();
        $('#container').hide();
        $('#main-content').show();
    }
});