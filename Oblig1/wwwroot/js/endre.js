function valideringOgEndreKunde() {
    const reiseMalOK = valideringReiseMal();
    const fornavnOK = valideringFornavn($("#fornavn").val());
    const etternavnOK = valideringEtternavn($("#etternavn").val());
    const adresseOK = valideringAdresse($("#adresse").val());
    const postnrOK = valideringPostnr($("#postnr").val());
    const poststedOK = validerPoststed($("#poststed").val());
    const epostOK = valideringEpost($("#epost").val());
    const telfonnrOK = valideringTelfonnr($("#telfonnr").val());
    if (fornavnOK && etternavnOK && adresseOK && postnrOK && poststedOK && epostOK && telfonnrOK && reiseMalOK) {
        endreKunde();
    }
}

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
        $("#reiseMalFra").val(kunde.destinationFrom);
        $("#reiseMalTil").val(kunde.destinationTo);
        $("#antallAdult").val(kunde.antallAdult);
        $("#antallChild").val(kunde.antallChild);
        $("ticketType").val(kunde.ticketType);
        $("#avgang").val(kunde.departureDato);
        $("#retur").val(kunde.returnDato);
         $("#telfonnr").val(kunde.telfonnr);
        $("#epost").val(kunde.epost);

        console.log(kunde)

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

        if (getTicketType() === 'En vei') {
            console.log("envie")
            hideReturDatoInput()
        }

        const avgangInput = document.getElementById("avgang");
        const returInput = document.getElementById("retur");
    
        setDefaultDato(avgangInput);
        setDefaultDato(returInput);
    
        const currentDate = getCurrentDateString();
        deaktivereTidligereDatoer(avgangInput, currentDate);
        deaktivereTidligereDatoer(returInput, currentDate);

    }); 
});

function endreKunde() {
        let returDate;
    const ticketType = getTicketType();
    if (ticketType === 'En vei') {
        returDate = $("#retur").val(" ");
    } else {
        returDate = $("#retur").val();
    }

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
        destinationFrom: $("#reiseMalFra").val(),
        destinationTo: $("#reiseMalTil").val(),
        antallAdult: $("#antallAdult").val(),
        antallChild: $("#antallChild").val(),
        ticketType: getTicketType(),
        departureDato: $("#avgang").val(),
        returnDato: $("#retur").val(),
        ticketClass: getKlassetType(),
        telfonnr: $("#telfonnr").val(),
        epost: $("#epost").val()
    };

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
    console.log(type + "sdfsdf")
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

function onAvgangChange() {
    if (getTicketType() === 'Retur') {
        const avgangInput = document.getElementById("avgang")
        const returInput = document.getElementById("retur")
        returInput.value = avgangInput.value
        deaktivereTidligereDatoer(returInput, avgangInput.value)
    }
}

function onTicketTypeChange() {
    const ticketType = getTicketType();
    if (ticketType === 'En vei') {
        hideReturDatoInput()
    } else {
        showReturDatoInput();
        const avgangInput = document.getElementById("avgang")
        const returInput = document.getElementById("retur")
        returInput.value = avgangInput.value
        deaktivereTidligereDatoer(returInput, avgangInput.value)
    }
}

function setDefaultDato(datoInput) {
    const currentDate = getCurrentDateString();
    datoInput.value = currentDate;
}

function getCurrentDateString() {
    const currentDate = new Date();
    const month = parseInt(currentDate.getMonth()) + 1;
    const date = currentDate.getFullYear() + "-" + month.toString().padStart(2, '0') + "-" + currentDate.getDate().toString().padStart(2, '0');
    return date;
}

function deaktivereTidligereDatoer(datoInput, date) {
    datoInput.setAttribute('min', date)
}

function hideReturDatoInput() {
    const returInput = document.getElementById("retur");
    const returLabel = document.getElementById("returLabel")
    returInput.style.display = "none";
    returLabel.style.display = "none";
}

function showReturDatoInput() {
    const returInput = document.getElementById("retur");
    const returLabel = document.getElementById("returLabel")
    returInput.style.display = "initial";
    returLabel.style.display = "initial";
}