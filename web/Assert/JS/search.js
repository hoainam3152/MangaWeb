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
  function generateAnimeCard(manga) {
    return `
      <div class="anime-card">
        <div class="anime-image">
        <img src="/Assert/Image/${manga.data.coverImage}" class="anime-img">
        </div>
        <div class="anime-details">
        <h3 class="anime-title">${manga.data.title}</h3>
        <span class="anime-type">${manga.data.authorId}</span>
        <p class="anime-description">${manga.data.description}</p>
        <p class="anime-rating">${manga.data.status}</p>
        <p class="anime-year">${manga.data.releaseDate}</p>
        </div>
      </div>
    `;
  }