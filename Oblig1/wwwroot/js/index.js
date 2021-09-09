﻿$(function(){
    hentAlleKunder();
});

function hentAlleKunder() {
    $.get("kunde/hentAlle", function (kunder) {
        formaterKunder(kunder);
    });
}

function formaterKunder(kunder) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Fornavn</th><th>Etternavn</th><th>Telfonnr</th><th>Epost</th><th>Adresse</th><th>Postnr</th><th>Poststed</th><th>Reisemålet</th><th>Billettypet</th><th>Klasset</th><th>Voksen</th><th>Barn</th><th>Avgang Dato</th><th>Retur Dato</th><th></th>" +
        "</tr>";
    for (let kunde of kunder) {
        ut += "<tr>" +
            "<td>" + kunde.fornavn + "</td>" +
            "<td>" + kunde.etternavn + "</td>" +
            "<td>" + kunde.telfonnr + "</td>" +
            "<td>" + kunde.epost + "</td>" +
            "<td>" + kunde.adresse + "</td>" +
            "<td>" + kunde.postnr + "</td>" +
            "<td>" + kunde.poststed + "</td>"+
            "<td>" + kunde.destination + "</td>"+
            "<td>" + kunde.ticketType + "</td>"+
            "<td>" + kunde.ticketClass + "</td>"+
            "<td>" + kunde.antallAdult + "</td>"+
            "<td>" + kunde.antallChild + "</td>"+
            "<td>" + kunde.departureDato + "</td>"+
            "<td>" + kunde.returnDato + "</td>"+
            "<td> <a class='btn btn-primary' href='endre.html?id=" + kunde.id + "'>Endre</a></td>" +
            "<td> <button class='btn btn-danger' onclick='slettKunde(" + kunde.id + ")'>Slett</button></td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#kundene").html(ut);
}