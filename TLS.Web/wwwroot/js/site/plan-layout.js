// menu js
const openMenu = document.querySelector(".open-menu");
const closeMenu = document.querySelector(".close-menu");
const mobileMenu = document.querySelector(".mobile-menu");

// slider js
openMenu.addEventListener("click", function () {
    mobileMenu.classList.add("open");
});

closeMenu.addEventListener("click", function () {
    mobileMenu.classList.remove("open");
});

$(".owl-carousel").owlCarousel({
    loop: true,
    margin: 10,
    items: 1,
});

// collapse js
document.addEventListener("DOMContentLoaded", function () {
    const buttons = document.querySelectorAll("[data-accordion-target]");

    buttons.forEach((button) => {
        button.addEventListener("click", () => {
            const target = document.querySelector(
                button.getAttribute("data-accordion-target")
            );
            const expanded =
                button.getAttribute("aria-expanded") === "true" || false;

            target.classList.toggle("hidden");
            button.setAttribute("aria-expanded", !expanded);
        });
    });
});