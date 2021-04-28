$(document).ready(function () {
  
    $("#btn1").click(function () {
        $("#absatz1").toggle("slow");
      
    });
    $("#btnf").click(function () {
        $("#absatz1").text("Hallo");

    });
    $("#btnp").click(() => {
        $("#table").html(tableperson(createPerson()))
    });
});

function createPerson() {
    let msg = document.querySelector("#vorname").value;
    let msg2 = document.querySelector("#alter").value;

    return { firstname: msg , alter: msg2 };
    

}

function tableperson(person) {
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
            <td>${person.alter}</td >
        </tr>
        
      
    </tbody>
    <tfoot>
        <tr>
               
        </tr>
    </tfoot>
   
</table>`;
}











