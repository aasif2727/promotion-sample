var products = new Array();
var promotions = new Array();

$(document).ready(function () {
    $("input[name='promotionRule']").change(function () {
        var _id = $(this)[0].id.replace("chkPromo_", "");
        if ($(this)[0].checked) {
            promotions.push(_id);
        }
    });
    $("input[name='products']").change(function () {
        var _id = $(this)[0].id.replace("chkProd_", "");
        var _qty = $('#qty_' + _id).val();
        var _name = $('#name_' + _id).html();
        var _price = $('#price_' + _id).html();
        if ($(this)[0].checked && _qty > 0) {
            var product = {};
            product.ProductId = _id;
            product.Title = _name;
            product.Qty = _qty;
            product.UnitPrice = _price;
            products.push(product);
        }
        else {
            alert('Select product count!');
        }
    });
});

function loadCart() {
    debugger;
    discounts = JSON.stringify(promotions);
    if (products.length > 0) {
        $.ajax({
            url: '/home/load?rules=' + discounts + '&productObj=' + JSON.stringify(products),
            type: 'GET',
            success: function (res) {
                $('#cart').empty();
                $('#cart').html(res);
            }
        });
    }
    else {
        alert('No products selected!');
    }
}

