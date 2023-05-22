document.getElementById('signup_button').addEventListener('click', function () {
    window.location.href = '/Home/Sign_Up';
});

document.getElementById('authorize_button').addEventListener('click', function () {
    window.location.href = '/Home/Sign_In';
});

function showMenu() {
    document.getElementById("slide").classList.toggle("showmenu");
}

function togglePane(elementId, moreId, lessId, flag, shrinkSize, growSize) {
    var element = document.getElementById(elementId);
    var moreElement = document.getElementById(moreId);
    var lessElement = document.getElementById(lessId);

    if (flag === 'true') {
        element.style.height = growSize;
        moreElement.style.display = 'none';
        lessElement.style.display = 'initial';
        document.getElementById('Checkbox4').style.display = 'none';
    } else {
        element.style.height = shrinkSize;
        lessElement.style.display = 'none';
        moreElement.style.display = 'initial';
    }
}