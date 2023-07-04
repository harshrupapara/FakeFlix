function validateForm(event) {
    event.preventDefault(); // Prevent form submission

    // Get form values
    var name = document.getElementById("contactform-name").value;
    var email = document.getElementById("contactform-email").value;
    var message = document.getElementById("contactform-message").value;

    // Validate form fields
    if (name === "" || email === "" || message === "") {
        alert("Please fill in all fields.");
        return;
    }
    // Perform additional validation if needed

    // Submit the form (you can replace the URL with your actual API endpoint)
    fetch("https://local.fakeflix.com/api/contactus/postcontactform", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ "name": name, "email": email, "message": message }),
    }).then(response => response.text())
        .then(data => {
            console.log(data);
            document.getElementById("contact-form").reset();
            alert("Form submitted successfully! Thank You!");
        })
        .catch(error => {
            console.log(error);
        });
    console.log(email);
}

// Attach event listener to form submission
document
    .getElementById("contact-form")
    .addEventListener("submit", validateForm);
