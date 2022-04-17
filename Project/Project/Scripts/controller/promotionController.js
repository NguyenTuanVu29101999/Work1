
var promotion = {
    init: function () {
        promotion.regEvents();
    },
    regEvents: function () {
        $('#btnAddNewPro').off('click').on('click', function () {
            window.location.href = "/Promotion/Create";
        });

      

        $('#btnReloadPro').off('click').on('click', function () {
            window.location.href = "/Promotion/Index";
        });


    }
}
promotion.init();