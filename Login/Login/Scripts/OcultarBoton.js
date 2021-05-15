//seccion leer mas

let i = 0;

let button = document.querySelector('#boton').addEventListener('click', function () {
    if (!i) {
    /* document.getElementById('leerMas').style.display = 'inline';*/
        document.getElementById('leerMas').style.display = '';
        document.getElementById('boton').innerHTML = 'Leer Menos';
        i = 1;
    }
    else {
        document.getElementById('leerMas').style.display = 'none';
        document.getElementById('boton').innerHTML = 'Información del Gráfico';
        i = 0;
    }


})