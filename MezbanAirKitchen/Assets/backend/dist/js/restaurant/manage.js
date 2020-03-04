$(document).ready(function () {
    var filterState = false;
    $("#restaurantTable").DataTable({
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
});