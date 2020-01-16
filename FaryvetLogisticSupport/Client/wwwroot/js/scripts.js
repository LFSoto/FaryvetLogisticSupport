function DataTableAdd() {
    $(document).ready(function () {
        $('#datatable').DataTable();
    });
}

function DataTableRemove() {
    $(document).ready(function () {
        $('#datatable').DataTable().destroy();
    });
}