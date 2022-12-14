$(document).ready(() => {
    const toggleBtn = document.querySelector(".sidebar-toggle");
    const closebtn = document.querySelector(".close-btn");
    const sidebar = document.querySelector(".sidebar");
    const btnSwitch = document.querySelector(".change-lg-btn")
    const btnSwitch2 = document.querySelector(".change-lg-btn2")

    if ($("#select_lg_ctrl").val() == 'vi') {
        btnSwitch.textContent = 'ENG';
        btnSwitch2.textContent = 'ENG';
    } else {
        btnSwitch.textContent = 'VN';
        btnSwitch2.textContent = 'VN';
    }

    btnSwitch.addEventListener("click", function () {
        const initialText = 'ENG';

        if (btnSwitch.textContent.includes(initialText)) {
            btnSwitch.textContent = initialText;
        } else {
            
            btnSwitch.textContent = 'VN';
        }
        changeLanguage(btnSwitch.textContent);
    });

    btnSwitch2.addEventListener("click", function () {
        const initialText = 'ENG';

        if (btnSwitch2.textContent.includes(initialText)) {
            
            btnSwitch2.textContent = initialText;
        } else {
            btnSwitch2.textContent = 'VN';
        }
        changeLanguage(btnSwitch2.textContent);
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

    AOS.init();
})