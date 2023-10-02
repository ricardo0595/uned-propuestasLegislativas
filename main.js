(async function () {

    let crGeo = null;
    const provinceField = document.getElementById('province')
    const cantonField = document.getElementById('canton')
    const districtField = document.getElementById('district')
    const form = document.getElementById('proposalForm')
    const submitForm = form.querySelector('button[name="submit"]')

    provinceField.onchange = function () {
        resetSelect(cantonField)
        resetSelect(districtField)
        setCantonField();
    }

    cantonField.onchange = function () {
        setDistrictField();
    }

    submitForm.onclick = function () {
        getFormData();
    }

    async function getCRGeo() {
        const response = await fetch("/geo.json");
        crGeo = await response.json();
        console.log(crGeo);
        setProvinceField();
    }



    function resetSelect(select) {
        while (select.options.length > 1) {
            select.remove(1);
        }
    }

    function setProvinceField() {

        for (const [id, provincia] of Object.entries(crGeo.provincias)) {
            console.log(`${id}: ${provincia}`);
            const op = document.createElement('option')
            op.value = id
            op.innerHTML = provincia.nombre
            provinceField.add(op)
        }

    }

    function setCantonField() {

        for (const [id, canton] of Object.entries(crGeo.provincias[provinceField.value].cantones)) {
            console.log(`${id}: ${canton}`);
            const op = document.createElement('option')
            op.value = id
            op.innerHTML = canton.nombre
            cantonField.add(op)
        }
    }

    function setDistrictField(cantonId) {


        for (const [id, distrito] of Object.entries(crGeo.provincias[provinceField.value].cantones[cantonField.value].distritos)) {
            console.log(`${id}: ${distrito}`);
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
        console.log(formData)
    }

    getCRGeo()

}())