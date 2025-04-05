// JavaScript code can be added here for interactivity or dynamic content.
const animeEl = document.getElementById("anime-list");

async function fetchAllMangas() {
  const urlParams = new URLSearchParams(window.location.search);
  const mangaTitle = urlParams.get('manga');
  let response
  if (mangaTitle == "") {
    response = await fetch(`https://localhost:7162/api/Manga`);
  } else {
    response = await fetch(`https://localhost:7162/api/Manga/nameTitle?nameTitle=${mangaTitle}`);
  }

  try {

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
  if (mangas.data.length == 0) {
    const h1Item = document.createElement('h1');
    h1Item.textContent = "Không Tìm Thấy Kết Quả Nào!"
    animeEl.style.display = "block";
    animeEl.appendChild(h1Item);
  } else {
    mangas.data.forEach(manga => {
        const mangaItem = document.createElement('div');
        mangaItem.classList.add('anime-card');
        mangaItem.innerHTML = `
            <img src="/Assert/Image/${manga.coverImage}" alt="${manga.title}" onerror="this.onerror=null;this.src='https://www.peeters-leuven.be/covers/no_cover.gif';" width="220" height="300" >
            <h3>${manga.title}</h3>
        `;
        mangaItem.addEventListener('click', function() {
            window.location.href = `manga-detail.html?id=${manga.mangaId}`;
        });
        
        animeEl.appendChild(mangaItem);
    });
  }
}

// Gọi hàm fetchAllMangas khi trang web được tải
window.onload = fetchAllMangas;