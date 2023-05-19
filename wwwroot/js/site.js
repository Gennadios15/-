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
function fetchData(buttonId) {
    // Get the category based on the buttonId
    const category = getCategoryFromButtonId(buttonId);

    // Fetch data from the server based on the category
    fetch(`/api/data?category=${category}`)
        .then((response) => response.json())
        .then((data) => {
            // Update the UI with the fetched data
            updateUI(data);
        })
        .catch((error) => {
            console.error('Error fetching data:', error);
        });
}

function getCategoryFromButtonId(buttonId) {
    // Return the appropriate category based on the buttonId
    // ...
}

//DISPLAY DATA
function updateUI(data) {
    // Get the element where you want to display the data
    const dataContainer = document.getElementById('dataContainer');

    // Clear the previous content
    dataContainer.innerHTML = '';

    // Iterate through the fetched data and create new elements to display it
    data.forEach((item) => {
        const dataElement = document.createElement('div');
        dataElement.textContent = item.name; // Replace 'name' with the appropriate property from your data model
        dataContainer.appendChild(dataElement);
    });
}

