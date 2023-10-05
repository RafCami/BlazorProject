namespace BlazorProject.Pages
{
    public partial class ToonFoto
    {
        List<string> fotos = new List<string>() { "breakfast", "flower", "flower_red", "fontain", "lunch", "sunset" };
        int x = 0;

        private void ChangeFoto()
        {
            Random rnd = new Random();
            int oldX = x;
            do
            {
                x = rnd.Next(0, fotos.Count);
            } while (oldX == x);
        }
    }
}
