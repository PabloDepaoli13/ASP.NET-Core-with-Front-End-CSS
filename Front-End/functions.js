const $btnAgregar = document.getElementById("btnAgregar"), modal = document.getElementById("myModal"), span = document.getElementById("btnClose"),
$btnAgregarElement = document.getElementById("btnAgregarCust");

$btnAgregar.addEventListener("click", (e) => 


    {modal.style.display = "block";}

);

span.addEventListener("click", (e) => {
    modal.style.display = "none";
});

$btnAgregarElement.addEventListener("click", (e) => {
    e.preventDefault();
    var data = {
        "firstName": document.getElementById('agr-name').value,
        "lastName": d.getElementById('agr-ape').value, 
        "email": d.getElementById('agr-em').value,
        "phone": d.getElementById('agr-pho').value,
        "address": d.getElementById('agr-dir').value
   };
   console.log(data);
   create(data);
});