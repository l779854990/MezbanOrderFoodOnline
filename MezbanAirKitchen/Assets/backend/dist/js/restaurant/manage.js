$(document).ready(function () {
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
});