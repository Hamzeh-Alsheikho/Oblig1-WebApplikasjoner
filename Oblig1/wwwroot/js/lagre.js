﻿let kunde = {}
let billett = {}

function valideringOgLagreKunde() {
    const reiseMalOK = valideringReiseMal();
    const antallVoksenOK = valideringAntallVoksen($("#antallAdult").val());
    const antallBarnOK = valideringAntallBarn($("#antallChild").val());
    const fornavnOK = valideringFornavn($("#fornavn").val());
    const etternavnOK = valideringEtternavn($("#etternavn").val());
    const adresseOK = valideringAdresse($("#adresse").val());
    const postnrOK = valideringPostnr($("#postnr").val());
    const poststedOK = validerPoststed($("#poststed").val());
    const epostOK = valideringEpost($("#epost").val());
    const telfonnrOK = valideringTelfonnr($("#telfonnr").val());
    if (fornavnOK && etternavnOK && adresseOK && postnrOK && poststedOK && epostOK && telfonnrOK && reiseMalOK
        && antallVoksenOK && antallBarnOK) {
        showKredittForm()
    }
}

function valideringOgLagreKredittInfo() {
    const kortnummerOK = valideringKortnummer($("#kortnummer").val());
    const kortholdersNavnrOK = valideringkortholdersNavn($("#kortholdersNavn").val());
    const utlopsdatoOK = valideringUtlopsDato();
    const cardVerificationCodeOK = valideringCardVerificationCode($("#cardVerificationCode").val());
    if (kortnummerOK && kortholdersNavnrOK && utlopsdatoOK && cardVerificationCodeOK) {
        lagreKunde()
    }
 }

function showKredittForm() {
    const ticketType = getTicketType();
    if (ticketType === 'En vei') {
        returDate = $("#retur").val(" ");
    } else {
        returDate = $("#retur").val();
    }
    kunde = {
        fornavn: $("#fornavn").val(),
        etternavn: $("#etternavn").val(),
        adresse: $("#adresse").val(),
        telfonnr: $("#telfonnr").val(),
        epost: $("#epost").val(),
        postnr: $("#postnr").val(),
        poststed: $("#poststed").val(),
    }
    //$("#myselect option:selected").text();
    billett = {
        destinationFrom: $("#reiseMalFra option:selected").text(),
        destinationTo: $("#reiseMalTil option:selected").text(),
        antallAdult: $("#antallAdult").val(),
        antallChild: $("#antallChild").val(),
        ticketType: getTicketType(),
        departureDato: $("#avgang").val(),
        returnDato: $("#retur").val(),
        ticketClass: getKlassetType(),
    }

    const kjopBillettForm = document.getElementById("kjopBillettForm");
    const kredittForm = document.getElementById("kredittForm");
    kjopBillettForm.classList.add("hidden")
    kredittForm.classList.remove("hidden")
}

function hideKredittForm() {
    const kjopBillettForm = document.getElementById("kjopBillettForm");
    const kredittForm = document.getElementById("kredittForm");
    kjopBillettForm.classList.remove("hidden")
    kredittForm.classList.add("hidden")
}

function lagreKunde() {
    const url = "Kunde/Lagre";
    $.post(url, kunde, function (kundeId) {
        if (kundeId) {
            lagreBillett(kundeId)
        }
        else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }
    });
}

function lagreKredittInfo(kundeId) {
    const arInput = document.getElementById("utlopsdatoAr").value;
    const manedInput = document.getElementById("utlopsdatoManed").value;
    const utlopsDato = manedInput + "/" + arInput;

    let kredittInfo = {
        kortnummer: $("#kortnummer").val(),
        kundeId: kundeId,
        kortHolderNavn: $("#kortholdersNavn").val(),
        kortUtlopsdato: utlopsDato,
        cvc: $("#cardVerificationCode").val(), 
    }
    const url = "Kunde/LagreKreditt";
    $.post(url, kredittInfo, function (OK) {
        if (OK) {
            window.location.href = 'kvittering.html?id=' + kundeId;
        }
        else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }
    });
}

function lagreBillett(kundeId) {
    const url = "Kunde/LagreBillett";
    billett.kundeId = kundeId;
    $.post(url, billett, function (OK) {
        if (OK) {
            lagreKredittInfo(kundeId);
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

$(function() {

    hentAlleDestinasjoner();

    if (getTicketType() === 'En vei') {
        hideReturDatoInput()
    }
    const avgangInput = document.getElementById("avgang");
    const returInput = document.getElementById("retur");

  
    setDefaultDato(avgangInput);
    setDefaultDato(returInput);
  
    const currentDate = getCurrentDateString();
    deaktivereTidligereDatoer(avgangInput, currentDate);
    deaktivereTidligereDatoer(returInput, currentDate);
})

function hentAlleDestinasjoner() {
    const url = "Kunde/HentAlleDestinasjon";
    $.get(url, function (destinasjoner) {
        const reiseMalFraInput = document.getElementById("reiseMalFra"); 
        leggDestinasjonerTilDropDown(destinasjoner, reiseMalFraInput, "Fra");
    });
}

function leggDestinasjonerTilDropDown(destinasjoner, input, type) {
    removeAll(input, type)
    for (let destinasjon of destinasjoner) {
        let optionElement = document.createElement("option");
        optionElement.setAttribute("value", destinasjon.id);
        optionElement.textContent = destinasjon.sted; 
        input.appendChild(optionElement); 
    }
}

function removeAll(selectBox, destinationType) {
    let index = 0;
    if (destinationType === "Fra") {
        index = 1
    }
    while (selectBox.options.length > index) {
        selectBox.remove(index);
    }
}

function hentGyldigDestinasjoner(id) {
    const url = "Kunde/HentGyldigDestinasjoner?destinasjonId=" + id;
    $.get(url, function (destinasjoner) {
        const reiseTilInput = document.getElementById("reiseMalTil");
        leggDestinasjonerTilDropDown(destinasjoner, reiseTilInput, "Til")
    })
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
    const date = currentDate.getFullYear() + "-" + month.toString().padStart(2, '0')  + "-" + currentDate.getDate().toString().padStart(2, '0');
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