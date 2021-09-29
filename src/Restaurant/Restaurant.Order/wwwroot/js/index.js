(function (w, d) {
    "use strict";

    function getDomElements() {
        const inputDishes = d.getElementById("inputDishes");
        const outputDishes = d.getElementById("outputDishes");
        const formDishes = d.getElementById("formDishes");
        formDishes.addEventListener("submit", async function (ev) {
            ev.preventDefault();
            const input = inputDishes.value;
            const output = await execute(input.replace(/\s/g, ''));
            outputDishes.value = output;
        }, true);
    }

    function validateInput(input) {
        if (!input) return "";
        validateTimeOfDay(input[0]);
        validateValues(input.slice(1));
    }

    const validTimeOfDayValues = ["morning", "night"];
    function validateTimeOfDay(timeOfDay) {
        if (typeof timeOfDay !== 'string')
            throw new Error(`The first element on input should be equals to "${validTimeOfDayValues.join(" or ")}"`);

        const isValidTimeOfDay = validTimeOfDayValues.filter(v => v.toLowerCase() == timeOfDay.toLowerCase());

        if (isValidTimeOfDay && isValidTimeOfDay.length === 0)
            throw new Error(`The first element on input should be equals to "${validTimeOfDayValues.join(" or ")}"`);
    }

    function validateValues(values) {
        const containsNan = values.filter(v => isNaN(v));
        if (containsNan && containsNan.length !== 0)
            throw new Error(`After "${validTimeOfDayValues.join(" or ")}" should contain only numbers`);
    }

    async function getDishes(input) {
        const url = location.origin + "/api/Orders/" + input[0].toLowerCase();
        const data = input.slice(1).map(i => parseInt(i));
        const options = {
            method: "POST",
            body: JSON.stringify(data),
            headers: { "accept": "*/*", "Content-type": "application/json" }
        };

        const response = await fetch(url, options);
        return response.json();
    }

    async function execute(input) {
        try {
            const inputList = input.split(',');
            validateInput(inputList);
            const dishes = await getDishes(inputList);
            return dishes.join(", ");
        } catch (e) {
            alert(e.message);
            return "";
        }
    }

    w.onload = function onLoad() {
        getDomElements();
    };
}(window, document));