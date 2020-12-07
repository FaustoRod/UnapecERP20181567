$(document).ready(function () {

});

function searchDocumentos() {
    var desde = $("#DocumentoSearch_FechaDesde").val().substring(0, 10);
    var hasta = $("#DocumentoSearch_FechaHasta").val().substring(0, 10);
    console.log(desde.substring(0, 10));
    console.log(hasta.substring(0, 10));
    $.ajax({
        type: 'POST',
        url: "https://localhost:5001/api/Documento/BuscarAsiento",
        //url: "https://unapec20181567.azurewebsites.net/api/Documento/BuscarAsiento",
        contentType: "application/json",
        data: JSON.stringify({ numero: "", numeroFactura: "", fechaDesde: desde, fechaHasta: hasta, estadoDocumentoId: 0 }),
        dataType: "json",
        success: function (data) {
            console.log(data);
            $("#documentosList").empty();
            if (data.length > 0) {
                $("#documentosList").html(getTableBody(data));

            } else {
                $("#documentosList").html("");

            }
        }
    });

    //console.log(numero);
    //console.log(factura);
    //console.log(estado);
    //console.log(desde);
    //console.log(hasta);
}

function enviarAsientos() {
    var desde = $("#DocumentoSearch_FechaDesde").val();
    var hasta = $("#DocumentoSearch_FechaHasta").val();
    //console.log(desde);
    //console.log(hasta);
    $.ajax({
        type: 'POST',
        url: "https://localhost:5001/api/Documento/EnviarAsiento",
        contentType: "application/json",
        data: JSON.stringify({ numero: "", numeroFactura: "", fechaDesde: desde, fechaHasta: hasta, estadoDocumentoId: 0 }),
        dataType: "json",
        success: function (data) {
            console.log(data);
            
        }
    });

    //console.log(numero);
    //console.log(factura);
    //console.log(estado);
    //console.log(desde);
    //console.log(hasta);
}

function getTableBody(itemList) {
    var body = "";
    itemList.forEach(e => body += getRows(e));
    return body;
}

function getRows(item) {
    var row = "<tr><td>" +
        item.numero +
        "</td><td>" +
        item.factura +
        "</td><td>" +
        item.proveedor +
        "</td><td>" +
        item.fecha +
        "</td><td>" +
        item.monto +
        "</td>";
    return row;
}

function getDate() {
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    today = mm + '/' + dd + '/' + yyyy;
    console.log(today);
}