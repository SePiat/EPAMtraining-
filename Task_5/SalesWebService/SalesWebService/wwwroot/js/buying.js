$(document).ready(function () {
    $.ajax({
        url: '/Buyings/ListOfBuyings',
        type: "Get",
        success: function (data) {
            $('#buyingsContainer').html(data);
        },
        error: errorFunc
    });
    $('#btn_filterBuyingsByManager').click(
        SearchBuyingByManager
    );
    $('#btn_filterBuyingsByBuyer').click(
        SearchBuyingByBuyer
    );
    $('#btn_filterBuyingsByProduct').click(
        SearchBuyingByProduct
    );
    $('#btn_filterBuyingsByDate').click(
        SearchBuyingByDate
    );
    $('#btn_filterBuyingsByCost').click(
        SearchBuyingByCost
    );   
    $('#btn_reset').click(
        ResetListOfBuying
    );
});

function SearchBuyingByManager() {
    $.ajax({
        url: '/Buyings/SearchBuyingByManager?managerName=' + $('#inp_filterBuyingByManager').val(),
        type: "Get",
        success: function (data) {
            $('#buyingsContainer').fadeOut(400,
                function () {
                    $('#buyingsContainer').html(data);
                    $(this).fadeIn(300);
                });
        },
        error: errorFunc
    });
}
function SearchBuyingByBuyer() {
    $.ajax({
        url: '/Buyings/SearchBuyingByBuyer?buyerName=' + $('#inp_filterBuyingByBuyer').val(),
        type: "Get",
        success: function (data) {
            $('#buyingsContainer').fadeOut(400,
                function () {
                    $('#buyingsContainer').html(data);
                    $(this).fadeIn(300);
                });
        },
        error: errorFunc
    });
}
function SearchBuyingByProduct() {
    $.ajax({
        url: '/Buyings/SearchBuyingByProduct?productName=' + $('#inp_filterBuyingByProduct').val(),
        type: "Get",
        success: function (data) {
            $('#buyingsContainer').fadeOut(400,
                function () {
                    $('#buyingsContainer').html(data);
                    $(this).fadeIn(300);
                });
        },
        error: errorFunc
    });
}

function SearchBuyingByDate() {
    $.ajax({
        url: '/Buyings/SearchBuyingByDate?date=' + $('#inp_filterBuyingByDate').val(),
        type: "Get",
        success: function (data) {
            $('#buyingsContainer').fadeOut(400,
                function () {
                    $('#buyingsContainer').html(data);
                    $(this).fadeIn(300);
                });
        },
        error: errorFunc
    });
}
function SearchBuyingByCost() {
    $.ajax({
        url: '/Buyings/SearchBuyingByCost?cost=' + $('#inp_filterBuyingByCost').val(),
        type: "Get",
        success: function (data) {
            $('#buyingsContainer').fadeOut(400,
                function () {
                    $('#buyingsContainer').html(data);
                    $(this).fadeIn(300);
                });
        },
        error: errorFunc
    });
}


function errorFunc(errorData) {
    alert('Error' + errorData.responseText);
}
