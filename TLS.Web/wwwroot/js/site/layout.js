$(document).ready(() => {
    const toggleBtn = document.querySelector(".sidebar-toggle");
    const closebtn = document.querySelector(".close-btn");
    const sidebar = document.querySelector(".sidebar");
    const btnSwitch = document.querySelector(".switch-btn button")

    if ($("#select_lg_ctrl").val() == 'vi') {
        btnSwitch.textContent = 'VN';
    } else {
        btnSwitch.textContent = 'ENG';
    }

    btnSwitch.addEventListener("click", function () {
        const initialText = 'ENG';

        if (btnSwitch.textContent.includes(initialText)) {
            btnSwitch.textContent = 'VN';
        } else {
            btnSwitch.textContent = initialText;
        }
        changeLanguage(btnSwitch.textContent);
    });

    const changeLanguage = function (culture) {
        if (culture == "VN") {
            document.getElementById("select_lg_ctrl").selectedIndex = 1;
        } else {
            document.getElementById("select_lg_ctrl").selectedIndex = 0;
        }
        document.getElementById("change_language_form").submit();

    }


    toggleBtn.addEventListener("click", function () {
        sidebar.classList.toggle("show-sidebar");
    });

    closebtn.addEventListener("click", function () {
        sidebar.classList.remove("show-sidebar");
    });
})