async function fetchMangaDetails() {
    const urlParams = new URLSearchParams(window.location.search);
    const mangaId = urlParams.get('id');

    try {
        const response = await fetch(`https://localhost:7162/api/Manga/id?id=${mangaId}`);

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const manga = await response.json();
        displayMangaDetails(manga);

    } catch (error) {
        console.error('Error fetching manga details:', error);
    }
}

function displayMangaDetails(manga) {
    const mangaDetails = document.getElementById('container');
    mangaDetails.innerHTML = `
            <div class="panel">
                <div class="left-panel">
                    <img src="/Assert/Image/${manga.data.coverImage}" alt="${manga.data.title}" onerror="this.onerror=null;this.src='https://www.peeters-leuven.be/covers/no_cover.gif';" width="220" height="300"> 
                </div>
                <div class="right-panel">
                    <div class="manga-detail">
                        <div class="manga-detail-information">
                        <div class="manga-detail-information-item">
                            <h2>${manga.data.title}</h2>
                        </div>
                        <div class="manga-detail-information-item">
                            <div class="item-title"><i class="fa-solid fa-plus"></i>Tên khác:</div>
                            <div class="item-value">${manga.data.alternateTitle}</div>
                        </div>
                        <div class="manga-detail-information-item">
                            <div class="item-title"><i class="fa-solid fa-user"></i>Tác giả:</div>
                            <div class="item-value">${manga.data.author}</div>
                        </div>
                        <div class="manga-detail-information-item">
                            <div class="item-title"><i class="fa-solid fa-wifi"></i>Tình trạng:</div>
                            <div class="item-value">${manga.data.status}</div>
                        </div>
                        <div class="manga-detail-information-item">
                            <div class="item-title"><i class="fa-solid fa-calendar-days"></i>Ngày phát hành:</div>
                            <div class="item-value">${manga.data.releaseDate}</div>
                        </div>
                        </div>
                    </div>
                </div>
        </div>
        <div class="description">
            <h2>Giới thiệu</h2>
            <p>${manga.data.description}</p>
        </div>
    `;
}

window.onload = fetchMangaDetails;