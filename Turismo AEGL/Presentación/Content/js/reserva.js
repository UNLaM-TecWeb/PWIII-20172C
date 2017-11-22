function deleteReserva(idr) {
    $.ajax({
        type: "GET",
        url: "/Reserva/Cancelar/" + idr,
        success: function (response) {
            location.reload();
        }
    });
}