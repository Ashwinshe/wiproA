// Get button reference
const btn = document.getElementById("locBtn");
const resultDiv = document.getElementById("result");

// Step 4: Add Event using JS (best practice)
btn.addEventListener("click", getLocation);

// Step 5: Use Geolocation
function getLocation() {
    resultDiv.innerHTML = `<div class="text-info">Fetching location...</div>`;

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition, showError);
    } else {
        resultDiv.innerHTML = `
            <div class="alert alert-danger">
                Geolocation is not supported by this browser.
            </div>
        `;
    }
}

// Step 6: Show Result
function showPosition(position) {
    const lat = position.coords.latitude;
    const lon = position.coords.longitude;

    resultDiv.innerHTML = `
        <div class="alert alert-success">
            <strong>Latitude:</strong> ${lat} <br>
            <strong>Longitude:</strong> ${lon}
        </div>
    `;
}

// Step 7: Handle Error
function showError(error) {
    let message = "";

    switch(error.code) {
        case error.PERMISSION_DENIED:
            message = "User denied the request for Geolocation.";
            break;
        case error.POSITION_UNAVAILABLE:
            message = "Location information is unavailable.";
            break;
        case error.TIMEOUT:
            message = "The request to get user location timed out.";
            break;
        default:
            message = "An unknown error occurred.";
    }

    resultDiv.innerHTML = `
        <div class="alert alert-warning">
            ${message}
        </div>
    `;
}
