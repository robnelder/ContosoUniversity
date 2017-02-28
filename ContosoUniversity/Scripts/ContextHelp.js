/* Provides Javascript necessary for enabling tooltips and popovers and repositions open popover when window is resized */

/* Enables tooltips and popovers */
$(document).ready(function () {
    $('[data-toggle="popover"]').popover();
    $('[data-toggle="tooltip"]').tooltip();
});
/* Repositions open popover when window is resized */
$(window).resize(function () {
    $('[data-toggle="popover"]').each(function (i, obj) {
        if ($(obj).data('bs.popover').tip().hasClass('in')) {
            $(obj).popover('show');
            return false; // break out of the loop
        }
    });
});