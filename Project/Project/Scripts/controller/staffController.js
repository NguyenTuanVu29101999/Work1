
var staff = {
    init: function () {
        staff.regEvents();
    },
    regEvents: function () {
        $('#btnAddNewStaff').off('click').on('click', function () {
            window.location.href = "/Staff/Create";
        });

        $('.btn-delete').off('click').off('click', function () {
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Order/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Staff/Index";
                    }
                }
            });
        });

        $('#btnReloadStaff').off('click').on('click', function () {
            window.location.href = "/Staff/Index";
        });


    }
}
staff.init();