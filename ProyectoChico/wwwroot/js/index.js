$(document).ready(function(){
var hola = 0;



var button = $("#boton");
button.on("click", function () {
    console.log("Presionaste el boton");
});

var form = $("#theForm");
form.hide();

var productoInfo = $(".productos li");
productoInfo.on("click", function () {

    console.log("Clickeaste en :" + $(this).text());
});

var loginTitulo = $("#tituloLogin");
var formulario = $(".popup");

    loginTitulo.on("click", function () {

        formulario.fadeToggle(2000);
    })
});
