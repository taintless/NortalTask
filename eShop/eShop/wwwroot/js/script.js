$(function () {

    var productsSource = document.getElementById("products-template").innerHTML;
    var productsTemplate = Handlebars.compile(productsSource);
    var productSource = document.getElementById("product-template").innerHTML;
    var productTemplate = Handlebars.compile(productSource);

    listProducts();

    $('.filter-criteria').find('input').change(function () {
        var values = {};
        $.each($('#filters-form').serializeArray(), function (i, field) {

            if (!values[field.name])
                values[field.name] = [];

            values[field.name].push(field.value);
        });

        listProducts(values);

    });

    function listProducts(filters) {
        fetchProducts(filters).then(function (products) {
            $('.products-list').empty();

            if (products.length === 0)
                $('.all-products').after().append('<h3 class="no-products text-center">No Products with selected filters.</h3>');
            else
                $('.no-products').remove();

            products.map(function (product) {
                $('.products-list').append(productsTemplate(product));
                $('.main-content').append(productTemplate(product));
            });

    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })
        });
    }

    function fetchProducts(filters) {
        return new Promise(function (resolve, reject) {
            $.ajax({
                url: "api/Products",
                data: filters,
                traditional: true,
                success: function (result) {
                    resolve(result.result);
                }
            });
        });
    }

    var checkboxes = $('.all-products input[type=checkbox]');

    $('#clear_filters').click(function (e) {
        e.preventDefault();
        $(checkboxes).attr('checked', false);
        listProducts();
    });

    $(window).on('hashchange', function(){
        render(window.location.hash);
    });

    function showProduct(id) {
        $('.single-product').click(function (e) {
            if ($(this).hasClass('visible')) {

                var clicked = $(e.target);

                if (clicked.hasClass('close') || clicked.hasClass('overlay')) {
                    window.location.hash = '#';
                }
            }
        });
        $("#" + id + ".single-product").addClass('visible');
    }

    function render(url) {

        var temp = url.split('/')[0];

        $('.main-content .page').removeClass('visible');

        var	map = {
            '': function() {
                $('.all-products').addClass('visible');
            },
            '#product': function() {
                var index = url.split('product/')[1].trim();
                showProduct(index);
            }
        };
        map[temp]();
    }
});