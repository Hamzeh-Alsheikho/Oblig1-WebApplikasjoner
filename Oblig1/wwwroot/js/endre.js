

$(function () {
    // hent kunden med kunde-id fra url og vis denne i skjemaet. 
    

    const id = window.location.search.substring(1);
    const url = "Kunde/HentEn?" + id;
    $.get(url, function (kunde) {
        $("#fornavn").val(kunde.fornavn);
        $("#etternavn").val(kunde.etternavn);
        $("#adresse").val(kunde.adresse);
        $("#postnr").val(kunde.postnr);
         $("#poststed").val(kunde.poststed);
        $("#reiseMal").val(kunde.destination);
        $("#antallAdult").val(kunde.antallAdult);
        $("#antallChild").val(kunde.antallChild);
        $("ticketType").val(kunde.ticketType);
        $("#avgang").val(kunde.departureDato);
        $("#retur").val(kunde.returnDato);
         $("#telefonner").val(kunde.telfonnr);
        $("#epost").val(kunde.epost);

        //Donni is here
        if (kunde.ticketType === 'En vei') {
            const singleInput = document.getElementById("single");
            singleInput.setAttribute("checked", "true");
        } else {
            const returInput = document.getElementById("turRetur");
            returInput.setAttribute("checked", "true")
        }

        if (kunde.ticketClass === "Economy") {
            const economyInput = document.getElementById("economy");
            economyInput.setAttribute("checked", "true")
        } else if (kunde.ticketClass === "Business") {
            const businessInput = document.getElementById("business");
            businessInput.setAttribute("checked", "true")
        } else {
            const firstClassInput = document.getElementById("first_Class");
            firstClassInput.setAttribute("checked", "true")
        }

    });
});

function endreKunde() {
    const idString = window.location.search.substring(1);
    const idStringArr = idString.split("=");
    const id = idStringArr[1]
    const kunde = {
        //id: $("#id").val(), // må ha med denne som ikke har blitt endret for å vite hvilken kunde som skal endres
        id: id,
        fornavn: $("#fornavn").val(),
        etternavn: $("#etternavn").val(),
        adresse: $("#adresse").val(),
        postnr: ($("#postnr").val()),
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
    console.log(kunde)
    $.post("Kunde/endre", kunde, function (OK) {
        if (OK) {
            window.location.href = 'index.html';
        }
        else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }
    });
}

function getTicketType() {
    const singleInput = document.getElementById("single");
    const turReturInput = document.getElementById("turRetur");

    const ticketArray = [singleInput, turReturInput];
    let type;
    
    for (let ticketType of ticketArray) {
        if (ticketType.checked) {
            type = ticketType.value
	    }
    }
    return type;
}

function getKlassetType() {
    const econonyInput = document.getElementById("economy");
    const fristClassInput = document.getElementById("first_Class");
    const businessInput = document.getElementById("business");

    const klassetArray = [econonyInput, fristClassInput, businessInput];

    let type;
    for (let klassetType of klassetArray) {
        if (klassetType.checked) {
            type = klassetType.value
        }
    }
    return type;
}

