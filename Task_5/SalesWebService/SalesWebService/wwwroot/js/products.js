$(document).ready(function () {
    $.ajax({
        url: '/Products/ListOfProducts',
        type: "Get",
        success: function (data) {
            $('#productsContainer').html(data);
        },
        error: errorFunc
    });
    $('#btn_filterProductByName').click(
        SearchProductByName
    );
    $('#btn_filterProductByCost').click(
        SearchProductByCost
    );  
    $('#btn_filterProductByCountBuyers').click(
        SearchProductByCountBuyers
    );
    $('#btn_reset').click(
        ResetListOfProducts
    );
});

function SearchProductByName() {
    $.ajax({
        url: '/Products/SearchProductByName?searchName=' + $('#inp_filterProductByName').val(),
        type: "Get",
        success: function (data) {
            $('#productsContainer').fadeOut(400,
                function () {
                    $('#productsContainer').html(data);
                    $(this).fadeIn(300);
                });
        },
        error: errorFunc
    });
}

function SearchProductByCost() {
    $.ajax({
        url: '/Products/SearchProductByCost?cost=' + $('#inp_filterProductByCost').val(),
        type: "Get",
        success: function (data) {
            $('#productsContainer').fadeOut(400,
                function () {
                    $('#productsContainer').html(data);
                    $(this).fadeIn(300);
                });
        },
        error: errorFunc
    });
}

function SearchProductByCountBuyers() {
    $.ajax({
        url: '/Products/SearchProductByCountBuyers?numberOfBuyers=' + $('#inp_filterProductByCountBuyers').val(),
        type: "Get",
        success: function (data) {
            $('#productsContainer').fadeOut(400,
                function () {
                    $('#productsContainer').html(data);
                    $(this).fadeIn(300);
                });
        },
        error: errorFunc
    });

}

function ResetListOfProducts() {
    $.ajax({
        url: '/Products/ListOfProducts',
        type: "Get",
        success: function (data) {
            $('#productsContainer').fadeOut(400,
                function () {
                    $('#productsContainer').html(data);
                    $(this).fadeIn(300);
                });
        },
        error: errorFunc
    });
}
function errorFunc(errorData) {
    alert('Error' + errorData.responseText);
}
