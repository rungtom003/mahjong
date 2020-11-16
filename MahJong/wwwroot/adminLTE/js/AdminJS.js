$(document).ready(function () {
    $('#showslip').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget)
        var recipient = button.data('whatever')
        var modal = $(this)
        $('#image_order').attr('src', '/Image/'+recipient+'.jpg');
    })
});