function __SubmitForm(eventTarget, eventArgument) {
    if (!registerform.onsubmit || (registerform.onsubmit() != false)) {
       
        registerform.submit();
    }
}