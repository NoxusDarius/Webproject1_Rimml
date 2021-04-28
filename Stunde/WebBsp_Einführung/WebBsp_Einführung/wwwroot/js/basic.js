//alert("basic.js");

// Zugriff mit JavaScript auf ein ID-Element
//document.getElementById("container_absatz1") -> JS - Methode aufrufen

//Zugriff mit jQuery auf ein ID-Element
//$("#container_absatz1")

//Zugriff mit jQuery auf ein Class-Element
//$(".container_absatz1")

//Zugriff mit jQuery auf ein Tag-Element
//$("p")


// JS-Code/JQuery-Code soll erst ausgeführt werden, wenn das komplette html-Document geladen wurde
// ready ... jQuery-Funktion
$(document).ready(function () {
    //alert("basic.js - ready()")
    $("#btn1").click(function () {
        $("p").text("neuer Text für alle Absätze");
    });
    $("#btn2").click(function() {
        $("#container_absatz1 p").text("neuer Text für disen Absatz");
    });
    $("#btn3").mouseenter(()=> {
        $(".c1").html("neuer Text für c1-Absätze");
    });
    $("#btn3").mouseleave(() => {
        $(".c1").html("SImma");
    });
    $("#btn4").click(() => {
        $("#id1").text("neuer Text für d1-Absätze");
    });
    $("#btn5").click(() => {
        $("#container_absatz3").toggle("slow");
    });
    $("#btnP").click(() => {
        $("#tableOnePerson").html(createTablenewPeople(createPeople()))
    });
    $("btnp").click(() => {
        $("#tablePeople").html(createTablenewPeople(createPeople()))
   

        

      
    });
});

function createPerson() {
    return { firstname: 'Manuel', lastname: 'Repetschnig', age: 18 };
    //JSON: definieren ein Feld mit dem Firstname, lastname, age
   //{wird benötigt}
    
}
function createPeople() {
    return [{ firstname: 'Manuel', lastname: 'Repetschnig', age: 18 }, { firstname: 'Danuel', lastname: 'Kepetschnig', age: 18 }, { firstname: 'Sanuel', lastname: 'Fepetschnig', age: 18 }];
}
function createTablenewPerson(person) {
    return `<table>
    <thead>
        <tr> <th colspan="2">Personendaten</th>
        </tr>
    </thead>
    <tbody>
       <tr>
            <td>Vorname</td>
            <td>${person.firstname}</td >
        </tr>
        <tr>
            <td>Lastname</td>
            <td>${person.lastname}</td >
        </tr>
        <tr>
            <td>Alter</td>
            <td>${person.age}</td >
        </tr>
      
    </tbody>
    <tfoot>
        <tr>
               
        </tr>
    </tfoot>
   
</table>`;
}
function createTablenewPeople(person2) {
   

       let s=`
<table>
    <thead>
        <tr> <th colspan="2">Personendaten</th>
        </tr>
    </thead>
    <tbody>
         `; for (let i = 0; i < person2.length; i++) {

             s += ` <tr>

            <tc>

                <td>${person2[i].firstname}</td >
            </tc>
            <tc>

                <td>${person2[i].lastname}</td >
            </tc>
            <tc>

                <td>${person2[i].age}</td >
            </tc>
        </tr>`;
  


 
       
            }
         
 
   
    s += `</table>`;

    return s;
}