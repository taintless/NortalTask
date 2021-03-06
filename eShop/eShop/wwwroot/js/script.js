var ProductsService = function () {
    var fetchProducts = function (filters, success) {
        $.ajax({
            url: "api/Products",
            data: filters,
            traditional: true,
            success: function (result) {
                success(result.result);
            }
        });
    };
    return {
        fetchProducts: fetchProducts
    };
}();

$(function () {
    var productsSource = document.getElementById("products-template").innerHTML;
    var productsTemplate = Handlebars.compile(productsSource);
    var productSource = document.getElementById("product-template").innerHTML;
    var productTemplate = Handlebars.compile(productSource);
    var checkboxes = $('.all-products input[type=checkbox]');
    var cameraIcon = function (value) {
        return '<i class="mdi mdi-camera" data-toggle="tooltip" data-placement="top" title="' + value + '% better than average" aria-hidden="true"></i>'
    };
    var storageIcon = function (value) {
        return '<i class="mdi mdi-database" data-toggle="tooltip" data-placement="top" title="' + value + '% bigger than average" aria-hidden="true"></i>'
    };
    var avgCamera = $('#AvgCamera').val();
    var avgStorage = $('#AvgStorage').val();

    listProducts(null, function () {
        render(window.location.hash);
    });

    function getFiltersValues() {
        var values = {};
        $.each($('#filters-form').serializeArray(), function (i, field) {

            if (!values[field.name])
                values[field.name] = [];

            values[field.name].push(field.value);
        });
        values['order'] = $('#order-by').val();
        return values;
    }
    $('#order-by').change(function () {
        listProducts(getFiltersValues());
    });

    $('.filter-criteria').find('input').change(function () {
        listProducts(getFiltersValues());
    });

    function listProducts(filters, success) {
        ProductsService.fetchProducts(filters, function (products) {
            $('.products-list').empty();

            if (products.length === 0)
                $('.all-products').after().append('<h3 class="no-products text-center">No Products with selected filters.</h3>');
            else
                $('.no-products').remove();

            products.map(function (product) {
                $('.products-list').append(productsTemplate(product));
                if (product.camera > avgCamera)
                    $("li[data-index=" + product.id + "]").find('h2').append(cameraIcon(Math.ceil(100 * (product.camera - avgCamera) / avgCamera)));
                if (product.storage > avgStorage)
                    $("li[data-index=" + product.id + "]").find('h2').append(storageIcon(Math.ceil(100 * (product.storage - avgStorage) / avgStorage)));
                $('.main-content').append(productTemplate(product));
            });

            $(function () {
                $('[data-toggle="tooltip"]').tooltip({
                    delay: { "hide": 100 }
                });
            });
            success && success();
        });
    };

    function fetchProducts(filters, success) {
        ProductsService.fetchProducts(filters, success);
    }

    $('#clear_filters').click(function (e) {
        e.preventDefault();
        $(checkboxes).attr('checked', false);
        listProducts();
    });

    $(window).on('hashchange', function () {
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

        var map = {
            '': function () {
                $('.all-products').addClass('visible');
            },
            '#product': function () {
                var index = url.split('product/')[1].trim();
                showProduct(index);
            }
        };
        map[temp]();
    }
});