$(function () {
    var source = document.getElementById("product-template").innerHTML;
    var template = Handlebars.compile(source);
    $.ajax({
        url: "api/Products",
        success: function (result) {
            console.log('SUCCESS: ', result);

            result.result.map(function (product) {
                $('.products-list').append(template(product))
            });            
        }
    });

    var checkboxes = $('.all-products input[type=checkbox]');

    $('#clear_filters').click(function (e) {
        $(checkboxes).attr('checked', false);
    });

    $('.single-product').click(function (e) {
        if ($(this).hasClass('visible')) {

            var clicked = $(e.target);

            if (clicked.hasClass('close') || clicked.hasClass('overlay')) {
                window.location.hash = '#';
            }
        }
    });

    $(window).on('hashchange', function(){
        render(window.location.hash);
    });

    function render(url) {

        var temp = url.split('/')[0];

        $('.main-content .page').removeClass('visible');

        var	map = {
            '': function() {
                $('.all-products').addClass('visible');
            },
            '#product': function() {
                var index = url.split('product/')[1].trim();
                $("#"+index+".single-product").addClass('visible');
            }
        };
        map[temp]();
    }
});