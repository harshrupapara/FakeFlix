var carouselContainer = document.querySelector('carousel-inner');
var firstDiv = document.getElementsByClassName('carousel-item')[0];
firstDiv.classList.add('active');

const play_button = document.getElementsByClassName(".youtube-play-btn");
play_button.style.cssText = 'background: url("../../Content/images/play-button.png") no-repeat center';