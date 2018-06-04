$(function () {

    $('#dialog').dialog({
        buttons: [{ text: "OK", click: addDataToTable }],
        modal: true,
        autoOpen: false,
        width: 340
    })

    $('#show').button().click(function () {
        $('#dialog').dialog("open");
    })

    function addDataToTable() {
        $('#placeholder').hide();

        $('<tr><td>' + $('#product').val() + '</td><td>' + $('#color').val() +
            '</td><td>' + $('#count').val() + '</td></tr>').appendTo('#prods tbody');

        $('#dialog').dialog("close");
    }

});