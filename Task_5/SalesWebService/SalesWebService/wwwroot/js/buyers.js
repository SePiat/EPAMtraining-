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
});
function errorFunc(errorData) {
    alert('Error' + errorData.responseText);
}