const $btnAgregar = document.getElementById("btnAgregar"), modal = document.getElementById("myModal"), span = document.getElementById("btnClose");

$btnAgregar.addEventListener("click", (e) => 


    {modal.style.display = "block";}

);

span.addEventListener("click", (e) => {
    modal.style.display = "none";
});