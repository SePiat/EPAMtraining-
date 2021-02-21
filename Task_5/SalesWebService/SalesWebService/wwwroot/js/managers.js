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
    $('#btn_filterByName').click(
        SearchByName
    );
    $('#btn_filterBySecondName').click(
        SearchBySecondName
    );
    $('#btn_filterByCountBuyers').click(
        SearchByCountBuyers
    );
    $('#btn_reset').click(
        ResetListOfManagers
    );
});

function SearchByName() {
    $.ajax({
        url: '/Managers/SearchByName?SearchName=' + $('#inp_filterByName').val(),
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

function SearchBySecondName() {
    $.ajax({
        url: '/Managers/SearchBySecondName?SecondName=' + $('#inp_filterBySecondName').val(),
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
