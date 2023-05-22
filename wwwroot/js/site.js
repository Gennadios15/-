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
        lessElement.style.display = 'inline';
        if (element === divCategory) {
            document.getElementById('Checkbox4').style.display = 'block';
            document.getElementById('Checkbox5').style.display = 'block';
            document.getElementById('Checkbox6').style.display = 'block';
            document.getElementById('Checkbox7').style.display = 'block';
            document.getElementById('Checkbox8').style.display = 'block';
            document.getElementById('Checkbox9').style.display = 'block';
            document.getElementById('Checkbox10').style.display = 'block';
            document.getElementById('Checkbox11').style.display = 'block';
            document.getElementById('Checkbox12').style.display = 'block';
            document.getElementById('Checkbox13').style.display = 'block';
            document.getElementById('Checkbox14').style.display = 'block';
        } else {
            document.getElementById('Checkbox18').style.display = 'block';
            document.getElementById('Checkbox19').style.display = 'block';
            document.getElementById('Checkbox20').style.display = 'block';
        }
    } else {
        element.style.height = shrinkSize;
        lessElement.style.display = 'none';
        moreElement.style.display = 'inline';
        if (element === divCategory) {
            document.getElementById('Checkbox4').style.display = 'none';
            document.getElementById('Checkbox5').style.display = 'none';
            document.getElementById('Checkbox6').style.display = 'none';
            document.getElementById('Checkbox7').style.display = 'none';
            document.getElementById('Checkbox8').style.display = 'none';
            document.getElementById('Checkbox9').style.display = 'none';
            document.getElementById('Checkbox10').style.display = 'none';
            document.getElementById('Checkbox11').style.display = 'none';
            document.getElementById('Checkbox12').style.display = 'none';
            document.getElementById('Checkbox13').style.display = 'none';
            document.getElementById('Checkbox14').style.display = 'none';
        } else {
            document.getElementById('Checkbox18').style.display = 'none';
            document.getElementById('Checkbox19').style.display = 'none';
            document.getElementById('Checkbox20').style.display = 'none';
        }

    }
}

function getValue() {
    var v = document.getElementById('customRange').value;
    document.getElementById('valueBox').value = v;
}

function myMenu() {
    console.log("Im in my menu");
    
    }


