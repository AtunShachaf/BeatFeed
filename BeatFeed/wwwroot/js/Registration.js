
function checkPassword() {
    // timeout before a callback is called
    var timeout;
    // traversing the DOM and getting the input and span using their IDs
    var strengthBadge = document.getElementById('StrengthDisp');
    // The strong and weak password Regex pattern checker
    var password = document.getElementById('pass');
    var strongPassword = new RegExp('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9])(?=.{8,})');
    var mediumPassword = new RegExp('((?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9])(?=.{6,}))|((?=.*[a-z])(?=.*[A-Z])(?=.*[^A-Za-z0-9])(?=.{8,}))');


    function StrengthChecker(PasswordParameter) {
        // We then change the badge's color and text based on the password strength

        if (strongPassword.test(PasswordParameter)) {
            strengthBadge.style.backgroundColor = "green"
            strengthBadge.textContent = 'Strong'
        } else if (mediumPassword.test(PasswordParameter)) {
            strengthBadge.style.backgroundColor = 'blue'
            strengthBadge.textContent = 'Medium'
        } else {
            strengthBadge.style.backgroundColor = 'red'
            strengthBadge.textContent = 'Weak'
        }
    }

    // Adding an input event listener when a user types to the  password input 

    password.addEventListener("input", () => {
        //The badge is hidden by default, so we show it
        strengthBadge.style.display = 'block'
        clearTimeout(timeout);
        //We then call the StrengChecker function as a callback then pass the typed password to it
        timeout = setTimeout(() => StrengthChecker(password.value), 500);
        //Incase a user clears the text, the badge is hidden again
        if (password.value.length !== 0) {
            strengthBadge.style.display != 'block'
        } else {
            strengthBadge.style.display = 'none'
        }

    });
}

$(document).ready(function (e) {
    $('#pass').keypress(checkPassword());
    $('#submit').click(function (event) {
        var strengthBadge = document.getElementById('StrengthDisp');
        if (strengthBadge.textContent == 'Weak') {
            $("#pw-ad-field").html("Password must be at least 8 charachters long</br>also 1 uppercase, lowercase and special characters.");
            event.preventDefault();
           
        }
    })
})