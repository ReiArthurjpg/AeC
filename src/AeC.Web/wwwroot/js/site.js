document.addEventListener('DOMContentLoaded', () => {
    // CEP mask and autocomplete for the standalone Form page (Edit/Create via page)
    const cep = document.querySelector('.cep-mask');
    const btnBuscar = document.getElementById('btn-buscar-cep');
    if (cep) {
        cep.addEventListener('input', () => {
            let v = cep.value.replace(/\D/g, '').slice(0, 8);
            cep.value = v.length > 5 ? v.slice(0, 5) + '-' + v.slice(5) : v;
        });
        const buscarCep = async () => {
            const clean = cep.value.replace(/\D/g, '');
            if (clean.length !== 8) return;
            const load = document.getElementById('cep-loading');
            if(load) load.classList.remove('d-none');
            try {
                const resp = await fetch(`/Enderecos/BuscarCep?cep=${clean}`);
                if (!resp.ok) {
                    Swal.fire('CEP não encontrado', 'Verifique o CEP informado.', 'info');
                    return;
                }
                const d = await resp.json();
                document.getElementById('Logradouro').value = d.logradouro || '';
                document.getElementById('Complemento').value = d.complemento || '';
                document.getElementById('Bairro').value = d.bairro || '';
                document.getElementById('Cidade').value = d.localidade || '';
                document.getElementById('UF').value = d.uf || '';
            } catch {
                Swal.fire('Falha na consulta', 'Não foi possível consultar o ViaCEP agora.', 'error');
            } finally {
                if(load) load.classList.add('d-none');
            }
        };
        cep.addEventListener('blur', buscarCep);
        if (btnBuscar) {
            btnBuscar.addEventListener('click', buscarCep);
        }
    }
});
