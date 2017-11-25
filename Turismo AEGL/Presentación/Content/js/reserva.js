function deleteReserva(idr) {
    $.get("/Reserva/Cancelar/" + idr, null, function () {
        $("#tr_" + idr).remove();
    });
}
