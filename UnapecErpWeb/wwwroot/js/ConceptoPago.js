$(document).ready(function () {
    getConceptoPagos();

    $("#crearConceptoModal").on("hidden.bs.modal",
        function (e) {
            $("#Descripcion").val("");
            var button = $(e.relatedTarget);
            button.data('descripcion').text = "";
            button.data('id').text = "";
            $("#Id").val(0);


        });

    $("#crearConceptoModal").on("show.bs.modal",
        function (e) {
            var button = $(e.relatedTarget);
            console.log(button);// Button that triggered the modal
            var name = button.data('name');// Extract info from data-* attributes
            // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
            // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
            var modal = $(this);
            console.log(name);
            console.log(button.data("id"));
            $("#Id").val(button.data("id"));
            console.log($("#Id").val() + "------------------->>>");
            $("#Descripcion").val(name);

        });
});

function getConceptoPagos() {
    $.get("https://unapec20181567.azurewebsites.net/api/ConceptoPago", function (data) {
        //console.log(data[0].descripcion);
        //alert(data);
        $("#conceptosList").empty();
        $("#conceptosList").html(getTableBody(data));

    });

}

function createConceptoPago() {
    var descripcion = $("#Descripcion").val();

    var id = $("#Id").val();
    var name = $("#Descripcion").val();
    console.log($("#Id").val() + "     -     dhsssssssssssdddddddddddddddddddddddddddddddddddddddd");
    //console.log(name);
    //console.log(id.length);
    if (id.length > 0) {
        $.ajax({
            type: 'PUT',
            url: "https://unapec20181567.azurewebsites.net/api/ConceptoPago/",
            data: JSON.stringify({ id: id, descripcion: name, activo:true}),
            contentType: "application/json",
            dataType: "json",
            statusCode: {
                200: function () {
                    console.log("OK");
                    swal("Exito", "Concepto Modificado", "success");
                    $('#crearConceptoModal').modal('hide');
                    getConceptoPagos();

                },
                400: function () {
                    swal("Error", "Fallo al Modificar Concepto", "error");

                }
            }
        });
    } else {
        $.ajax({
            type: 'POST',
            url: "https://unapec20181567.azurewebsites.net/api/ConceptoPago/Crear",
            data: JSON.stringify(descripcion),
            contentType: "application/json",
            dataType: "json",
            statusCode: {
                200: function () {
                    console.log("OK");
                    swal("Exito", "Concepto Creado", "success");
                    $('#crearConceptoModal').modal('hide');
                    getConceptoPagos();

                },
                400: function () {
                    swal("Error", "Fallo al Crear Concepto", "error");

                }
            }
        });
    }

}

function getRows(item) {
    //console.log(item);
    var row = "<tr><td>" + item.descripcion + "</td><td><button type='button' class='btn btn-primary' onclick='showDeleteConcepto(" + item.id + ")'" + getDataFields(item.id, item.descripcion) + ">Eliminar </button >" + getEditButton(item.id, item.descripcion) + "</td>" + "</tr>";
    return row;
}

function getDataFields(id, text) {
    return " data-id='" + id + " data-name='" + text + "'  ";
}

function getEditButton(id, description) {
    if (id > 0) {
        return "<button type='button' id='editButton' class='btn btn-primary' data-toggle='modal' data-target='#crearConceptoModal' data-id='" + id + "' data-name='" + description + "'>Editar</button>";
    }

    return "";
}

function getTableBody(itemList) {
    var body = "";
    itemList.forEach(e => body += getRows(e));
    return body;
}

function showDeleteConcepto(id) {
    if (id > 0) {
        swal("Desea Eliminar Concepto de Pago?",
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
                    deleteConcepto(id);
                }
            });

    }
}

function deleteConcepto(id) {
    $.ajax({
        type: 'DELETE',
        url: "https://unapec20181567.azurewebsites.net/api/ConceptoPago/" + id,
        contentType: "application/json",
        dataType: "json",
        statusCode: {
            200: function () {
                console.log("OK");
                swal("Exito", "Concepto Eliminado", "success");
                $('#crearConceptoModal').modal('hide');
                getConceptoPagos();

            },
            400: function () {
                swal("Error", "Fallo al Eliminar Concepto", "error");

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
        console.log(data);

    });
}