$(document).ready(function () {
    $('#showtable').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget)
        var recipient = button.data('whatever')
        var modal = $(this)
        modal.find('.modal-body > h1').text(recipient)
    })
});