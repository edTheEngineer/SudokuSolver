// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

function ShowHideDivSingleMulti() {
    showHideElement("singleCell", "singleCellShow", "singleCellHide");
}


function ShowHideDivSingleNotesOnOff() {
    showHideElement("notesCheck", "numbersToSelect", "possibilitiesToSelect", );
}

function showHideElement(docYes, show, hide) {
var chkYes = document.getElementById(docYes);
var containerToHide = document.getElementById(hide);
var containerToShow= document.getElementById(show);
containerToHide.style.display = chkYes.checked ? "block" : "none";
containerToShow.style.display = chkYes.checked ? "none" : "block";
}