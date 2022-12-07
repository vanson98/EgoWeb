const toggleBtn = document.querySelector(".sidebar-toggle");
const closebtn = document.querySelector(".close-btn");
const sidebar = document.querySelector(".sidebar");
const btnSwitch = document.querySelector(".switch-btn button")

btnSwitch.addEventListener("click", function () {
    const initialText = 'ENG';

    if (btnSwitch.textContent.includes(initialText)) {
        btnSwitch.textContent = 'VN';
    } else {
        btnSwitch.textContent = initialText;
    }
});

toggleBtn.addEventListener("click", function () {
    sidebar.classList.toggle("show-sidebar");
});

closebtn.addEventListener("click", function () {
    sidebar.classList.remove("show-sidebar");
});