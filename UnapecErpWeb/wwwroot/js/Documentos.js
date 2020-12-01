$(document).ready(function () {
    getDocumentos();
    //setDates();
    
});

function getDocumentos() {
    $.get("https://localhost:5001/api/Documento", function (data) {
        //console.log(data[0].descripcion);
        //alert(data);
        $("#documentosList").empty();
        $("#documentosList").html(getTableBody(data));

    });

}

function searchDocumentos() {
    var numero = $("#DocumentoSearch_Numero").val();
    var factura = $("#DocumentoSearch_NumeroFactura").val();
    var estado = $("#DocumentoSearch_EstadoDocumentoId").val();
    var desde = $("#DocumentoSearch_FechaDesde").val();
    var hasta = $("#DocumentoSearch_FechaHasta").val();

    $.ajax({
        type: 'POST',
        url: "https://localhost:5001/api/Documento/Buscar/",
        contentType: "application/json",
        data: JSON.stringify({ numero: numero, numeroFactura: factura, fechaDesde: desde, fechaHasta: hasta, estadoDocumentoId: estado }),
        dataType: "json",
        success: function(data) {
            console.log(data);
        }
    });

    console.log(numero);
    console.log(factura);
    console.log(estado);
    console.log(desde);
    console.log(hasta);
}

function getTableBody(itemList) {
    var body = "";
    itemList.forEach(e => body += getRows(e));
    return body;
}

function getRows(item) {
    console.log(item);
    var row = "<tr><td>" + item.numero + "</td><td>" + item.factura + "</td><td>" + item.proveedor + "</td><td>" + item.fecha + "</td><td>" + item.monto + "</td><td>" + item.estado + "</td><td><button type='button' class='btn btn-primary' onclick='showPagarDocumento(" + item.id + ")'>Pagar</button></td></tr>";
    return row;
}

function showPagarDocumento(id) {
    if (id > 0) {
        swal("Desea Cambiar Estado de Documento a Pago?",
            {
                buttons: {
                    cancel: {
                        text: "No",
                        value: false,
                        visible: true,
                        className: "",
                        closeModal: true
                    },
                    confirm: {
                        text: "Si",
                        value: true,
                        visible: true,
                        className: "",
                        closeModal: false
                    }
                }
            }).then((value) => {
                if (value) {
                    pagarDocumento(id);
                }
            });

    }
}

function pagarDocumento(id) {
    $.ajax({
        type: 'POST',
        url: "https://localhost:5001/api/Documento/Pagar/" + id,
        contentType: "application/json",
        dataType: "json",
        statusCode: {
            200: function () {
                console.log("OK");
                swal("Exito", "Documento Pago", "success");
                $('#crearProveedorModal').modal('hide');
                getConceptoPagos();

            },
            400: function () {
                swal("Error", "Fallo al Pagar Documento", "error");

            }
        }
    });
}

function setDates() {
    $("#DocumentoSearch_FechaDesde").val(new Date());
}