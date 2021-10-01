$(function(){
    hentAlleKunder();
});


function hentAlleKunder() {
    
    $.get("kunde/hentAlle", function (kunderArray) {
        let kunderList;
        let billetterList;
        if (kunderArray) {
            kunderList = kunderArray;
            $.get("kunde/hentAlleBilletter", function (billetterArray) {
                if (billetterArray) {
                    billetterList = billetterArray;
                }
                formaterKunder(kunderList, billetterList);
            });
        }
    });
}

function formaterKunder(kunder, billetter) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Fornavn</th><th>Etternavn</th><th>Telfonnr</th><th>Epost</th><th>Adresse</th><th>Postnr</th><th>Poststed</th><th>Fra</th><th>Til</th><th>Billettypet</th><th>Klasset</th><th>Voksen</th><th>Barn</th><th>Avgang Dato</th><th>Retur Dato</th><th></th><th></th>" +
        "</tr>";
    for (let kunde of kunder) {
        for (let billett of billetter) {
           if (billett.kundeId === kunde.id) {
                if (billett.returnDato === null) {
                    billett.returnDato = " ";
                }
                ut += "<tr>" +
                    "<td>" + kunde.fornavn + "</td>" +
                    "<td>" + kunde.etternavn + "</td>" +
                    "<td>" + kunde.telfonnr + "</td>" +
                    "<td>" + kunde.epost + "</td>" +
                    "<td>" + kunde.adresse + "</td>" +
                    "<td>" + kunde.postnr + "</td>" +
                    "<td>" + kunde.poststed + "</td>" +
                    "<td>" + billett.destinationFrom + "</td>" +
                    "<td>" + billett.destinationTo + "</td>" +
                    "<td>" + billett.ticketType + "</td>" +
                    "<td>" + billett.ticketClass + "</td>" +
                    "<td>" + billett.antallAdult + "</td>" +
                    "<td>" + billett.antallChild + "</td>" +
                    "<td>" + billett.departureDato + "</td>" +
                    "<td>" + billett.returnDato + "</td>" +
                    "<td> <a class='btn btn-primary' href='endre.html?id=" + kunde.id + "'>Endre</a></td>" +
                    "<td> <button class='btn btn-danger' onclick='slettBillett(" + kunde.id + ")'>Slett</button></td>" +
                    "</tr>";
                }
            }
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
    const slettConfirm = confirm("Er du sikker på å slette alle biletter");
    if (slettConfirm) {
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
}


