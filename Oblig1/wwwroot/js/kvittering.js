$(function(){
        const kundeId = window.location.search.substring(1);

        //hent kunde
        hentKunde(kundeId)
        hentBillett(kundeId)
})

function hentKunde(kundeId) {
    const url = "Kunde/HentEn?" + kundeId;
    $.get(url, function(kunde) {
        console.log(kunde)
        const navn = document.getElementById("navn")
        const telefonnr = document.getElementById("telefonnr")
        const adress = document.getElementById("adress")
        const bilettId = document.getElementById("bilettId")
        const currentDate = document.getElementById("currentDate")

        navn.textContent = " " + kunde.fornavn + " " + kunde.etternavn;
        telefonnr.textContent = " " + kunde.telfonnr;
        adress.textContent = " " + kunde.adresse;
        currentDate.textContent = " " +  getCurrentDateString();
    })
}

function hentBillett(kundeId) {
    const id = window.location.search.substring(1).split("=")[1];
    
    const url = "Kunde/HentEnBillett?kundeId=" + id;
    $.get(url, function(billett) {
        console.log(billett)
        const billettId = document.getElementById("billettId")
        const fra = document.getElementById("fra")
        const til = document.getElementById("til")
        const datoFra = document.getElementById("datoFra")
        const datoTil = document.getElementById("datoTil")
        const antallVoksen = document.getElementById("antallVoksen")
        const antallBarn = document.getElementById("antallBarn")
        const billettType = document.getElementById("billettType")
        const billettKlasse = document.getElementById("billettKlasse")

        billettId.textContent = " " + billett.id;
        fra.textContent = " " + billett.destinationFrom;
        til.textContent = " " + billett.destinationTo;
        datoFra.textContent = " " + billett.departureDato;
        if (!billett.returnDato) {
            datoTil.textContent = " ";
        }else {
            datoTil.textContent = " " + billett.returnDato;
        }
        antallVoksen.textContent = " " + billett.antallAdult;
        antallBarn.textContent = " " + billett.antallChild;
        billettType.textContent = " " + billett.ticketType;
        billettKlasse.textContent = " " + billett.ticketClass;
    })
}

function getCurrentDateString() {
    const currentDate = new Date();
    const month = parseInt(currentDate.getMonth()) + 1;
    const date = currentDate.getFullYear() + "-" + month.toString().padStart(2, '0')  + "-" + currentDate.getDate().toString().padStart(2, '0');
    return date;
}