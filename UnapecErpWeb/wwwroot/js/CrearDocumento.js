$(document).ready(function () {
    getProveedores();

    $("#crearDocumentoModal").on("hidden.bs.modal",
        function (e) {
            //$("#Nombre").val("");
            //$("#Documento").val("");
            //$("#Id").val(0);
        });

    $("#crearDocumentoModal").on("show.bs.modal",
        function (e) {
            console.log(getDate());
            $("#Fecha").val(getDate());
            getProveedores();
            //$("#Documento").val("");
            //$("#Id").val(0);
        });
});

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
    console.log(id);
    console.log(proveedorId);
    console.log(numero);
    console.log(factura);
    console.log(fecha);
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