// JavaScript code can be added here for interactivity or dynamic content.
const animeEl = document.getElementById("anime-list");
const searchEl = document.getElementById("search-input");
const formEl = document.getElementById("form");

formEl.addEventListener('submit', async(e) => {
  // prevent default form behaviour
   e.preventDefault()

  let searchString = searchEl.value;

  try {

  } catch (err) {
    console.log(err);
    animeEl.innerHTML = `<p>${err}</p>`;
  }
})

async function fetchAllMangas() {
  try {
      const response = await fetch('https://localhost:7162/api/Manga');

      if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
      }

      const mangas = await response.json();

      displayMangas(mangas);

  } catch (error) {
      console.error('Error fetching mangas:', error);
  }
}

function displayMangas(mangas) {
  animeEl.innerHTML = ''; // Xóa nội dung cũ
  mangas.data.forEach(manga => {
      const mangaItem = document.createElement('div');
      mangaItem.classList.add('anime-card');
      mangaItem.innerHTML = `
          <img src="/Assert/Image/${manga.coverImage}" alt="${manga.title}" width="200" height="300">
          <h3>${manga.title}</h3>
      `;
      mangaItem.addEventListener('click', function() {
          window.location.href = `manga-detail.html?id=${manga.mangaId}`;
      });
      
      animeEl.appendChild(mangaItem);
  });
}

// Gọi hàm fetchAllMangas khi trang web được tải
window.onload = fetchAllMangas;