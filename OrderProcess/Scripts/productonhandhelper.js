var productsOnHandCollection = {};
var formProductModelToPost = {};
function Post() {
    var dataType = 'application/json; charset=utf-8';
    formProductModelToPost.Quantity = $('#formQuantity').val();
    console.log('Submitting form...');
    $.ajax({
        type: "POST",
        dataType: "json",
        data: JSON.stringify(formProductModelToPost), //JSON.stringify(data),
        url: "../api/ticket",
        contentType: "application/json; charset=utf-8"
    });
    formProductModelToPost = {};
}

var uri = '../api/productonhand';
$(document).ready(function () {

    $.ajax({
        type: 'GET',
        url: uri,
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        async: false
    }).done(function (data) {
        var html;
        productsOnHandCollection = data;
        jQuery.each(data,
            function (index, item) {
                html += "<tr><td>" +
                    item.Product.ID +
                    "</td><td>" +
                    item.Product.PartNumber +
                    "</td><td class='quantity'>" +
                    item.Quantity +
                    "</td><td>" +
                    item.Product.PartName +
                    "</td><td>" +
                    item.Product.Supplier +
                    "</td><td>" +
                    item.Product.DropoffLocation +
                    "</td><td><button product-id=" + item.Product.ID + ">Show</button></td></tr>";

            })
        $("#productsonhand").append(html);
    });


    $('header button').click(function (e) {
        e.preventDefault();
        var productId = $(e.currentTarget).attr("product-id");

        bindFormProductOnHandData(productId);

        $('form > div:nth-of-type(1)').addClass('openForm'),
            $('nav').addClass('navFade')
    })
    $('.dismiss').click(function () {
        $('form > div:nth-of-type(1)').removeClass('openForm'),
            $('nav').removeClass('navFade')
    })
    $('#postForm').click(function (e) {
        e.preventDefault();
        Post();
    });
});

function bindFormProductOnHandData(productId) {
    //Get productOnHand from globally scoped variable based on input of productId by looping all items in productsOnHandCollection
    for (var i = 0; i < productsOnHandCollection.length; i++) {
        if (productsOnHandCollection[i].Product.ID == productId)
            formProductModelToPost = productsOnHandCollection[i];
    }

    $('#formQuantity').attr('max', formProductModelToPost.Quantity);
    $('#productId').val(formProductModelToPost.Product.ID);
    $('#partNumber').val(formProductModelToPost.Product.PartNumber);
    $('#partName').val(formProductModelToPost.Product.PartName);
    $('#partSupplier').val(formProductModelToPost.Product.Supplier);
    $('#partDropoffLocation').val(formProductModelToPost.Product.DropoffLocation);
}