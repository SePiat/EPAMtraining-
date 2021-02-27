$(document).ready(function () {
    $.ajax({
        url: '/Buyers/ListOfBuyers',
        type: "Get",       
        success: function (data) {
            $('#buyersContainer').html(data);            
        },
        error: errorFunc
    });
    $('#btn_filterBuyerByName').click(
        SearchBuyerByName
    );
    $('#btn_filterByCountBuyings').click(
        SearchByCountBuyings
    );
    $('#btn_reset').click(
        ResetListOfBuyers
    );
});


function SearchBuyerByName() {
    $.ajax({
        url: '/Buyers/SearchByName?searchName=' + $('#inp_filterBuyerByName').val(),
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
        url: '/Buyers/SearchByCountBuyings?searchCountBuyings=' + $('#inp_filterByCountBuyings').val(),
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
