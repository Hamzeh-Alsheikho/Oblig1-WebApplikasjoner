 function lagreKunde() {
    const kunde = {
        fornavn: $("#fornavn").val(),
        etternavn: $("#etternavn").val(),
        adresse: $("#adresse").val(),
        postnr: $("#postnr").val(),
        poststed: $("#poststed").val(),
        destination: $("#reiseMal").val(),
        antallAdult: $("#antallAdult").val(),
        antallChild: $("#antallChild").val(),
        ticketType: getTicketType()
    }

    const url = "Kunde/Lagre";
    $.post(url, kunde, function (OK) {
        if (OK) {
            window.location.href = 'index.html';
        }
        else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }

    });
    getTicketType();
}

function getTicketType() {
    const singleInput = document.getElementById("single");
    const turReturInput = document.getElementById("turRetur");

    const ticketArray = [singleInput, turReturInput];
    let ticketType;
    
    for (let ticketType of ticketArray) {
        if (ticketType.checked) {
            ticketType = ticketType.value;
            return ticketType.value;  
	    }
    }
    console.log("sfsdf", ticketType)
}