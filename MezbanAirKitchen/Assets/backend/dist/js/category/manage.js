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
        function() {
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
        function() {
            const form = $("#categoryFormAdd").serialize();
            $.ajax({
                type: 'POST',
                url: "/Admin/Category/Add",
                header: {
                    __RequestVerificationToken: window.getToken(),
                },
                data: {
                    form
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