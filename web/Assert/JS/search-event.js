// JavaScript code can be added here for interactivity or dynamic content.
const animeElSearch = document.getElementById("anime-list");
const searchEl = document.getElementById("search-input");
const formEl = document.getElementById("form");

formEl.addEventListener('submit', async(e) => {
  // prevent default form behaviour
   e.preventDefault()

  //let searchString = searchEl.value;
  window.location.href = `search.html?manga=${searchEl.value}`;

  try {

  } catch (err) {
    console.log(err);
    animeElSearch.innerHTML = `<p>${err}</p>`;
  }
})