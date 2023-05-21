const entriesPerPage = 10;
let allEntries = [];
let totalPages;
let paginatedEntries;

async function fetchCourses(url) {
    try {
        const response = await fetch(url);
        if (!response.ok) {
            console.error("Server returned an error:", await response.text());
            return;
        }
        const data = await response.json();
        console.log("Fetched courses:", data); // Add this line to log the fetched data
        return data; // Return the fetched data
    } catch (error) {
        console.error("An error occurred while fetching courses:", error);
    }
}




function renderPage(pageNumber) {
    console.log(`Rendering page ${pageNumber}`); // Log the rendered page number

    // Get the entries for the given page number
    const pageEntries = paginatedEntries[pageNumber - 1];

    // Create an HTML string for the entries
    const entriesHtml = pageEntries.map(entry => `
    <div class="cssCourses">
        <div id="coursesName">
            <p style="font-size: 18px;"><b>${entry.ModuleName}</b></p>
        </div>
        <div id="coursesSxoli">
            <p style="font-size: 12px;"><b>Σχολή: </b>${entry.ModuleName}</p>
        </div>
        <div id="coursesCode">
            <p style="font-size: 12px;"><b>Κωδικός Μαθήματος: </b>${entry.idModules}</p>
        </div>
        <div id="coursesTeacher">
            <p style="font-size: 12px;"><b>Διδάσκοντες:</b> ${entry.ModuleLeader}</p>
        </div>
        <div id="coursesRating">
            ${renderRating(entry.Rating)}
        </div>
    </div>
  `).join("");

    console.log(`Generated HTML content: ${entriesHtml}`); // Log the generated HTML content

    // Update the courses container with the entries HTML
    const coursesContainer = document.getElementById("coursesContainer");
    if (coursesContainer) {
        coursesContainer.innerHTML = entriesHtml;
    } else {
        console.error('coursesContainer not found'); // Log an error if the coursesContainer is not found
    }
}



function renderRating(rating) {
    const fullStar = '<span class="fa fa-star"></span>';
    const emptyStar = '<span class="fa fa-star-o"></span>';
    const ratingHtml = [];

    for (let i = 0; i < 5; i++) {
        if (i < rating) {
            ratingHtml.push(fullStar);
        } else {
            ratingHtml.push(emptyStar);
        }
    }

    return ratingHtml.join("");
}


let currentPage = 1;

function goToPage(pageNumber) {
    console.log(`Going to page ${pageNumber}`); // Add this line to log the goToPage function call

    if (pageNumber < 1 || pageNumber > totalPages) return;

    currentPage = pageNumber;
    renderPage(currentPage);
}


function init() {
    fetchCourses('http://localhost:7043/Home/GetAllCoursesFinal').then(courses => {
        allEntries = courses; // Set allEntries to the fetched courses
        totalPages = Math.ceil(allEntries.length / entriesPerPage); // Calculate the total number of pages
        paginatedEntries = Array.from({ length: totalPages }, (_, i) => allEntries.slice(i * entriesPerPage, (i * entriesPerPage) + entriesPerPage)); // Create an array of paginated entries
        renderPage(1); // Render the first page of entries
    });
}

// Call the init function when the page has loaded
window.addEventListener("DOMContentLoaded", init);
window.currentPage = currentPage;
window.totalPages = totalPages;
window.goToPage = goToPage;

