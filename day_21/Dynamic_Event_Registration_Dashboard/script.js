// Event Data (Client Side Only)
let events = [
  { id: 1, name: "Yoga Workshop", date: "10 Feb 2026", participants: 15, registered: false },
  { id: 2, name: "Music Night", date: "12 Feb 2026", participants: 25, registered: false },
  { id: 3, name: "Chess Tournament", date: "15 Feb 2026", participants: 10, registered: false },
  { id: 4, name: "Cooking Class", date: "18 Feb 2026", participants: 18, registered: false }
];

const eventContainer = document.getElementById("eventContainer");

// Function to Display Events Dynamically
function displayEvents() {
  eventContainer.innerHTML = ""; // clear container

  events.forEach((event) => {
    // Create card
    let card = document.createElement("div");
    card.className = "event-card";

    // Event Name
    let title = document.createElement("h2");
    title.textContent = event.name;

    // Event Date
    let date = document.createElement("p");
    date.textContent = "📅 Date: " + event.date;

    // Participants Count
    let count = document.createElement("p");
    count.innerHTML = `👥 Participants: <span class="count">${event.participants}</span>`;

    // Button
    let button = document.createElement("button");

    if (event.registered) {
      button.textContent = "Unregister";
      button.className = "unregister";
    } else {
      button.textContent = "Register";
      button.className = "register";
    }

    // Button Click Event
    button.onclick = function () {
      toggleRegistration(event.id);
    };

    // Append all elements to card
    card.appendChild(title);
    card.appendChild(date);
    card.appendChild(count);
    card.appendChild(button);

    // Append card to container
    eventContainer.appendChild(card);
  });
}

// Toggle Register/Unregister
function toggleRegistration(eventId) {
  events = events.map((event) => {
    if (event.id === eventId) {
      if (event.registered) {
        // Unregister
        event.participants--;
        event.registered = false;
      } else {
        // Register
        event.participants++;
        event.registered = true;
      }
    }
    return event;
  });

  displayEvents(); // refresh UI dynamically
}

// Initial Load
displayEvents();
