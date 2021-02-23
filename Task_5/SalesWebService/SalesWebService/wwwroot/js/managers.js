$(document).ready(function () {
    $.ajax({
        url: '/Managers/ListOfManagers',
        type: "Get",
        success: function (data) {
            $('#managersContainer').fadeOut(400,
                function () {
                    $('#managersContainer').html(data);
                    $(this).fadeIn(300);
                });
        },
        error: errorFunc
    });
    $('#btn_filterManagerByName').click(
        SearchManagerByName
    );
    $('#btn_filterManagerBySecondName').click(
        SearchManagerBySecondName
    );
    $('#btn_filterByCountBuyers').click(
        SearchByCountBuyers
    );
    $('#btn_reset').click(
        ResetListOfManagers
    );
});

function SearchManagerByName() {
    $.ajax({
        url: '/Managers/SearchManagerByName?SearchName=' + $('#inp_filterManagerByName').val(),
        type: "Get",
        success: function (data) {
            $('#managersContainer').fadeOut(400,
                function () {
                    $('#managersContainer').html(data);
                    $(this).fadeIn(300);
                });
        },
        error: errorFunc
    });
}

function SearchManagerBySecondName() {
    $.ajax({
        url: '/Managers/SearchManagerBySecondName?SecondName=' + $('#inp_filterManagerBySecondName').val(),
        type: "Get",
        success: function (data) {
            $('#managersContainer').fadeOut(400,
                function () {
                    $('#managersContainer').html(data);
                    $(this).fadeIn(300);
                });
        },
        error: errorFunc
    });
}

function SearchByCountBuyers() {
    $.ajax({
        url: '/Managers/SearchByCountBuyers?SearchCountBuyers=' + $('#inp_filterByCountBuyers').val(),
        type: "Get",
        success: function (data) {
            $('#managersContainer').fadeOut(400,
                function () {
                    $('#managersContainer').html(data);
                    $(this).fadeIn(300);
                });
        },
        error: errorFunc
    });

}
function ResetListOfManagers() {
    $.ajax({
        url: '/Managers/ListOfManagers',
        type: "Get",
        success: function (data) {
            $('#managersContainer').fadeOut(400,
                function () {
                    $('#managersContainer').html(data);
                    $(this).fadeIn(300);
                });
        },
        error: errorFunc
    });
}
function errorFunc(errorData) {
    alert('Error' + errorData.responseText);
}
