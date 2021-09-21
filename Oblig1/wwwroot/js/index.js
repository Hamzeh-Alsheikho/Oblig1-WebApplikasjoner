$(function(){
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
        "<th>Fornavn</th><th>Etternavn</th><th>Telfonnr</th><th>Epost</th><th>Adresse</th><th>Postnr</th><th>Poststed</th><th>Fra</th><th>Til</th><th>Billettypet</th><th>Klasset</th><th>Voksen</th><th>Barn</th><th>Avgang Dato</th><th>Retur Dato</th><th></th><th></th>" +
        "</tr>";
    for (let kunde of kunder) {
        if (kunde.returnDato === null) {
            kunde.returnDato = " ";
        }
        ut += "<tr>" +
            "<td>" + kunde.fornavn + "</td>" +
            "<td>" + kunde.etternavn + "</td>" +
            "<td>" + kunde.telfonnr + "</td>" +
            "<td>" + kunde.epost + "</td>" +
            "<td>" + kunde.adresse + "</td>" +
            "<td>" + kunde.postnr + "</td>" +
            "<td>" + kunde.poststed + "</td>"+
            "<td>" + kunde.destinationFrom + "</td>"+
            "<td>" + kunde.destinationTo + "</td>"+
            "<td>" + kunde.ticketType + "</td>"+
            "<td>" + kunde.ticketClass + "</td>"+
            "<td>" + kunde.antallAdult + "</td>"+
            "<td>" + kunde.antallChild + "</td>"+
            "<td>" + kunde.departureDato + "</td>"+
            "<td>" + kunde.returnDato + "</td>"+
            "<td> <a class='btn btn-primary' href='endre.html?id=" + kunde.id + "'>Endre</a></td>" +
            "<td> <button class='btn btn-danger' onclick='slettBillett(" + kunde.id + ")'>Slett</button></td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#kundene").html(ut);
}
function slettBillett(id) {
    const url = "Kunde/Slett?id=" + id;
    $.get(url, function (ok) {
        if (ok) {
            window.location.href = 'index.html';
        }
        else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }
    });
}


function nullstille() {
    const url = "Kunde/SlettAlle"
    $.get(url, function (ok) {
        if (ok) {
            window.location.href = 'index.html';
        }
        else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }
    });
}