    
var order = {
    init: function () {
        order.regEvents();
    },
    regEvents: function () {
        $('#btnAddNew').off('click').on('click', function () {
            window.location.href = "/Order/Create";
        });

        $('.btn-delete').off('click').off('click', function () {
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Order/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Order/Index";
                    }
                }
            });
        });

        $('#btnReload').off('click').on('click', function () {
            window.location.href = "/Order/Index";
        });

        
    }
}
order.init();