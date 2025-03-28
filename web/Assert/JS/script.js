// JavaScript code can be added here for interactivity or dynamic content.
const animeEl = document.getElementById("anime-list");
const searchEl = document.getElementById("search-input");
const formEl = document.getElementById("form");

formEl.addEventListener('submit', async(e) => {
  // prevent default form behaviour
   e.preventDefault()

  let searchString = searchEl.value;

  try {
    const res = await fetch(`https://localhost:7162/api/Manga/id?id=${searchString}`);
    const data = await res.json();
    console.log(data)

    const animeCardHTML = generateAnimeCard(data);
    animeEl.innerHTML = animeCardHTML;
  } catch (err) {
    console.log(err);
    animeEl.innerHTML = `<p>${err}</p>`;
  }
})
  function generateAnimeCard(data) {
    return `
      <div class="anime-card">
        <div class="anime-image">
        <img src="../Image/default.jpeg" class="anime-img">
        </div>
        <div class="anime-details">
        <h3 class="anime-title">${data.data.title}</h3>
        <span class="anime-type">${data.data.authorId}</span>
        <p class="anime-description">${data.data.description}</p>
        <p class="anime-rating">${data.data.status}</p>
        <p class="anime-year">${data.data.releaseDate}</p>
        </div>
      </div>
    `;
  }

//truncate function
  function truncateText(text, maxLength) {
    if (text.length > maxLength) {
      return text.slice(0, maxLength) + "...";
    }
    return text;
  }

// simple form submission handling.

const subscribeForm = document.getElementById("subscribe-form");

subscribeForm.addEventListener("submit", (event) => {
  event.preventDefault();
  const email = event.target.querySelector("input[type='email']").value;
  // You can handle the form submission, e.g., send the email to a server, etc.
  console.log(`Subscribed with email: ${email}`);
  event.target.reset();
});