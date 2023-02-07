
hideSelect = () => {
    let select = document.getElementById('valueSelect');
    let value = select.options[select.selectedIndex].value;
    if (value == 1) {
        $('#clientSelect').show()
    }
    else
    {       
        $('#clientSelect').hide();
    }
}

liveToastMessage = (message, origin) => {
    $('#toast-body').html(message);
    $('#toast-origin').html(origin);
    $('#toast-time').html(new Date().toLocaleDateString('pt-Br',
                                    {hour12: false,
                                        hour: "numeric",
                                        minute:"numeric"
        }));
    const toastLiveMessages = $('#liveToast')
    const toast = new bootstrap.Toast(toastLiveMessages);

    toast.show();
}

msgModalMessage = (message, callback) => {
    $('#modal-body').html(message);
    $('#btnModalCallback').click(() => callback());

    $('#msgModal').modal('show');
}

closeMsgModalMessage = () => {
    $('#msgModal').modal('hide')
}

deleteRegistro = (id, name, origin) => {
    msgModalMessage(`Você que mesmo excluir o registro ${name}?`, () => {
        $.ajax({
            url: `/${origin}/Delete`,
            method: 'POST',
            data: {
                id: id
            },
            success: (resp) => {
                var msg = `O Registro ${name} foi excluído.`;

                if (!(resp.code == '200')) {
                    msg = resp.status;
                }
                liveToastMessage(msg, `${origin}`);
                setTimeout(() => { window.location.reload(); }, 4000);
            }
        });
        closeMsgModalMessage();
    });
}