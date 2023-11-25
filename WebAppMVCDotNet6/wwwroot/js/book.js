
var dataTable;
$(document).ready(function (){

    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url":"/Books/GetAll"
        },
        "columns": [
            { "data": "bookTitle", "width": "15%" },
            { "data": "description", "width": "15%" },
            { "data": "price", "width": "15%" },
           { "data": "category.name", "width": "15%" }
        ]
    });
    
})