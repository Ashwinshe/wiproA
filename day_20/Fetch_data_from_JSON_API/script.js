function getUser() {
    fetch("https://randomuser.me/api/")
        .then(response => response.json())
        .then(data => {

            const user = data.results[0];

            document.getElementById("user").innerHTML = `
                <h3>${user.name.first} ${user.name.last}</h3>
                <p>Email: ${user.email}</p>
                <img src="${user.picture.medium}" alt="User Image">
            `;
        })
        .catch(error => {
            console.error("Error:", error);
        });
}
