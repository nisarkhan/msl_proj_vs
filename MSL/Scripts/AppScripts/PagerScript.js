function checkfile(sender) {
    var validExts = new Array(".xlsx", ".xls");
    var fileExt = sender.value; 
    fileExt = fileExt.substring(fileExt.lastIndexOf('.'));
    if (validExts.indexOf(fileExt) < 0) {
        //alert("Invalid file selected, valid files are of " + validExts.toString() + " types.");
        document.getElementById("btnImportData").disabled = true;
        $('#form_header').submit();//.val("pageSizeDDL");
        return false;
    }
    else {
        document.getElementById("btnImportData").disabled = false;
        return true;
    }
}


$(function () {

    
    //$("#btnImportData").click(function () {
    //    $("#loading").fadeIn();
    //});

    $("#form_header_file").submit(function (e) {
        $("#myLoadingElement").show();
    });


    $('#btnRemoveFromGrid').prop('disabled', true);
    //$('#PageSize').prop('disabled', true);
    
    
    var spanValue = parseInt($('#validatefailedcount').text());
    if (spanValue > 0)
    {
        //disable the save button
        $('#btnSavetoDB').prop('disabled', true);
    }
    else
    {
        //enable the save button
        $('#btnSavetoDB').prop('disabled', false);
    }

    var rowCount = $('#webgrid_id >tbody >tr').length;
    if (rowCount > 0) {
        //$('#btnSavetoDB').prop('disabled', false); //enable
        $('#btnRemoveFromGrid').prop('disabled', false);
        //if (rowCount > 5) { $('#PageSize').prop('disabled', false); }
        $('#detaildiv').show();
    }
    else
    {
        $('#btnSavetoDB').prop('disabled', true);
        $('#btnValidateData').prop('disabled', true);
        $('#detaildiv').hide();
    }

    //$('#gridPager ul').addClass('pagination');
    //$('tfoot').hide();

    $('#PageSize').change(function () {        
        $('#form_header_pager').submit()
        return false;
    });

    $('#ShowRecords').change(function () {
        $('#form_header_show_records').submit()
        return false;
    });

    $('#btnImportData').prop('disabled', true);
    $('#fileUpload').change(function () {
        if ($(this).val()) {
            //$('#btnImportData').prop('disabled', false);
        } else {
            //$('#btnImportData').prop('disabled', 'disabled');
        }
    });


    //$('tbody tr').hover(function () {
    //    $(this).addClass('webgrid-selected-row');
    //}).on('click', function () {
    //    //location.href = '/Details/' + $(this).find('td:first').text();
    //});

    //$('#webgrid_id').on('click', 'tr:not(.webgrid-selected-row)', function () {
    //    $(this).add('tr.webgrid-selected-row').toggleClass('webgrid-selected-row');
    //});

    $('#webgrid_id').on('click', 'tr', function () {
        $('tr.yellow').removeClass('yellow');
        $(this).addClass('yellow');
    });
    
    //$(".warrantyEndDate").datepicker();
    $(".date").datepicker({ format: 'mm/dd/yy' });

    //$(".date").datepicker({
    //    dateFormat: 'mm/dd/yy', autoclose: true,
    //    showOn: "button", todayHighlight: true,
    //    //buttonImage: "../calendar/images/calendar.gif",
    //    buttonImageOnly: true,
    //    changeMonth: true,
    //    changeYear: true, clearBtn: true
    //});

   // $("input[id$=WarrantyEndDate]").datepicker({});
    
    //$("input[id$=WarrantyEndDate]").datepicker({
    //    dateFormat: 'mm/dd/yy', autoclose: true,
    //    showOn: "button", todayHighlight: true,
    //    //buttonImage: "../calendar/images/calendar.gif",
    //    buttonImageOnly: true,
    //    changeMonth: true,
    //    changeYear: true, clearBtn: true
    //});

    //$(this).addClass('.webgrid-selected-row');
    //$('#webgrid_id tr').not(this).removeClass('.webgrid-selected-row');

    //$('#SearchText').change(function () {

    //    $('#frmDetails').submit()
    //    return false;

    //});

    //$('#gridPager a').click(function (e) {

    //    var form = $('#frmDetails');
    //    form.attr("action", this.href);
    //    $(this).attr("href", "javascript:");
    //    form.submit();

    //});

    //$('th a').click(function () {

    //    var form = $('#frmDetails');
    //    form.attr("action", this.href);
    //    $(this).attr("href", "javascript:");
    //    form.submit();

    //});

    //setArrowImages();

});