document.getElementById('signup_button').addEventListener('click', function () {
    window.location.href = '/Home/Sign_Up';
});

document.getElementById('authorize_button').addEventListener('click', function () {
    window.location.href = '/Home/Sign_In';
});

function showMenu() {
    document.getElementById("slide").classList.toggle("showmenu");
}


function myMenu() {
    console.log("Im in my menu");
    
    }


