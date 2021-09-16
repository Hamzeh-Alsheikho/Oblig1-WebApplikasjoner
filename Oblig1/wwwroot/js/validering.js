
function valideringFornavn(fornavn) {
    const regexp = /^[a-zA-ZæøåÆØÅ\.\ \-]{2,20}$/;
    const ok = regexp.test(fornavn);
    if (!ok) {
        $("#forNavnFeil").html("Fornavnet må bestå av 2 til 20 bokstaver");
        return false;
    }
    else {
        $("#forNavnFeil").html("");
        return true;
    }
}

function valideringEtternavn(etternavn) {
    const regexp = /^[a-zA-ZæøåÆØÅ\.\ \-]{2,20}$/;
    const ok = regexp.test(etternavn);
    if (!ok) {
        $("#etterNavnfeil").html("Etternavnet må bestå av 2 til 20 bokstaver");
        return false;
    }
    else {
        $("#etterNavnfeil").html("");
        return true;
    }
}


function valideringTelfonnr(telfonnr) {
    const regexp = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/im;
    const ok = regexp.test(telfonnr);
    if (isNaN(telfonnr) ) {
        $("#telfonnrFeil").html("Må skrive nummer");
        return false;
    }
    if (!ok) {
        $("#telfonnrFeil").html("Må være minst 8 siffer e.g. +4793412342");
        return false;
    }
    else {
        $("#telfonnrFeil").html("");
        return true;
    }
}


function valideringAdresse(adresse) {
    var regexp = /^[0-9a-zA-ZæøåÆØÅ\ \.\-]{2,50}$/;
    var ok = regexp.test(adresse);
    if (!ok) {
        $("#adresseFeil").html("Adressen må bestå av 2 til 50 bokstaver og tall");
        return false;
    }
    else {
        $("#adresseFeil").html("");
        return true;
    }
}

function valideringPostnr(postnr) {
    var regexp = /^[0-9]{4}$/;
    var ok = regexp.test(postnr);
    if (!ok) {
        $("#postnrFeil").html("Postnr må bestå av 4 tall");
        return false;
    }
    else {
        $("#postnrFeil").html("");
        return true;
    }
}

function validerPoststed(poststed) {
    var regexp = /^[a-zA-ZæøåÆØÅ\ \.\-]{2,20}/;
    var ok = regexp.test(poststed);
    if (!ok) {
        $("#poststedFeil").html("Poststed må bestå av 2 til 20 bokstaver");
        return false;
    }
    else {
        $("#poststedFeil").html("");
        return true;
    }
}

function valideringEpost(epost) {
    var regexp = /^[A-Za-z0-9]{1}[A-Za-z0-9_.-]*@{1}[A-Za-z0-9_.-]{1,}\.[A-Za-z0-9]{1,}$/;
    var ok = regexp.test(epost);
    if (!ok) {
        $("#epostFeil").html("Må skrive f.eks: xxx@oslomet.no");
        return false;
    }
    else {
        $("#epostFeil").html("");
        return true;
    }
}






