const URL_VIACEP = "https://viacep.com.br/ws/@CEP/json/";


$(document).ready(function() {

    $('#cep').on('blur', () => {
        let cep = $('#cep').val();
        if (cep >= 8) {
            let urlCep = URL_VIACEP.replace('@CEP', cep);
            getJason(urlCep).then((resp) => {
                $('#country').val("Brasil");
                $('#uf').val(resp.uf);
                $('#city').val(resp.localidade);
                $('#neighbourhood').val(resp.bairro);
                $('#street').val(resp.logradouro);
            })
        }
    })
})
const getJason = (url) => {
    return fetch(url).then((resposta) => resposta.json());
}