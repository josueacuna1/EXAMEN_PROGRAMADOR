 //---------- Realiza algunas validaciones en el formulario de modificación ----------\\
function validar(data){
    if(data.id_cliente !== "" && data.nombre !=="" && data.apellido_materno !== "" && data.apellido_paterno !== "" && data.rfc !== "" && data.curp !=="" &&  data.fecha_alta !==""){
      if((data.rfc).length >= 12 && (data.rfc).length <=13){
        if((data.curp).length ===18){
          GuardarCambios(data)
        }else{
          alert("Curp no valido, escribio: " + (data.curp).length + " dígitos. \n\nEl curp se compone de 18 dígitos.");
        }
      }else{
        alert("El RFC debe es de 12 dígitos si es persona moral o 13 dígitos si es persona física. \n\nEscribiste: "+ (data.rfc).length + " dígitos.");
      }
    }
    else{
      alert("Todos los campos son obligatorios.");
    }    
  }
 //---------- Llama a la API y obtiene la información de todos los clientes dados de alta en el sistema ----------\\
  function Obtener() {
    $(".table tbody").html("");
    $.get("http://localhost:58683/api/Cliente").done(function (response) {
      //---------- Obtiene todos los datos y los va almacenando en una tabla en <tr>´s y posteriormente los agrega a la tabla. ----------\\
      $.each(response, function (id, fila) {
        $("<tr>")
          .append(
            $("<td>").text(fila.id_cliente),
            $("<td>").text(fila.nombre),
            $("<td>").text(fila.apellido_materno),
            $("<td>").text(fila.apellido_paterno),
            $("<td>").text(fila.rfc),
            $("<td>").text(fila.curp),
            $("<td>").text(fila.fecha_alta),
            $("<td>").append($("<button>").data("id", fila.id_cliente).addClass(
              "btn btn-success btn-sm mr-1 Consultar").text("Consultar").attr({
              type: "button",
            })),
            $("<td>").append($("<button>").data("id", fila.id_cliente).addClass(
              "btn btn-warning btn-sm mr-1 Editar").text("Editar").attr({
              type: "button",
            })),
            $("<td>").append($("<button>").data("id", fila.id_cliente).data("nombre", fila.nombre).addClass(
              "btn btn-danger btn-sm mr-1 Eliminar").text("Eliminar").attr({
              type: "button",
            })))
          .appendTo(".table");
      });
    });
  }
  //--- Llama a la API y obtiene la información de un cliente, y posterior a ello, lo agrega como valores en los inputs del formulario de actualizar ---\\
  function agregarInfo(id_Cli) {
    $.get("http://localhost:58683/api/Cliente")
      .done(function (response) {
        $.each(response, function (id, fila) {
          if (fila.id_cliente === id_Cli) {
            $("#id_clie").val(fila.id_cliente),
              $("#nombre_clie").val(fila.nombre),
              $("#apellidoP_clie").val(fila.apellido_materno),
              $("#apellidoM_clie").val(fila.apellido_paterno),
              $("#rfc_clie").val(fila.rfc),
              $("#curp_clie").val(fila.curp),
              $("#fechaA_clie").val(fila.fecha_alta)
          }
        });
      });
  }
//---------- Función para guardar los cambios del cliente ----------\\
function validarDatos(){
  let data = {
    id_cliente: $("#id_clie").val(),
    nombre: $("#nombre_clie").val(),
    apellido_materno: $("#apellidoP_clie").val(),
    apellido_paterno: $("#apellidoM_clie").val(),
    rfc: $("#rfc_clie").val(),
    curp: $("#curp_clie").val(),
    fecha_alta: $("#fechaA_clie").val()
  }   
  let x = JSON.stringify(data);
  //--- Manda a validar los datos ---\\
  validar(data);
  
}
//---------- Función que permite guardar los datos ya validados por medio de una peticion ajax a la API ----------\\
  function GuardarCambios(data) {
    $.ajax({
        method: "PUT",
        url: "http://localhost:58683/api/Cliente?id_cliente=" + data.id_cliente,
        contentType: 'application/json',
        data: JSON.stringify(data),
      })
      .done(function (response) {
        console.log(response);
        if (response) {
          window.location = "index.html?ed=1";
        } else {
          alert("Error al Modificar")
        }
      });
  }

  