// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

function ShowHideDivSingleMulti() {
    showHideElement("singleCell", "singleCellShow", "singleCellHide");
}


function ShowHideDivSingleNotesOnOff() {
    //showHideElement("notesCheck", "numbersToSelect", "possibilitiesToSelect");
    document.getElementById("hiddenNotesCheck").click();
}

function ShowHideDivSingleGridOnOff() {
    //showHideElement("notesCheck", "numbersToSelect", "possibilitiesToSelect");
    document.getElementById("hiddenGridCheck").click();
}

function showHideElement(docYes, show, hide) {
var chkYes = document.getElementById(docYes);
var containerToHide = document.getElementById(hide);
var containerToShow= document.getElementById(show);
containerToHide.style.display = chkYes.checked ? "block" : "none";
containerToShow.style.display = chkYes.checked ? "none" : "block";
}

function EnterNumbers(i,j) {

    var id = "myInput" + ";" + i + ";" + j;
    console.log(id);
    var input = document.getElementById(id);
    console.log(input.value);
}

function IsGridValid(id) {
    console.log("VALIDATION TEST");

    let aaa = id.substring(8, 9);
    let bbb = id.substring(10, 11);
    console.log("[ " + aaa + " , " + bbb + " ] ");
    unhighlightErrorCells(aaa, bbb);
    //myInput; "+i + "; " + j;
    //Check Rows
    for (let i = 0; i < 9; i++)
    {
        var rows = [];
        for (let j = 0; j < 9; j++)
        {
            var idName = "myInput;" + i + ";" + j;
            var element = document.getElementById(idName);
            var elementValue = element.value;
            if (elementValue == "")
            {
                rows.push(0);
            }
            else
            {
                rows.push(parseInt(elementValue));
            }

        }
        let isV = isValid(rows);
        console.log(isV);
        if (!isV) {
            document.getElementById('typedInvalid').style.visibility = 'visible';
            highlightErrorCells(aaa,bbb, true);
            return false;
        }

        //console.log(isV+ i);
    }

    //Check Cols
    for (let j = 0; j < 9; j++)
    {
        var cols = [];
        for (let i = 0; i < 9; i++)
        {
            var idName = "myInput;" + i + ";" + j;
            var element = document.getElementById(idName);
            var elementValue = element.value;
            if (elementValue == "")
            {
                cols.push(0);
            }
            else {
                cols.push(parseInt(elementValue));
            }

        }
        let isV = isValid(cols);
        console.log(isV);
        if (!isV) {
            document.getElementById('typedInvalid').style.visibility = 'visible';
            highlightErrorCells(aaa,bbb, true);
            return false;
        }

        //console.log(isV+ i);
    }

    //Check Blocks

    var blocks = ["0-0", "0-1", "0-2", "1-0", "1-1", "1-2", "2-0", "2-1", "2-2"];

    for (let a = 0; a < 9; a++) {
        var check = blocks[a];
        var blockList = [];
        for (let i = 0; i < 9; i++) {
            
            for (let j = 0; j < 9; j++) {

                let a = parseInt(i / 3);
                let b = parseInt(j / 3);
                var ijCheck = a + "-" + b;
                if (ijCheck == check) {
                   // console.log("BLOCK INDEX CHECK " +ijCheck + " " + i + " / " + j);
                    var idName = "myInput;" + i + ";" + j;
                    var element = document.getElementById(idName);
                    var elementValue = element.value;
                    if (elementValue == "") {
                        blockList.push(0);
                    }
                    else {
                        blockList.push(parseInt(elementValue));
                    }

                }

                //console.log(isV+ i);
            }

        }

        let isV = isValid(blockList);
        console.log("BLOCK INDEX " + a);
        console.log(blockList);
        console.log(isV);
        if (!isV) {
            document.getElementById('typedInvalid').style.visibility = 'visible';
            highlightErrorCells(aaa,bbb, true);
            return false;
        }
    }

    document.getElementById('typedInvalid').style.visibility = 'hidden';

}

function highlightErrorCells(i, j, isHighlight) {

    if (!isHighlight) {
        for (let abc = 0; abc < 9; abc++) {
            for (let cde = 0; cde < 9; cde++) {
                var idNames = "myInput;" + abc + ";" + cde;
                var element = document.getElementById(idNames);
                var elementValue = element.value;
                element.style.backgroundColor = "";
            }
        }
    }
    for (let num = 1; num <= 9; num++) {
        let numC = 0;

        //ROWS
        for (let a = 0; a < 9; a++) {
            numC = 0;
            var cells = [];
            for (let b = 0; b < 9; b++) {


                var idName = "myInput;" + a + ";" + b;
                var element = document.getElementById(idName);
                var elementValue = element.value;
                if (elementValue == num) {
                    numC += 1;
                    cells.push(idName);
                }
            }

            if (numC > 1) {

                for (let c = 0; c < cells.length; c++) {
                    var idNameH = cells[c];
                    var elementH = document.getElementById(idNameH);
                    if (isHighlight) {
                        elementH.style.backgroundColor = "red";
                    }

                    else {
                        element.style.backgroundColor = "";
                    }
                    
                }
            }
        }

        //COLS

        for (let b = 0; b < 9; b++) {
            numC = 0;
            var cells = [];
            for (let a = 0; a < 9; a++) {


                var idName = "myInput;" + a + ";" + b;
                var element = document.getElementById(idName);
                var elementValue = element.value;
                if (elementValue == num) {
                    numC += 1;
                    cells.push(idName);
                }
            }

            if (numC > 1) {

                for (let c = 0; c < cells.length; c++) {
                    var idNameH = cells[c];
                    var elementH = document.getElementById(idNameH);
                    if (isHighlight) {
                        elementH.style.backgroundColor = "red";
                    }

                    else {
                        element.style.backgroundColor = "";
                    }
                }
            }
        }

        // BLOCKS
        var blocks = ["0-0", "0-1", "0-2", "1-0", "1-1", "1-2", "2-0", "2-1", "2-2"];

        for (let bl = 0; bl < 9; bl++) {
            var check = blocks[bl];
            var blockList = [];
            numC = 0;
            var cells = [];
            for (let a = 0; a < 9; a++) {

                for (let b = 0; b < 9; b++) {
                    let co1 = parseInt(a / 3);
                    let co2 = parseInt(b / 3);
                    var ijCheck = co1 + "-" + co2;
                    if (ijCheck == check) {
                        console.log(ijCheck);
                        var idNames = "myInput;" + a + ";" + b;
                        var element = document.getElementById(idNames);
                        var elementValue = element.value;
                        if (elementValue == num) {
                            numC += 1;
                            cells.push(idNames);
                        }
                    }

                }
            }


            console.log("NUM = " +num + " BLOCK No " + bl + " = COUNT OF " + numC);
            if (numC > 1) {

                for (let c = 0; c < cells.length; c++) {
                    var idNameH = cells[c];
                    console.log("ADD : " + idNameH)
                    var elementH = document.getElementById(idNameH);
                    if (isHighlight) {
                        elementH.style.backgroundColor = "red";
                    }

                    else {
                        element.style.backgroundColor = "";
                    }
                }
            }
        }
    }   
}

function unhighlightErrorCells(i, j) {
    highlightErrorCells(i, j, false);
    
}

function isValid(arr) {
    arr.sort();
    var current = 0;
    //console.log(arr);
    for (var i = 0; i < arr.length; i++)
    {
        let num = arr[i];
        
        if (num == 0) {
            continue;
        }
        if (num == current) {

            return false;
        }

        current = num;
    };
   
    return true;
}



function validateNumbers(id) {
    var element = document.getElementById(id);
    var elementValue = element.value;
    var pattern = /^[1-9]+$/;
    var result = elementValue.match(pattern);
    console.log(result + " " + elementValue);
    if (result == null) {
        console.log("no match here")
        element.value = "";
    }

    else {
        if (element.value.length > 1) {
            var sliceV = element.value.slice(1, 2);
            var l =
                element.value.length > 1
            element.value = element.value.slice(1, 2);
            console.log(sliceV + " " + l);
        }
        }

    IsGridValid(id)
}

function moveCoordinate(coordinate, direction) {
    var word = "myInput;";
    var trueCoordinate = coordinate.substring(8);
    console.log("true coordinate is " + trueCoordinate);
    if (direction == "up") {
        return word + Up(trueCoordinate);
    }

    if (direction == "down") {
        return word + Down(trueCoordinate);
    }
    if (direction == "left") {
        return word + Left(trueCoordinate);
    }

    if (direction == "right") {
        return word + Right(trueCoordinate);
    }
    return coordinate;
}

function Up(coordinate) {
    var c = SplitTextCoordinate(coordinate);
    var i = c.i;
    var j = c.j;
    var d = findUpwardsCell(i, j);
    var x = d.x;
    var y = d.y;
    return x + ";" + y;
}

function Down(coordinate) {
    var c = SplitTextCoordinate(coordinate);
    var i = c.i;
    var j = c.j;
    var d = findBackwardsCell(i, j);
    var x = d.x;
    var y = d.y;
    return x + ";" + y;
}

function Left(coordinate) {
    var c = SplitTextCoordinate(coordinate);
    var i = c.i;
    var j = c.j;
    var d = findPreviousCell(i, j);
    var x = d.x;
    var y = d.y;
    return x + ";" + y;
}

function Right(coordinate) {
    var c = SplitTextCoordinate(coordinate);
    var i = c.i;
    var j = c.j;
    var d = findNextCell(i, j);
    var x = d.x;
    var y = d.y;
    return x + ";" + y;
}

function SplitTextCoordinate(x) {
    ii = x.substring(0, 1);
    jj = x.substring(2, 3);
    console.log("SS " + ii + " / " + jj);
    i = parseInt(ii);
    j = parseInt(jj);

    return {
        i,
        j
    };
}

function findNextCell(i, j, ) {
    x = i;
    y = j + 1;

    if (y > 8) {
        y -= 9;
        x += 1;

        if (x > 8) {
            x -= 9;
        }
    }
    return {
        x, y
    };
}

function GetCoOrdinatesOfCell(cellIn) //Gets x and Y coordinate of a singular Index
{
    cellIn -= 1;
    let GroupSize = 9;
    x = parseInt(cellIn / GroupSize);
    y = cellIn % GroupSize;

    return {
        x, y
    };

}

function Get1DIndex(x, y) {
    let GroupSize = 9;
    return x * GroupSize + y;
}

function findPreviousCell(i, j) {
    x = i;
    y = j - 1;
    if (y < 0) {
        y += 9;
        x -= 1;
        if (x < 0) {
            x += 9;
        }
    }
    return {
        x, y
    };
}

function findUpwardsCell(i, j) {
    x = i - 1;
    y = j;
    if (x < 0) {
        x += 9;
        y -= 1;
        if (y < 0) {
            y += 9;
        }
    }
    return {
        x, y
    };
}

function findBackwardsCell(i, j) {
    x = i + 1;
    y = j;

    if (x > 8) {
       
        x -= 9;
        y += 1;

        if (y > 8) {
            y -= 9;
        }
    }
    return {
        x, y
    };
}

document.addEventListener('keydown', function (e) {
    var code = e.which || e.keyCode;
    var currentElement = document.activeElement.id;
    if (code == '38') {
        //Up
        var c = moveCoordinate(currentElement, "up");
        var x = document.getElementById(c);
        x.focus();
    }
    else if (code == '40') {
        //Down
        var c = moveCoordinate(currentElement, "down");
        console.log(c);
        var x = document.getElementById(c);
        x.focus();
    }
    else if (code == '37') {
        //Left
        var c = moveCoordinate(currentElement, "left");
        console.log(c);
        var x = document.getElementById(c);
        x.focus();
    }
    else if (code == '39') {
        //right
        var c = moveCoordinate(currentElement, "right");
        console.log(c);
        var x = document.getElementById(c);
        x.focus();
    }

}
    )