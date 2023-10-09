namespace BlazorProject.Pages
{
    public partial class Dobbelen
    {
        private bool[] isWinner = new bool[12];
        private string guessInput = "";
        private string result = "";

        protected override async Task OnInitializedAsync()
        {
            ResetArray();
        }

        private void ResetArray()
        {
            for (int i = 0; i < isWinner.Length; i++)
            {
                isWinner[i] = false;
            }
        }

        private void Reset()
        {
            ResetArray();
            guessInput = "";
            result = "";

        }

        private void Play()
        {
            if (!int.TryParse(guessInput, out int guess) || guess < 1 || guess > 12) return;
            ResetArray();
            int winners = 0;

            for (int i = 0; i < isWinner.Length; i++)
            {
                if (new Random().Next(1, 7) == 6)
                {
                    isWinner[i] = true;
                    winners++;
                }
            }

            result = $"{winners} speler(s) gooide een 6. {((winners == guess) ? "Gewonnen. Juist" : "Verloren. Fout")} geraden!";

        }
        
        private void PlayToXWinners()
        {
            if (!int.TryParse(guessInput, out int guess) || guess < 0 || guess > 12) return;
            ResetArray();
            int rolls = 0;
            int winners = 0;

            do
            {
                if (new Random().Next(1, 7) == 6)
                {
                    isWinner[winners] = true;
                    winners++;
                }
                rolls++;
            } while (winners < guess);

            result = $"{winners} speler(s) gooide een 6 na {Math.Ceiling((double)rolls / (double)12)} rondes.";

        }
    }
}
