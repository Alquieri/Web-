const nome = document.getElementById('nome');
const form = document.getElementById('form');
const input = document.getElementById('cep');


async function BuscaCep(endpoint) {
    try {
        const response = await fetch(endpoint);
        const data = await response.json();
        console.log(data);
        nome.innerText = `${data.logradouro}`;
    } catch (error) {
        nome.innerText = 'Erro';
        console.error(error);
    }
}

form.addEventListener('submit', (event) => {
    event.preventDefault();
BuscaCep(`https://viacep.com.br/ws/${input.value}/json/`);
})




