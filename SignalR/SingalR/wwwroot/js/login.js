"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/login").build();


document.getElementById("accion").disabled = true;


connection.on("Redirect", function () {
    window.location.href = "/Logeado"; 
});


connection.start().then(function () {
    document.getElementById("accion").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("accion").addEventListener("click", function (event) {

    connection.invoke("Redireccionar").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});