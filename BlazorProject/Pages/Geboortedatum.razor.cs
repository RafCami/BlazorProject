namespace BlazorProject.Pages
{
    public partial class Geboortedatum
    {
        private DateTime? SelectedDate { get; set; }
        private string maxDate = $"{DateTime.Now.Year}-{DateTime.Now.Month}-";

        protected override void OnInitialized()
        {
            if (DateTime.Now.Day < 10) maxDate += $"0{DateTime.Now.Day}";
            else maxDate += $"{DateTime.Now.Day}";
        }

        protected async Task LookupFacts()
        {
            if (SelectedDate >= new DateTime(1970, 1, 1) && SelectedDate <= DateTime.Now)
            {
                await LocalStorageAccessor.SetValueAsync("SelectedDate", SelectedDate);
                NavManager.NavigateTo("funfacts");
            }
        }
    }
}
