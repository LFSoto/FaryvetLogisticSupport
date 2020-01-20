function DataTableAdd() {
    $(document).ready(function () {
        $('#datatable').DataTable({
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
            }
        });
    });
}

function DataTableRemove() {
    $(document).ready(function () {
        $('#datatable').DataTable().destroy();
    });
}

function fecha() {
    var fechaActual = new Date();
    var anio = fechaActual.getYear();
            if (anio < 1000) {
        anio += 1900
    }
    var dia = fechaActual.getDay();
    var mes = fechaActual.getMonth();
    var diam = fechaActual.getDate();
    var arrayDia = new Array("Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado");
    var arrayMes = new Array("Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Setiembre", "Octubre", "Noviembre", "Diciembre");

    var horaActual = new Date();
    var hora = horaActual.getHours();
    var minuto = horaActual.getMinutes();

            if (hora == 24) {
        hora = 0;
            } else if (hora > 12) {
        hora = hora - 0;
}
            if (hora < 10) {
        hora = "0" + hora;
}
            if (minuto < 10) {
        minuto = "0" + minuto;
}

var reloj = document.getElementById("reloj");
reloj.textContent = " " + arrayDia[dia] + " " + diam + " de " + arrayMes[mes] + " " + anio + " | " + hora + ":" + minuto;
reloj.innerText = " " + arrayDia[dia] + " " + diam + " de " + arrayMes[mes] + " " + anio + " | " + hora + ":" + minuto;

setTimeout("fecha()", 1000);
}

function alerta() {
    alert("Hola");
}