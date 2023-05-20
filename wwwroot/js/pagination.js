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
        return data; // Return the fetched data
    } catch (error) {
        console.error("An error occurred while fetching courses:", error);
    }
}




function renderPage(pageNumber) {
    // Get the entries for the given page number
    const pageEntries = paginatedEntries[pageNumber - 1];

    // Create an HTML string for the entries
    const entriesHtml = pageEntries.map(entry => `
    <div class="cssCourses">
      <div style="left: 25px; position:absolute;" id="coursesName">
        <p style="font-size: 18px;"><b>${entry.ModuleName}</b></p>
      </div>
      <div style="left: 25px; position:absolute; top:20%" id="coursesSxoli">
        <p style="font-size: 12px;"><b>Σχολή: </b>${entry.ModuleName}</p>
      </div>
      <div style="left: 25px; position:absolute; top:30%" id="coursesCode">
        <p style="font-size: 12px;"><b>Κωδικός Μαθήματος: </b>${entry.idModules}</p>
      </div>
      <div style="left: 25px; position:absolute; top:40%" id="coursesTeacher">
        <p style="font-size: 12px;"><b>Διδάσκοντες:</b> ${entry.ModuleLeader.join(", ")}</p>
      </div>
      <div style="left: 25px; position:absolute; top:70%" id="coursesRating">
        ${renderRating(entry.Rating)}
      </div>
    </div>
  `).join("");

    // Update the courses container with the entries HTML
    const coursesContainer = document.getElementById("coursesContainer");
    coursesContainer.innerHTML = entriesHtml;
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
