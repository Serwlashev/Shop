// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function AddProduct() {

    $.ajax({
        type: "GET",
        url: "/Products/AddToCart",
        success: function (response) {
            alert("Hello: " + response.Name + " .\nCurrent Date and Time: " + response.DateTime);
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    })
}