using System.Globalization;

namespace BlazorProject.Pages
{
    public partial class FunFacts
    {
        private List<string> Results { get; set; } = new List<string>();

        protected override async Task OnInitializedAsync()
        {
            string storage = await LocalStorageAccess.GetValueAsync<string>("SelectedDate");
            if (!DateTime.TryParse(storage, out DateTime geboortedatum)) return;
            Results.Add($"Vandaag is het {DateTime.Now.ToString("dddd dd MMMM yyyy", new CultureInfo("nl-BE"))}");
            Results.Add($"Je bent geboren op {geboortedatum.ToString("dddd dd MMMM yyyy", new CultureInfo("nl-BE"))}");
            Results.Add($"Je loopt al {Math.Floor((DateTime.Now - geboortedatum).TotalDays)} dagen op deze wereldbol rond.");
            Results.Add($"Je zal vermoedelijk sterven op {geboortedatum.AddDays((80.3 * 365.25)).ToString("dddd dd MMMM yyyy", new CultureInfo("nl-BE"))}");
        }
    }
}
