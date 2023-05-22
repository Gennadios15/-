function togglePane(elementId, moreId, lessId, flag, shrinkSize, growSize) {
    var element = document.getElementById(elementId);
    var moreElement = document.getElementById(moreId);
    var lessElement = document.getElementById(lessId);

    if (flag === true) {
        element.style.height = growSize;
        moreElement.style.display = 'none';
        lessElement.style.display = 'inline';
    } else {
        element.style.height = shrinkSize;
        lessElement.style.display = 'none';
        moreElement.style.display = 'inline';
    }
}

function test() {
    alert(document.getElementById("customRange3").value);
}