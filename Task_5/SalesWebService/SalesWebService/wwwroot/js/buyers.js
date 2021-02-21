$(document).ready(function () {
    $.ajax({
        url: '/Buyers/ListOfBuyers',
        type: "Get",
        success: function (data) {
            $('#buyersContainer').fadeOut(400,
                function () {
                    $('#buyersContainer').html(data);
                    $(this).fadeIn(300);
                });
        },
        error: errorFunc
    });
    $('#btn_filterByName').click(
        SearchByName
    );
    $('#btn_filterByCountBuyings').click(
        SearchByCountBuyings
    );
    $('#btn_reset').click(
        ResetListOfBuyers
    );
});

function SearchByName() {
    $.ajax({
        url: '/Buyers/SearchByName?SearchName=' + $('#inp_filterByName').val(),
        type: "Get",
        success: function (data) {
            $('#buyersContainer').fadeOut(400,
                function () {
                    $('#buyersContainer').html(data);
                    $(this).fadeIn(300);
                });
        },
        error: errorFunc
    });
}
function SearchByCountBuyings() {
    $.ajax({
        url: '/Buyers/SearchByCountBuyings?SearchCountBuyings=' + $('#inp_filterByCountBuyings').val(),
        type: "Get",
        success: function (data) {
            $('#buyersContainer').fadeOut(400,
                function () {
                    $('#buyersContainer').html(data);
                    $(this).fadeIn(300);
                });
        },
        error: errorFunc
    });

}
function ResetListOfBuyers() {
    $.ajax({
        url: '/Buyers/ListOfBuyers',
        type: "Get",
        success: function (data) {
            $('#buyersContainer').fadeOut(400,
                function () {
                    $('#buyersContainer').html(data);
                    $(this).fadeIn(300);
                });
        },
        error: errorFunc
    });
}
function errorFunc(errorData) {
    alert('Error' + errorData.responseText);
}
