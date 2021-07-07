$(function() {


    $('.slide-one-item').owlCarousel({
        center: false,
        autoplayHoverPause: true,
        items: 1,
        loop: true,
        stagePadding: 0,
        margin: 0,
        smartSpeed: 2000,
        autoplay: true,
        autoplayTimeout: 15000,
        /* autoplaySpeed: 5000,*/
        pauseOnHover: true,
        dots: true,
        nav: true,
        navText: ['<span class="icon-keyboard_arrow_left">', '<span class="icon-keyboard_arrow_right">']
    });

	
})