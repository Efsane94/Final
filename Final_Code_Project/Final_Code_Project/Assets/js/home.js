$(document).ready(function(){
    $('.owl-carousel').owlCarousel({
        loop:true,
        margin:10,
        nav:true,
        interval:2000,
        responsive:{
            0:{
                items:1
            },
            600:{
                items:2
            },
            1000:{
                items:4
            }
        }
    })   
});


$(function() {
    $('.button-like')
      .bind('click', function(event) {
        $(this).toggleClass("liked");
      })
  });