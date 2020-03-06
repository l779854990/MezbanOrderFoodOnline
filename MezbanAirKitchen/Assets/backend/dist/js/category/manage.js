$(document).ready(function () {
    var filterState = false;
    $("#categoryTable").DataTable({
        'ajax': '',
        'columnDefs': [
            {
                'targets': 0,
                'checkboxes': {
                    'selectRow': true
                }
            }
        ],
        'select': {
            'style': 'multi'
        },
        "searching": false,
        'order': [[1, 'asc']],
        "autoWidth": false
    });
    $(".filterState").on("click",
        function () {
            filterState = !filterState;
            if (filterState) {
                $(".formFilter").toggle("slow");
                $(".arrow-down").show();
                $(".arrow-up").hide();
            } else {
                $(".formFilter").toggle("slow");
                $(".arrow-up").show()
                $(".arrow-down").hide();
            }
        });
    $("#saveCategory").on("click",
        function () {
            const model = {
                Code: $("#Code").val(),
                NameVi: $("#NameVi").val(),
                DiscriptionVi: $("#DiscriptionVi").val(),
                NameEn: $("#NameEn").val(),
                DiscriptionEn: $("#DiscriptionEn").val(),
                SortOrder: $("#SortOrder").val(),
                Status: $("#Status").val()
            }
            $.ajax({
                type: 'POST',
                url: "/Admin/Category/Add",
                data: {
                    __RequestVerificationToken: window.getToken(),
                    model
                },
                dataType: 'json',
                success: function (data) {
                    if (data.result == "Error") {
                        alert(data.message);
                    }
                }
            });

        });
});