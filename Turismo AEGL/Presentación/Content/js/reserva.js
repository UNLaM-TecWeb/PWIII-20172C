function deleteReserva(idr) {
    $.get("/Reserva/Cancelar/" + idr, null, function () {
        location.reload();
    });
}