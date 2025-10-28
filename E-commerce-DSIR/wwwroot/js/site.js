document.addEventListener("DOMContentLoaded", function () {
    varsidebar = document.getElementById("sidebar");
    varmainContent = document.getElementById("mainContent");
    vartoggleButton = document.getElementById("toggleMenu");
    // Gérer l'affichage du menu au clic
    toggleButton.addEventListener("click", function () {
        if (sidebar.style.display === "none") {
            sidebar.style.display = "block";
            mainContent.classList.remove("col-md-12");
            mainContent.classList.add("col-md-10");
        } else {
            sidebar.style.display = "none";
            mainContent.classList.remove("col-md-10");
            mainContent.classList.add("col-md-12");
        }
    });
});
