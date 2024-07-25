document.addEventListener('DOMContentLoaded', () => {
    const linkColor = document.querySelectorAll('.nav__link');
    const dashboardLink = document.getElementById('dashboard-link');

    //function colorLink() {
    //    linkColor.forEach(l => l.classList.remove('active'));
    //    this.classList.add('active');
    //    // Store the active link index in localStorage
    //    localStorage.setItem('activeLink', [...linkColor].indexOf(this));
    //}

    function colorLink() {
        linkColor.forEach(l => l.classList.remove('active'));
        this.classList.add('active');
        // Store the active link id in localStorage
        localStorage.setItem('activeLinkId', this.id);
    }

    //// Add event listeners to each link
    //linkColor.forEach(l => l.addEventListener('click', colorLink));


    // Add event listeners to each link
    linkColor.forEach(l => l.addEventListener('click', colorLink));


    //// Retrieve and apply the active link from localStorage
    //const activeLinkIndex = localStorage.getItem('activeLink');
    //if (activeLinkIndex !== null) {
    //    linkColor[activeLinkIndex].classList.add('active');
    //} else {
    //    // Default to Dashboard link if no active link is set
    //    dashboardLink.classList.add('active');
    //}

    // Retrieve and apply the active link from localStorage
    const activeLinkId = localStorage.getItem('activeLinkId');
    if (activeLinkId !== null) {
        const activeLink = document.getElementById(activeLinkId);
        if (activeLink) {
            activeLink.classList.add('active');
        } else {
            // If the stored active link ID doesn't exist (possibly due to changes in HTML),
            // default to setting the dashboard link as active
            dashboardLink.classList.add('active');
            localStorage.setItem('activeLinkId', 'dashboard-link');
        }
    } else {
        // Default to Dashboard link if no active link is set
        dashboardLink.classList.add('active');
        localStorage.setItem('activeLinkId', 'dashboard-link');
    }


    const switchMode = document.getElementById('switch-mode');

    switchMode.addEventListener('change', function () {
        if (this.checked) {
            document.body.classList.add('dark');
            // Store dark mode state in localStorage
            localStorage.setItem('darkMode', 'true');
        } else {
            document.body.classList.remove('dark');
            localStorage.setItem('darkMode', 'false');
        }
    });

    // Retrieve and apply the dark mode state from localStorage
    const darkMode = localStorage.getItem('darkMode');
    if (darkMode === 'true') {
        document.body.classList.add('dark');
        switchMode.checked = true;
    } else {
        document.body.classList.remove('dark');
        switchMode.checked = false;
    }

    
});
const menuBar = document.querySelector('#content nav .nav__toggle');
const sidebar = document.getElementById('sidebar');

menuBar.addEventListener('click', function () {
    sidebar.classList.toggle('hide');
});
function updateClock() {
    const now = new Date();
    const hours = now.getHours().toString().padStart(2, '0');
    const minutes = now.getMinutes().toString().padStart(2, '0');
    const seconds = now.getSeconds().toString().padStart(2, '0');
    const ampm = hours >= 12 ? 'PM' : 'AM';
    const hours12 = hours % 12 || 12;
    const timeString = `${hours12}:${minutes}:${seconds} ${ampm}`;
    document.getElementById('clock').textContent = timeString;

   
}
setInterval(updateClock, 1000);
updateClock();


/*===== COLLAPSE MENU  =====*/
const linkCollapse = document.getElementsByClassName('collapse__link')
var i

for (i = 0; i < linkCollapse.length; i++) {
    linkCollapse[i].addEventListener('click', function () {
        const collapseMenu = this.nextElementSibling
        collapseMenu.classList.toggle('showCollapse')

        const rotate = collapseMenu.previousElementSibling
        rotate.classList.toggle('rotate')
    })
}




