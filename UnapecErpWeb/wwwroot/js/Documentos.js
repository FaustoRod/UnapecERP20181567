$(document).ready(function () {
    getDocumentos();
    //setDates();
    getProveedores();

    $("#crearDocumentoModal").on("hidden.bs.modal",
        function (e) {
            $("#ProveedorId").val("");
            $("#Numero").val("");
            $("#NumeroFactura").val("");
            $("#Fecha").val(getDate());
            $("#Monto").val("0.00");
        });

    $("#crearDocumentoModal").on("show.bs.modal",
        function (e) {
            //console.log(getDate());
            $("#Fecha").val(getDate());
            getProveedores();
            //$("#Documento").val("");
            //$("#Id").val(0);
        });
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
        "</td><td>" +
        item.estado +
        "</td><td>";
    if (item.estadoId < 2) {
        row += getButton(item.id);
    }

    row +="</td></tr>";
    return row;
}

function getButton(id)
{
    return "<button type='button' class='btn btn-primary' onclick='showPagarDocumento(" + id + ")'>Pagar</button>";
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
                $('#crearDocumentoModal').modal('hide');
                getDocumentos();

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


function getProveedores() {
    $.get("https://localhost:5001/api/Provedor/OptionList", function (data) {
        //console.log(data[0].descripcion);
        data.forEach(element => addOption(element));

    });
}

function addOption(item) {
    var opt = document.createElement("option");
    opt.innerHTML = item.text;
    opt.value = item.value;
    $("#ProveedorId").append(opt);
}

function createDocumento() {
    var id = 0;
    var proveedorId = $("#ProveedorId").val();
    var numero = $("#Numero").val();
    var factura = $("#NumeroFactura").val();
    var fecha = $("#Fecha").val();
    var monto = $("#Monto").val();
    //console.log(id);
    //console.log(proveedorId);
    //console.log(numero);
    //console.log(factura);
    //console.log(fecha);
    console.log(id > 0);

    if (id > 0) {
        $.ajax({
            type: 'PUT',
            url: "https://localhost:5001/api/Documento/Crear",
            data: JSON.stringify({
                proveedorId: proveedorId,
                numero: numero,
                numeroFactura: factura,
                fecha: fecha,
                monto: monto
            }),
            contentType: "application/json",
            dataType: "json",
            statusCode: {
                200: function () {
                    console.log("OK");
                    swal("Exito", "Documento Modificado", "success");
                    window.location.replace("https://localhost:44325/Documento");
                },
                400: function () {
                    swal("Error", "Fallo al Modificar Documento", "error");

                }
            }
        });
    } else {
        $.ajax({
            type: 'POST',
            url: "https://localhost:5001/api/Documento/Crear",
            data: JSON.stringify({
                proveedorId: proveedorId,
                numero: numero,
                numeroFactura: factura,
                fecha: fecha,
                monto: monto
            }),
            contentType: "application/json",
            dataType: "json",
            statusCode: {
                200: function () {
                    console.log("OK");
                    swal("Exito", "Documento Creado", "success");
                    getDocumentos();
                    $('#crearDocumentoModal').modal('hide');
                },
                400: function () {
                    swal("Error", "Fallo al Crear Documento", "error");

                }
            }
        });
    }
}

function getDate() {
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    today = mm + '/' + dd + '/' + yyyy;
    console.log(today);
}