$(document).ready(function () {
    $('#myForm').submit(function (event) {
        // Reset border styles and clear previous error messages
        $('.border').removeClass('error');
        $('.error-message').remove();

        // Validate Name
        var name = $('#name').val().trim();
        if (name === '') {
            showError('name', 'Please enter your name');
            event.preventDefault();
        }

        // Validate Email
        var email = $('#email').val().trim();
        if (email === '' || !isValidEmail(email)) {
            showError('email', 'Please enter a valid email address');
            event.preventDefault();
        }

        // Validate Contact
        var contact = $('#contact').val().trim();
        if (contact === '' || !isValidContact(contact)) {
            showError('contact', 'Please enter a valid contact number');
            event.preventDefault();
        }

        // Validate Address
        var address = $('#address').val().trim();
        if (address === '') {
            showError('address', 'Please enter your address');
            event.preventDefault();
        }
    });

    // Function to display an error message and add a red border
    function showError(fieldId, errorMessage) {
        $('#' + fieldId).next('.border').addClass('error');
        $('#' + fieldId).parent().append('<div class="error-message">' + errorMessage + '</div>');
    }

    // Function to check if the email is valid using a simple regex
    function isValidEmail(email) {
        var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(email);
    }

    // Function to check if the contact number is valid
    function isValidContact(contact) {
        return /^\d+$/.test(contact);
    }
});
