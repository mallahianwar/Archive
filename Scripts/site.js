function RefrechParam(params) {
    if (params != null) {
        var param = "{";
        var i = 0;
        var lastChr = "";
        for (var AjaxParams of params) {
            i++;
            if (params.length == i)
                lastChr = "";
            else
                lastChr = ",";

            param += '' + AjaxParams.paramId + ':' + $('#' + AjaxParams.inputId).val() + lastChr;
        }
        param += "}";

        return malformedJSON2Object(param);

    }
}
function malformedJSON2Object(tar) {
    var obj = {};
    tar = tar.replace(/^\{|\}$/g, '').split(',');
    for (var i = 0, cur, pair; cur = tar[i]; i++) {
        pair = cur.split(':');
        obj[pair[0]] = /^\d*$/.test(pair[1].replace("", "-1")) ? +pair[1] : pair[1];
    }
    return obj;
}
var oTable = '';
function initDataTable(tableWrapperId, isServerSide, isProcessing, ajaxURL, ajaxType, pageLength, params, DrawCallbackFunction) {

    var table = $(tableWrapperId);
    oTable = table.DataTable({
        // ajax
        "processing": isProcessing,
        "serverSide": isServerSide,
        "ajax": {
           
            "url": ajaxURL,
            "type": ajaxType,
            "data": function (d) {
                return  $.extend({}, d, RefrechParam(params)) 
            }
            , 
        },
      
        //                    "columns": columnsData,

        // Internationalisation. For more info refer to http://datatables.net/manual/i18n
        "language": {
            "aria": {
                "sortAscending": ":  Ascending order",
                "sortDescending": ": Descending order"
            },
            "emptyTable": "لا يوجد بيانات",
            "info": "عرض _START_ الى _END_ من _TOTAL_ صفوف",
            "infoEmpty": "لا يوجد بيانات",
            "infoFiltered": "(filtered1 from _MAX_ total)",
            "lengthMenu": "_MENU_ اظهار",
            "search": "search:",
            "processing": "يتم التحميل .....",
            "zeroRecords": "لا يوجد بيانات"
        },

        // Or you can use remote translation file
        //"language": {
        //   url: '//cdn.datatables.net/plug-ins/3cfcc339e89/i18n/Portuguese.json'
        //},


        // setup responsive extension: http://datatables.net/extensions/responsive/
        responsive: false,
        "bFilter": false,
        "ordering": true, //disable column ordering 
        //"paging": false, disable pagination
        "dom": '<"top"l>rt<"bottom"ip><"clear">',
        "order": [
            [0, 'asc'] 

        ],
        //columnDefs: [{ orderable: true, targets: [0] }],
        //columnDefs: [{
        //    targets: [0],
        //    orderData: [0, 1]
        //}, {
        //    targets: [1],
        //    orderData: [1, 0]
        //}],
        "lengthMenu": [
            [5, 10, 20, 50, 100, 400]
            , [5, 10, 20, 50, 100, "All"] // change per page values here
        ],
        // set the initial value
        "pageLength": pageLength,
        "initComplete": function (settings, json) {
         
            if ($('#listevent').val() == "") {

                $("#btnclear").hide();
            }
            else {
                $("#btnclear").show();
            }
           
        },
        "drawCallback": function (settings) {

           
            if ($('#listevent').val() == "") {

                $("#btnclear").hide();
            }
            else {
                $("#btnclear").show();
            }
            if (typeof DrawCallbackFunction === "function") {
                
                DrawCallbackFunction()
            }
        }
    });
    $('#datatable_tools > li > a.tool-action').on('click', function () {
        var action = $(this).attr('data-action');
    });
}
function refreshDtable() {
    oTable.ajax.reload();
}
