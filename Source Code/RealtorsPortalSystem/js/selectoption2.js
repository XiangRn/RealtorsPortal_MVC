$(document).ready(function () {
    var $progControl = $(".progControlSelect2").select2({
        
    });
   
    $(".clearSelect2").on("click", function () { $progControl.val(null).trigger("change"); });
})