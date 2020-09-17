var program = program || {};

program.delete = function (id) {
    bootbox.confirm({
        title: "Cảnh báo",
        message: "Bạn có muốn xóa chương trình này không?",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> Không'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Có'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: `/Program/Delete/${id}`,
                    method: "GET",
                    contentType: 'json',
                    success: function (data) {
                        if (data.deleteProgram > 0) {
                            window.location.href = "/Program/Index";
                        }
                    }
                });
            }
        }
    });
}