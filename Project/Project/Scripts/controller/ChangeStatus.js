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
                url: "/Order/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == 1) {
                        btn.text('Mới nhận');
                    } else if (response.status == 2) {
                        btn.text('Đang giặt');
                    } else if (response.status == 3) {
                        btn.text('Giặt xong');
                    } else {
                        btn.text('Đã giao');
                    }
                }
            });
        });

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