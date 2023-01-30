
var empInput = document.getElementById("ESSN");
var ProjectsArea = document.getElementById("projectsArea");
var proInput = document.getElementById("proNumber");
var hourArea = document.getElementById("hourArea");



empInput.addEventListener("change", async () => {
    var projectsResult = await fetch("http://localhost:5006/Works_On/EditEmpHour_emp/" + empInput.value)
    projectList = await projectsResult.text();
    console.log(projectList);
    console.log(proInput);

    ProjectsArea.innerHTML = projectList;
    proInput = document.getElementById("proNumber");
    proNumber.addEventListener("change", async () => {

        console.log(proNumber);
        var hourResult = await fetch("http://localhost:5006/Works_On/EditEmpHour_empPro/" + empInput.value + "?proNumber=" + proNumber.value);
        hour = await hourResult.text();
        hourArea.innerHTML = hour;
    })
});