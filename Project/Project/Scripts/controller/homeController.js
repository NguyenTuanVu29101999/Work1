//viết hàm để gọi Ajax

var home = {
    intit: function () {
        home.registerEvents();
    },
    registerEvents: function () {
        getValue();
        $(document).ready(function () {
            $.ajax({
                type: "GET",
                url: "/Home/GetData",
                data: "{}",
                success: function (data) {
                    var s = '<option>Please Select Product</option>';
                    for (var i = 0; i < data.length; i++) {
                        s += '<option value = "' + data[i].DON_GIA + '">' + data[i].TEN_SP + '</option>';
                    }
                    $("#dropdownSelect").html(s);
                }
            });
        });

        function getValue() {
            var myVal = $("#dropdownSelect").val();
            $("#show").val(myVal);
        }
    }
}
home.intit();