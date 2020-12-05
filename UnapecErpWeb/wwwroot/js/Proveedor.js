$(document).ready(function () {
    getConceptoPagos();

    $("#crearProveedorModal").on("hidden.bs.modal",
        function (e) {
            $("#Nombre").val("");
            $("#Documento").val("");
            $("#Id").val(0);
        });

    $("#crearProveedorModal").on("show.bs.modal",
        function (e) {
            var button = $(e.relatedTarget);
            var name = button.data('nombre');

            $("#Id").val(button.data("id"));
            $("#Nombre").val(name);
            $("#Documento").val(button.data('documento'));
            $("#TipoPersonaId").val(button.data('tipoid'));

            if ($("#TipoPersonaId").val() === "" || $("#TipoPersonaId").val() === null || $("#TipoPersonaId").val() === 0) {
                $("#TipoPersonaId").val(1);
            }
        });
});

function getConceptoPagos() {
    $.get("https://unapec20181567.azurewebsites.net/api/Provedor", function (data) {
        //console.log(data[0].descripcion);
        //alert(data);
        $("#provedorList").empty();
        $("#provedorList").html(getTableBody(data));

    });

}

function createProveedor() {
    var id = $("#Id").val();
    var name = $("#Nombre").val();
    var tipoPersona = $("#TipoPersonaId").val();
    var documento = $("#Documento").val();
    //console.log(name);
    //console.log(id.length);
    if (id.length > 0) {
        $.ajax({
            type: 'PUT',
            url: "https://unapec20181567.azurewebsites.net/api/Provedor/",
            data: JSON.stringify({ id: id, nombre: name, activo: true, tipoPersonaId: tipoPersona, documento: documento }),
            contentType: "application/json",
            dataType: "json",
            statusCode: {
                200: function () {
                    console.log("OK");
                    swal("Exito", "Proveedor Modificado", "success");
                    $('#crearProveedorModal').modal('hide');
                    getConceptoPagos();

                },
                400: function () {
                    swal("Error", "Fallo al Modificar Proveedor", "error");

                }
            }
        });
    } else {
        $.ajax({
            type: 'POST',
            url: "https://unapec20181567.azurewebsites.net/api/Provedor/Crear",
            data: JSON.stringify({ nombre: name, activo: true, tipoPersonaId: tipoPersona, documento: documento }),
            contentType: "application/json",
            dataType: "json",
            statusCode: {
                200: function () {
                    console.log("OK");
                    swal("Exito", "Proveedor Creado", "success");
                    $('#crearProveedorModal').modal('hide');
                    getConceptoPagos();

                },
                400: function () {
                    swal("Error", "Fallo al Crear Proveedor", "error");

                }
            }
        });
    }

}

function getRows(item) {
    console.log(item);
    var row = "<tr><td>" + item.nombre + "</td><td>" + item.tipoPersonaName + "</td><td>" + item.documento + "</td><td>" + item.balance + "<td><button type='button' class='btn btn-primary' onclick='showDeleteProveedor(" + item.id + ")'" + getDataFields(item.id, item.descripcion) + ">Eliminar </button >" + getEditButton(item) + "</td>" + "</tr>";
    return row;
}

function getDataFields(id, text) {
    return " data-id='" + id + " data-name='" + text + "'  ";
}

function getEditButton(item) {
    if (item.id > 0) {
        return "<button type='button' id='editButton' class='btn btn-primary' data-toggle='modal' data-target='#crearProveedorModal' data-id='" + item.id + "' data-nombre='" + item.nombre + "' data-tipoId='" + item.tipoPersonaId + "' data-documento='"+ item.documento +"'>Editar</button>";
    }

    return "";
}

function getTableBody(itemList) {
    var body = "";
    itemList.forEach(e => body += getRows(e));
    return body;
}

function showDeleteProveedor(id) {
    if (id > 0) {
        swal("Desea Eliminar Proveedor?",
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
                    deleteProveedor(id);
                }
            });

    }
}

function deleteProveedor(id) {
    $.ajax({
        type: 'DELETE',
        url: "https://unapec20181567.azurewebsites.net/api/Provedor/" + id,
        contentType: "application/json",
        dataType: "json",
        statusCode: {
            200: function () {
                console.log("OK");
                swal("Exito", "Proveedor Eliminado", "success");
                $('#crearProveedorModal').modal('hide');
                getConceptoPagos();

            },
            400: function () {
                swal("Error", "Fallo al Eliminar Proveedor", "error");

            }
        }
    });
}

function editConcepto(id) {
    if (id > 0) {

    }
}

function getConcepto(id) {
    $.get("https://unapec20181567.azurewebsites.net/api/ConceptoPago/" + id, function (data) {
        //console.log(data[0].descripcion);
        //alert(data);

    });
}