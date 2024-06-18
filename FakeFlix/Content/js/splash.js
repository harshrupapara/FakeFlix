

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































//$(document).ready(function () {

//    // Check if the current page is the home page ("/" or "/home")
//    if (window.location.pathname === '/' || window.location.pathname === '/home' || window.location.pathname === "/en") {
//        // Remove the animationDiv after 5 seconds
//        $('#main-content').hide();
//        // Set cookie
//        function createCookie(name, value, hours) {
//            var expires;
//            if (hours) {
//                var date = new Date();
//                date.setTime(date.getTime() + (hours * 60 * 60 * 1000));
//                expires = "; expires=" + date.toGMTString();
//            } else {
//                expires = "";
//            }
//            document.cookie = name + "=" + value + expires + "; path=/";
//        }

//        var visitedCookie = $.cookie('visited');
//        if (visitedCookie == null) {
//            createCookie('visited', 'true', 1);
//        }
//        if (cookie("visited") == true) {
//            setTimeout(function () {
//                $('#container').css('display', '');
//                $('#container').remove();
//                $('#main-content').show();
//            }, 5000);
//        }
//    }
//    else {
//        $('#container').hide();
//        $('#main-content').show();
//    }
//});


////window.addEventListener('load', function () {
////    var homepagePaths = ["/", "/home"];
////    var currentPath = window.location.pathname;
////    if (homepagePaths.includes(currentPath)) {
////        var myDiv = document.getElementById('container');
////        myDiv.style.display = "flex";


////    }
////});