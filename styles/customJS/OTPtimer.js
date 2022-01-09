
    var timeLeft = 60;
    var label = document.getElementById('ctn');
    var elem = document.getElementById('ButtonResendOTP');
    var timerId = setInterval(countdown, 1000);

    function countdown() {
    if (timeLeft == -1) {
        clearTimeout(timerId);
    doSomething();
    } else {
        label.innerHTML = 'Resend OTP ' + timeLeft + ' seconds left';
    timeLeft--;
    }
}

function doSomething() {
    document.getElementById("ButtonResendOTP").className = "MyClass";
   
}
