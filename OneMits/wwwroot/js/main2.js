
/* -------------------------------- 

signup and signin

-------------------------------- */
$(".email-signup").hide();
$("#signup-box-link").click(function () {
    $(".email-login").fadeOut(100);
    $(".email-signup").delay(100).fadeIn(100);
    $("#login-box-link").removeClass("active");
    $("#signup-box-link").addClass("active");
});
$("#login-box-link").click(function () {
    $(".email-login").delay(100).fadeIn(100);;
    $(".email-signup").fadeOut(100);
    $("#login-box-link").addClass("active");
    $("#signup-box-link").removeClass("active");
});

/* -------------------------------- 

navbar

-------------------------------- */

function myFunction() {
    var x = document.getElementById("myTopnav");
    if (x.className === "topnav") {
        x.className += " responsive";
    } else {
        x.className = "topnav";
    }
}


/* -------------------------------- 

read More

-------------------------------- */


$('.hiding').addClass('hide-me');

$('.read-more').on('click', function () {
    $(this).addClass('hide-me');
    $('.hiding').toggle();
    $('.dots').toggle();
});
$('.show-less').on('click', function () {
    $(this).removeClass('hide-me');
    $('.read-more').removeClass('hide-me');
    $('.hiding').toggle();
    $('.dots').toggle();
});



/* -------------------------------- 

like button

-------------------------------- */


$('.fa-heart').on('click', function (event, count) {
    event.preventDefault();

    var $this = $(this),
        count = $this.attr('data-count'),
        active = $this.hasClass('active'),
        multiple = $this.hasClass('multiple-count');


    $.fn.noop = $.noop;
    $this.attr('data-count', !active || multiple ? ++count : --count)[multiple ? 'noop' : 'toggleClass']('active');

});

/* -------------------------------- 

Dyanmic TAgs

-------------------------------- */
$('.tabgroup > div').hide();
$('.tabgroup > div:first-of-type').show();
$('.tabs a').click(function (e) {
    e.preventDefault();
    var $this = $(this),
        tabgroup = '#' + $this.parents('.tabs').data('tabgroup'),
        others = $this.closest('li').siblings().children('a'),
        target = $this.attr('href');
    others.removeClass('active');
    $this.addClass('active');
    $(tabgroup).children('div').hide();
    $(target).show();

})
    /* -------------------------------- 
    
    Dyanmic TAgs
    
    -------------------------------- */


    (function ($, document) {

        // get tallest tab__content element
        let height = -1;

        $('.tab__content').each(function () {
            height = height > $(this).outerHeight() ? height : $(this).outerHeight();
            $(this).css('position', 'absolute');
        });

        // set height of tabs + top offset
        $('[data-tabs]').css('min-height', height + 40 + 'px');

    }(jQuery, document));


/* --------------------------------

NavBar

-------------------------------- */

$(document).ready(function () {
    (function ($) {
        $(".header-icon_nav").click(function (e) {
            e.preventDefault();
            $("body").toggleClass("with-sidebar_nav");
        });

        $(".overlay_nav").click(function (e) {
            $("body").removeClass("with-sidebar_nav");
        });
    })(jQuery);
});


/* --------------------------------

Like

-------------------------------- */

$(document).ready(function () {
    //LIKE
    $("a.like").click(function () {
        var id = $(this).data("QuestionId");
        var link = "/Article/LikeThis/" + QuestionId;
        var a = $(this);
        $.ajax({
            type: "GET",
            url: link,
            success: function (result) {
                a.html('<i class="fa fa-heart fa-lg text-danger"></i> (' + result + ')').removeClass("like").addClass("unlike");
            }
        });
    });


