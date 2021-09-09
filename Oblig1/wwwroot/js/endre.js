

$(function () {
    // hent kunden med kunde-id fra url og vis denne i skjemaet. 
    //Changing format from database to html
    function formatDate(dateString) {
        const dateArr = dateString.split(".");
        const formattedDate = dateArr[2] + "-" + dateArr[1] + "-" + dateArr[0]
        return formattedDate;
    }

    const id = window.location.search.substring(1);
    const url = "Kunde/HentEn?" + id;
    $.get(url, function (kunde) {
        const departureDate = formatDate(kunde.departureDato);
        const returnDato = formatDate(kunde.returnDato)
        $("#fornavn").val(kunde.fornavn);
        $("#etternavn").val(kunde.etternavn);
        $("#adresse").val(kunde.adresse);
        $("#postnr").val(kunde.postnr);
         $("#poststed").val(kunde.poststed);
        $("#reiseMal").val(kunde.destination);
        $("#antallAdult").val(kunde.antallAdult);
        $("#antallChild").val(kunde.antallChild);
        $("ticketType").val(kunde.ticketType);
        $("#avgang").val(departureDate);
         $("#retur").val(returnDato);
         $("#telefonner").val(kunde.telfonnr);
        $("#epost").val(kunde.epost);
    });
});

function endreKunde() {
    const kunde = {
        id: $("#id").val(), // må ha med denne som ikke har blitt endret for å vite hvilken kunde som skal endres
        fornavn: $("#fornavn").val(),
        etternavn: $("#etternavn").val(),
        adresse: $("#adresse").val(),
        postnr: $("#postnr").val(),
        poststed: $("#poststed").val(),
        destination: $("#reiseMal").val(),
        antallAdult: $("#antallAdult").val(),
        antallChild: $("#antallChild").val(),
        ticketType: getTicketType(),
        departureDato: $("#avgang").val(),
        returnDato: $("#retur").val(),
        ticketClass: getKlassetType(),
        telfonnr: $("#telefonner").val(),
        epost: $("#epost").val()
    };
    $.post("Kunde/Endre", kunde, function (OK) {
        if (OK) {
            window.location.href = 'index.html';
        }
        else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }
    });
}

