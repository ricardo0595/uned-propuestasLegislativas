(async function () {

    let crGeo = null;
    const provinceField = document.getElementById('province')
    const cantonField = document.getElementById('canton')
    const districtField = document.getElementById('district')
    const form = document.getElementById('proposalForm')
    const clearBtn = form.querySelector('.form__button--clear')
    const identificationType = document.querySelector('select[name="TipoIdentificacion"]')
    const identification = document.querySelector('input[name="Cedula"]')

    let validator = null;

    identificationType.onchange = function () {
        identification.value = '';
        if (identificationType.value === "N") {
            identification.placeholder = 'X-XXXX-XXXX'
            identification.pattern = '[1-9]-?\\d{4}-?\\d{4}'
            identification.setAttribute('maxlength', '11');

        } else {
            identification.placeholder = ''
            identification.removeAttribute('pattern');
            identification.setAttribute('maxlength','15');
        }
    }

    provinceField.onchange = function () {
        resetSelect(cantonField)
        resetSelect(districtField)
        setCantonField();
    }

    cantonField.onchange = function () {
        setDistrictField();
    }


    form.onsubmit = function (event) {
        event.preventDefault();
        getFormData();
    }

    async function getCRGeo() {
        const response = await fetch("/js/geo.json");
        crGeo = await response.json();
        setProvinceField();
    }

    clearBtn.onclick = function () {
        form.reset();
    }



    function resetSelect(select) {
        while (select.options.length > 1) {
            select.remove(1);
        }
    }

    function setProvinceField() {

        for (const [id, provincia] of Object.entries(crGeo.provincias)) {
            
            const op = document.createElement('option')
            op.value = id
            op.innerHTML = provincia.nombre
            provinceField.add(op)
        }

    }

    function setCantonField() {

        for (const [id, canton] of Object.entries(crGeo.provincias[provinceField.value].cantones)) {
            const op = document.createElement('option')
            op.value = id
            op.innerHTML = canton.nombre
            cantonField.add(op)
        }
    }

    function setDistrictField(cantonId) {


        for (const [id, distrito] of Object.entries(crGeo.provincias[provinceField.value].cantones[cantonField.value].distritos)) {
            const op = document.createElement('option')
            op.value = id
            op.innerHTML = distrito
            districtField.add(op)
        }
    }

    function getFormData() {

       

        let formData = {};
        const fields = form.querySelectorAll('input,textarea,select');
        fields.forEach(function (field) {
            formData[field.name] = field.value;
        })
        formData.IdPropuesta = null;
        console.log(formData)

        var myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");

        var raw = JSON.stringify(formData);

        var requestOptions = {
            method: 'POST',
            headers: myHeaders,
            body: raw,
            redirect: 'follow'
        };

        fetch("/Propuestas/EnviarPropuesta", requestOptions)
            .then(response => {
                
                response.json().then(function (data) {
                    if (data) {
                        location.replace("/Propuestas/Confirmacion");
                    } else {
                        location.replace("/Propuestas/Error");
                    }
                })
            })
            .catch(error => {
                console.log('error', error)
                location.replace("/Propuestas/Error");
            });

    }

   

    getCRGeo()

}())