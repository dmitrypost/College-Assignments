function UpdateTotal() {
    var adultcount = $( "#numberOfAdults" ).val();
    var childcount = $( "#numberOfChildren" ).val();
    var sum = adultcount * 125 + childcount * 75;
	document.getElementById("Total").innerHTML = "Total: $" + sum;
};

function Debug(string) {
    document.getElementById('Debug').innerHTML = string;
}

function Clear() {
    __SubmitForm("","");
}

