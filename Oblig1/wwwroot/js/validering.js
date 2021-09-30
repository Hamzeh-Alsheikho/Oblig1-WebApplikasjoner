function makeBorderRed(input) {
    input.style.border = "1px solid red";
}
function makeBorderInitial(input) {
    input.style.border = "1px solid lightgray";
}

function valideringReiseMal() {
    const fra = $("#reiseMalFra").val();
    const til = $("#reiseMalTil").val();
    if (fra === til) {
        $("#reisemalVelgFeil").html("Velg riktig reisemål");
        makeBorderRed(document.getElementById("reiseMalFra"));
        makeBorderRed(document.getElementById("reiseMalTil"));
        return false
    } else {
        $("#reisemalVelgFeil").html("");
        makeBorderInitial(document.getElementById("reiseMalFra"));
        makeBorderInitial(document.getElementById("reiseMalTil"));
        return true;
    }
}

function valideringAntallVoksen(antallAdult) {
    if (antallAdult <1) {
        $("#antallAdultFeil").html("Antall voksne må være minst 1");
        makeBorderRed(document.getElementById("antallAdult"));
        return false;
    }
    else {
        $("#antallAdultFeil").html("");
        makeBorderInitial(document.getElementById("antallAdult"));
        return true;
    }
}
function valideringAntallBarn(antallChild) {
    if (antallChild < 0) {
        $("#antallChildFeil").html("Antall barn må være minst 0");
        makeBorderRed(document.getElementById("antallChild"));
        return false;
    }
    else {
        $("#antallChildFeil").html("");
        makeBorderInitial(document.getElementById("antallChild"));
        return true;
    }
}
function valideringFornavn(fornavn) {
    const regexp = /^[a-zA-ZæøåÆØÅ\.\ \-]{2,20}$/;
    const ok = regexp.test(fornavn);
    if (!ok) {
        $("#forNavnFeil").html("Fornavnet må bestå av 2 til 20 bokstaver");
        makeBorderRed(document.getElementById("fornavn"));
        return false;
    }
    else {
        $("#forNavnFeil").html("");
        makeBorderInitial(document.getElementById("fornavn"));
        return true;
    }
}
function valideringEtternavn(etternavn) {
    const regexp = /^[a-zA-ZæøåÆØÅ\.\ \-]{2,20}$/;
    const ok = regexp.test(etternavn);
    if (!ok) {
        $("#etterNavnfeil").html("Etternavnet må bestå av 2 til 20 bokstaver");
        makeBorderRed(document.getElementById("etternavn"));
        return false;
    }
    else {
        $("#etterNavnfeil").html("");
        makeBorderInitial(document.getElementById("etternavn"));
        return true;
    }
}


function valideringTelfonnr(telfonnr) {
    const regexp = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{2,7}$/;
    const ok = regexp.test(telfonnr);
    if (isNaN(telfonnr) ) {
        $("#telfonnrFeil").html("Må skrive nummer");
        makeBorderRed(document.getElementById("telfonnr"));
        return false;
    }
    if (!ok) {
        $("#telfonnrFeil").html("Må være minst 8 siffer e.g. +4793412342");
        makeBorderRed(document.getElementById("telfonnr"));
        return false;
    }
    else {
        $("#telfonnrFeil").html("");
        makeBorderInitial(document.getElementById("telfonnr"));
        return true;
    }
}


function valideringAdresse(adresse) {
    var regexp = /^[a-zA-ZæøåÆØÅ.\-]+[a-zA-ZæøåÆØÅ0-9\ \_.]*[0-9]*$/;
    var ok = regexp.test(adresse);
    if (!ok) {
        $("#adresseFeil").html("Adressen må bestå av 2 til 50 bokstaver og tall");
        makeBorderRed(document.getElementById("adresse"));
        return false;
    }
    else {
        $("#adresseFeil").html("");
        makeBorderInitial(document.getElementById("adresse"));
        return true;
    }
}

function valideringPostnr(postnr) {
    var regexp = /^[0-9]{4}$/;
    var ok = regexp.test(postnr);
    if (!ok) {
        $("#postnrFeil").html("Postnr må bestå av 4 tall");
        makeBorderRed(document.getElementById("postnr"));
        return false;
    }
    else {
        $("#postnrFeil").html("");
        makeBorderInitial(document.getElementById("postnr"));
        return true;
    }
}

function validerPoststed(poststed) {
    var regexp = /^[a-zA-ZæøåÆØÅ\ \.\-]{2,20}/;
    var ok = regexp.test(poststed);
    if (!ok) {
        $("#poststedFeil").html("Poststed må bestå av 2 til 20 bokstaver");
        makeBorderRed(document.getElementById("poststed"));
        return false;
    }
    else {
        $("#poststedFeil").html("");
        makeBorderInitial(document.getElementById("poststed"));
        return true;
    }
}

function valideringEpost(epost) {
    var regexp = /^[A-Za-z0-9]{1}[A-Za-z0-9_.-]*@{1}[A-Za-z0-9_.-]{1,}\.[A-Za-z0-9]{1,}$/;
    var ok = regexp.test(epost);
    if (!ok) {
        $("#epostFeil").html("Må skrive f.eks: xxx@oslomet.no");
        makeBorderRed(document.getElementById("epost"));
        return false;
    }
    else {
        $("#epostFeil").html("");
        makeBorderInitial(document.getElementById("epost"));
        return true;
    }
}

function valideringKortnummer(kortnummer) {
    var regexp = /^[0-9]{16}$/;
    var ok = regexp.test(kortnummer);
    if (!ok) {
        $("#kortnummerFeil").html("Kortnummeret må bestå av 16 sifre");
        makeBorderRed(document.getElementById("kortnummer"));
        return false;
    }
    else {
        $("#kortnummerFeil").html("");
        makeBorderInitial(document.getElementById("kortnummer"));
        return true;
    }
}

function valideringkortholdersNavn(kortholdersNavn) {
    var regexp = /^[a-zA-ZæøåÆØÅ\.\ \-]{2,40}$/;
    var ok = regexp.test(kortholdersNavn);
    if (!ok) {
        $("#kortholdersNavnFeil").html("Skriv rikktig navn");
        makeBorderRed(document.getElementById("kortholdersNavn"));
        return false;
    }
    else {
        $("#kortholdersNavnFeil").html("");
        makeBorderInitial(document.getElementById("kortholdersNavn"));
        return true;
    }
}

function valideringUtlopsDato() {
    const arInput = document.getElementById("utlopsdatoAr").value;
    const manedInput = document.getElementById("utlopsdatoManed").value;
    let date = new Date();
    let regexp = /^[0-9]{2}$/;
    let currentYear = parseInt(date.getFullYear())  % 100;
    let currentMonth = parseInt(date.getMonth()) + 1;
    let arRegexOk = regexp.test(arInput);
    
    if (arRegexOk) {
        if (arInput > currentYear) {
            $("#utlopsdatoFeil").html("");
            return true;
        } else if (parseInt(arInput) === currentYear) {
            const manedOk = manedInput >= currentMonth;
            if (!manedOk) {
                $("#utlopsdatoFeil").html("Ugyldig måned");
                return false;
            }
            $("#utlopsdatoFeil").html("");
            return true;
        } else {
            $("#utlopsdatoFeil").html("Ugyldig år");
            return false;
        }
    } else {
        $("#utlopsdatoFeil").html("År må bestå av 2 sifre");
         return false;
    }
}

function valideringCardVerificationCode(cardVerificationCode) {
    console.log(cardVerificationCode)
    var regexp = /^[0-9]{3}$/;
    var ok = regexp.test(cardVerificationCode);
    if (!ok) {
        $("#cardVerificationCodeFeil").html("CVC må bestå av 3 sifre");
        makeBorderRed(document.getElementById("cardVerificationCode"));
        return false;
    }
    else {
        $("#cardVerificationCodeFeil").html("");
        makeBorderInitial(document.getElementById("cardVerificationCode"));
        return true;
    }
}
