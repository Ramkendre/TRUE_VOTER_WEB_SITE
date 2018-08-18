function numbersonly(evt) {
    var charCode = (evt.fwhich) ? evt.which : event.keyCode;
    if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

function insertTruckNo(evt) {
    var charCode = (evt.fwhich) ? evt.which : event.keyCode;
    if (charCode == 32) { return false; }
    if (evt.value.length == 2) {
        evt.value += " ";
        return;
    }
    if (evt.value.length == 5) {
        evt.value += " ";
        return;
    }
    if (evt.value.length == 8) {
        evt.value += " ";
        return;
    }
}

function validateDOB(evt)
{
    var dob = document.forms[1][1].value;
    var pattern = /^([0-9]{4})-([0-9]{2})-([0-9]{2})$/;
    if (dob == null || dob == "" || !pattern.test(dob)) {
        errMessage += "Invalid date of birth\n";
        return false;
    }
    else {
        return true
    }
}
