
// SPA Page Loader (Fetch)

function loadPage(page) {
  fetch(`pages/${page}.html`)
    .then(res => res.text())
    .then(html => {
      document.getElementById("content").innerHTML = html;

      if (page === "home") {
        showLocation();
      }

      if (page === "services") {
        setupServiceEvents();
      }

      if (page === "booking") {
        setupBookingForm();
      }
    })
    .catch(() => {
      document.getElementById("content").innerHTML = "<h2>Error Loading Page</h2>";
    });
}

// Geolocation (Module 3 Feature)

function showLocation() {
  const locationBox = document.getElementById("locationBox");

  if (!locationBox) return;

  if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(
      (position) => {
        locationBox.innerHTML = `
           Your Location Detected <br>
          Latitude: ${position.coords.latitude} <br>
          Longitude: ${position.coords.longitude}
        `;
      },
      () => {
        locationBox.innerHTML = "Location permission denied.";
      }
    );
  } else {
    locationBox.innerHTML = "Geolocation not supported.";
  }
}


// Fetch Services JSON (AJAX)
const fetchServices = async () => {
  try {
    const res = await fetch("data/services.json");
    const services = await res.json();
    return services;
  } catch (error) {
    console.log("Error fetching services:", error);
    return [];
  }
};


// Render Services using Template Literals

const renderServices = (services) => {
  const serviceList = document.getElementById("serviceList");
  if (!serviceList) return;

  let html = "";

  services.forEach(({ id, name, price, rating }) => {
    html += `
      <div class="col-md-4">
        <div class="card shadow-sm h-100">
          <div class="card-body">
            <h5 class="card-title">${name}</h5>
            <p class="card-text">Price: ₹${price}</p>
            <p class="card-text">Rating:  ${rating}</p>

            <button class="btn btn-primary bookBtn" data-service="${name}">
              Book Now
            </button>
          </div>
        </div>
      </div>
    `;
  });

  serviceList.innerHTML = html;
};


// Services Page Events

function setupServiceEvents() {
  const loadBtn = document.getElementById("loadServicesBtn");

  loadBtn.addEventListener("click", async () => {
    const services = await fetchServices();
    renderServices(services);
  });
}


// jQuery Event Delegation

$(document).on("click", ".bookBtn", function () {
  const serviceName = $(this).data("service");
  alert("Booking started for: " + serviceName);

  // auto redirect to booking page
  loadPage("booking");

  // store selected service in localStorage
  localStorage.setItem("selectedService", serviceName);
});


// Booking Form Handling

function setupBookingForm() {
  const form = document.getElementById("bookingForm");

  // auto-fill selected service
  const selectedService = localStorage.getItem("selectedService");
  if (selectedService) {
    document.getElementById("serviceType").value = selectedService;
  }

  form.addEventListener("submit", (event) => {
    event.preventDefault();

    if (!form.checkValidity()) {
      event.stopPropagation();
      form.classList.add("was-validated");
      return;
    }

    const name = document.getElementById("custName").value;
    const phone = document.getElementById("custPhone").value;
    const service = document.getElementById("serviceType").value;
    const date = document.getElementById("bookingDate").value;
    const address = document.getElementById("custAddress").value;

    const bookingDate = new Date(date);

    if (bookingDate < new Date()) {
      alert("Booking date must be future date!");
      return;
    }

    const bookingData = {
      name,
      phone,
      service,
      date: bookingDate.toDateString(),
      address
    };

    console.log("Booking Submitted:", bookingData);

    document.getElementById("bookingMsg").innerHTML =
      ` Booking Confirmed for ${service} on ${bookingData.date}`;

    form.reset();
    form.classList.remove("was-validated");
  });
}


// Default Load Home Page

window.onload = () => {
  loadPage("home");
};
