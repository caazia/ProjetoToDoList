//let btnCompletar = document.querySelector('.btnCompletar');

//btnCompletar.addEventListener("click", function () {

// console.log("clicou");
//    todolist.Status = "Concluído";
//    window.location.href = "/Index";

//});

const btnCompletar = document.querySelectorAll('.btnCompletar');

btnCompletar.forEach((e, textContent) => {

    e.addEventListener('click', (ev) => {
        ev.preventDefault();
        console.log("botão clicado", textContent);
    });
});

//btnCompletar.addEventListener("click", function () {

// console.log("clicou");
//    todolist.Status = "Concluído";
//    window.location.href = "/Index";

//});


