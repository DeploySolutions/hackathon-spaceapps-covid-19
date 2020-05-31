const info = [
    {
        h2: 'Night Moves',
        text: 'This is the general explanation'
    },
    {
        h2: 'Regions',
        text: 'This is the regions text'
    },
    {
        h2: 'Case Type',
        text: 'This is the case type text'
    },
    {
        h2: 'Polution',
        text: 'NO2 is a common air pollutant. Prolonged NO2 exposure is known to incease mortality rates in those experiencing COVID-19. Further, recently studies suggest that SARS-COV-2 (the virus that causes COVID-19) can survive in the air on particulate matter (i.e., gasious and solid air pollution). This chart allows users to visually correlate air polution with COVID-19 cases'
    }
]

document.addEventListener("DOMContentLoaded", function() {
 
    const infoButtons = document.querySelectorAll('.info');
    var modal = document.getElementById("myModal");
    
    infoButtons.forEach((e, i) => {
        e.addEventListener("click", function() {
            document.getElementById('innerModal').innerHTML = `<h2>${info[i].h2}</h2><p>${info[i].text}</p>`
            modal.style.display = "block";
        });
    });
});
 