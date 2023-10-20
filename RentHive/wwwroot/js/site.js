/*document.addEventListener("DOMContentLoaded", () => {
    const editButton = document.querySelector(".editButton");
    const saveButton = document.querySelector(".saveButton");

    editButton.addEventListener("click", () => {
        // Enable input fields
        userDisplayName.disabled = false;
        userFirstName.disabled = false;
        userMiddleName.disabled = false;
        userLastName.disabled = false;
        userPhoneNum.disabled = false;
        userBirthDate.disabled = false;
        userAddress.disabled = false;

        // Toggle button visibility
        editButton.style.display = "none";
        saveButton.style.display = "inline-block";
    });

    saveButton.addEventListener("click", () => {
        // Disable input fields
        userDisplayName.disabled = true;
        userFirstName.disabled = true;
        userMiddleName.disabled = true;
        userLastName.disabled = true;
        userPhoneNum.disabled = true;
        userBirthDate.disabled = true;
        userAddress.disabled = true;

        // Toggle button visibility
        editButton.style.display = "inline-block";
        saveButton.style.display = "none";

    });
});*/

document.addEventListener("DOMContentLoaded", () => {
    const editButton = document.querySelector(".editButton");
    const saveButton = document.querySelector(".saveButton");

    // Select the input fields by their IDs
    const userDisplayName = document.querySelector("#userDisplayName");
    const userFirstName = document.querySelector("#userFirstName");
    const userMiddleName = document.querySelector("#userMiddleName");
    const userLastName = document.querySelector("#userLastName");
    const userPhoneNum = document.querySelector("#userPhoneNum");
    const userBirthDate = document.querySelector("#userBirthDate");
    const userAddress = document.querySelector("#userAddress");

    editButton.addEventListener("click", () => {
        // Remove the readonly attribute
        userDisplayName.removeAttribute("readonly");
        userFirstName.removeAttribute("readonly");
        userMiddleName.removeAttribute("readonly");
        userLastName.removeAttribute("readonly");
        userPhoneNum.removeAttribute("readonly");
        userBirthDate.removeAttribute("readonly");
        userAddress.removeAttribute("readonly");

        // Toggle button visibility
        editButton.style.display = "none";
        saveButton.style.display = "inline-block";
    });

    saveButton.addEventListener("click", () => {
        // Add the readonly attribute back
        userDisplayName.setAttribute("readonly", "readonly");
        userFirstName.setAttribute("readonly", "readonly");
        userMiddleName.setAttribute("readonly", "readonly");
        userLastName.setAttribute("readonly", "readonly");
        userPhoneNum.setAttribute("readonly", "readonly");
        userBirthDate.setAttribute("readonly", "readonly");
        userAddress.setAttribute("readonly", "readonly");

        // Toggle button visibility
        editButton.style.display = "inline-block";
        saveButton.style.display = "none";
    });
});


document.addEventListener("DOMContentLoaded", function () {
    const passwordInput = document.querySelector('.password-text');
    const showIcon = document.getElementById('showIcon');
    const hideIcon = document.getElementById('hideIcon');

    showIcon.addEventListener("click", () => {
        passwordInput.type = 'text';
        showIcon.style.display = 'none';
        hideIcon.style.display = 'inline';
    });

    hideIcon.addEventListener("click", () => {
        passwordInput.type = 'password';
        showIcon.style.display = 'inline';
        hideIcon.style.display = 'none';
    });
});



