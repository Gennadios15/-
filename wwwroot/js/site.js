document.getElementById('signup_button').addEventListener('click', function () {
    window.location.href = '/Home/Sign_Up';
});

document.getElementById('authorize_button').addEventListener('click', function () {
    window.location.href = '/Home/Sign_In';
});

document.getElementById('signInForm').addEventListener('submit', function (event) {
    event.preventDefault(); // Prevent the default submit behavior

    // Submit the form using JavaScript
    this.submit();

    // Redirect to the home page
    window.location.href = '/Home/Index';
});

function showMenu() {
    document.getElementById("slide").classList.toggle("showmenu");
}





//CATEGORY FUNCTION
document.getElementById('categoryButons').addEventListener('click', function () {
    window.location.href = '/Home/Sign_Up';
});