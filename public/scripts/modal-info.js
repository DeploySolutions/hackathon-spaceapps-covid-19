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
    // Get the modal
    var modal = document.getElementById("myModal");

    // Get the button that opens the modal
    var btn = document.getElementById("myBtn");

    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[0];

    // When the user clicks the button, open the modal 
    btn.onclick = function() {
    modal.style.display = "block";
    }

    // When the user clicks on <span> (x), close the modal
    span.onclick = function() {
    modal.style.display = "none";
    }

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function(event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
    const infoButtons = document.querySelectorAll('.info');
    var modal = document.getElementById("myModal");
    
    infoButtons.forEach((e, i) => {
        e.addEventListener("click", function() {
            document.getElementById('innerModal').innerHTML = `<h2>${info[i].h2}</h2><p>${info[i].text}</p>`
            modal.style.display = "block";
        });
    });
});
 