//viết hàm để gọi Ajax

var user = {
    intit: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        // viết Event khi click vào trạng thái thì sẽ lấy dc cái ID của class tag <a></a>
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Accounts/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn.text('Kích hoạt');
                    } else {
                        btn.text('Khóa');
                    }
                }
            });
        });
    }
}
user.intit();