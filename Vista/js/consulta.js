//---------- Función para regresar a la página principal ----------\\
$(document).on("click", "#regresar", function () {
window.location = "index.html";
});
//---------- Función para capturar el ID del cliente que viene del url para obtener su información ----------\\
$.urlId = function(name){
    let results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
    if (results==null) {
      window.location = "index.html";
    }
    return decodeURI(results[1]) || 0;
}
/*---------- Función que oculta la alerta de información no encontrada, captura el ID del cliente que fue encontrado en 
                la función anterior y llama a una función para consultar las cuentas ligadas a el ID ----------*/
window.onload = function() {
$(".alerta").css("visibility", "hidden");
let id_cliente = $.urlId('id_cliente');
Obtener_info(id_cliente);
};

//---------- Función que busca la información por el ID del cliente ----------\\
function Obtener_info(id_cliente) {
    $(".table tbody").html("");
    //---------- Llama al controlador de la API parar que devuelva la información solicitada  ----------\\
    $.get("http://localhost:58683/api/Cliente?id_cliente="+id_cliente).done(function (response) {
    console.log(response);
    //---------- Si no se encontró ningún dato, agrega la alerta y la muestra y oculta el demas contenido ----------\\
    if(response.length === 0){
        $("#contenido").css("visibility", "hidden");
        let div ="<div class='alert alert-danger alerta' role='alert'>"
            +"El cliente que selecciono no tienen ninguna cuenta activa en este momento."
        +"</div>"
        document.getElementById("alerta").innerHTML = div;
     //---------- Si encuentra información, lo va almacenando en la tabla y en variables para ser utilizado. ----------\\
    }else{

        $.each(response, function (id, fila) {
        $("<tr>")
        .append(
          $("<td>").text(fila.id_cliente_cuenta),
          $("<td>").text(fila.id_cuenta),
          $("<td>").text(fila.nombre_cuenta),
          $("<td>").text(fila.saldo_actual + " $"),
          $("<td>").text(fila.fecha_contratacion),
          $("<td>").text(fila.fecha_ultimo_movimento))
        .appendTo(".table");
    });

    $.each(response, function (id, fila) {
        let nombre_cliente = fila.nombre;
        let id_cliente = fila.id_cliente;
        let apellido_paterno =fila.apellido_paterno;
        let apellido_materno = fila.apellido_materno;
        document.getElementById("nombre_cliente").innerHTML = nombre_cliente;
        document.getElementById("id_cliente").innerHTML = id_cliente;
        document.getElementById("apellido_paterno").innerHTML = apellido_paterno;
        document.getElementById("apellido_materno").innerHTML = apellido_materno;
    });

    }
  });
}


