using BlazorProject.Models;
using System.Net.Http.Json;

namespace BlazorProject.Pages
{
    public partial class Movies
    {
        private Movie[] movies;
        private string search;
        private string message;
        private bool error = false;

        protected async Task Search()
        {
            Reset();
            search = search.Trim();
            if (search.Length < 2 || search.Length > 15)
            {
                message = "Zoekterm moet tussen 2 en 15 karakters lang zijn.";
                error = true;
                return;
            }

            var response = await Http.GetAsync($"https://www.omdbapi.com/?s={search}&type=movie&apikey={MyApi.APIKEY}");
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var wrapper = await response.Content.ReadFromJsonAsync<MovieWrapper>();
                    if (wrapper.Search == null) movies = new Movie[0];
                    else movies = wrapper.Search;
                    message = $"Aantal gevonden: {movies.Length}";
                    error = false;
                }
                catch (Exception ex)
                {
                    message = $"Error: {ex.Message}";
                    error = true;
                }
            }
            else
            {
                message = $"Error status code: {response.StatusCode}";
                error = true;
            }
        }

        protected void Reset()
        {
            movies = new Movie[0];
            message = "";
            error = false;
        }
    }
}
