const URL_API = 'http://localhost:5024/api/'

document.addEventListener("DOMContentLoaded", init)

async function init(){
    await search()
}

 async function search(){
    var url = URL_API + 'customer';
    var response = await fetch(url, {
        "method": 'GET',
        "mode": 'cors',
        "headers": {
            "Content-Type": 'aplication/json'
        }
    }).then(response => response.json());

    console.log(response)
    
    var $html = '';

    for(customer of response){
        var row = `<tr>
        <td>${customer.firstName}</td>
        <td>${customer.lastName}</td>
        <td>${customer.email}</td>
        <td>${customer.phone}</td>
        <td><a href="#" class="button">Eliminar</a><a href="#" class="button">Editar</a></td>
    </tr>`;
    $html += row;
    }
    
    document.querySelector('#customers > tbody').outerHTML = $html; 
    
}