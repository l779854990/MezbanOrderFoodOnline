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
    $.fn.serializeObject = function () {
        let o = {};
        let a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name] !== undefined) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                } o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };
    $("#saveCategory").on("click",
        function () {
            //let formData = new FormData();
            //formData.append('Code', $("#Code").val());
            //formData.append('NameVi', $("#NameVi").val());
            //formData.append('DiscriptionVi', $("#DiscriptionVi").val());
            //formData.append('NameEn', $("#NameEn").val());
            //formData.append('DiscriptionEn', $("#DiscriptionEn").val());
            //formData.append('SortOrder', $("#SortOrder").val());
            //formData.append('Status', $("#Status").val());
            let formData = $('#categoryFormAdd').serializeObject();
            $.ajax({
                type: 'POST',
                url: "/Admin/Category/Add",
                data: {
                    __RequestVerificationToken: window.getToken(),
                    formData
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