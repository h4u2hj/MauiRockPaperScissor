using System.Data;

namespace RockPaperScissor
{
    public partial class MainPage : ContentPage
    {
        private int playerChoice;
        private int computerChoice;
        private int playerScore = 0;
        private int computerScore = 0;
        private Random random = new Random();


        public MainPage()
        {
            InitializeComponent();
        }

        //Rock:0, Paper: 1, Scissor: 2
        private async void OnRockClicked(object? sender, EventArgs e)
        {
            PlayerScore.TextColor = Colors.Black;
            ComputerScore.TextColor = Colors.Black;
            playerChoice = 0;
            int randomChoice = random.Next(0, 11);
            computerChoice = randomChoice % 3;

            await UpdateGameStatus();
            CheckWinner();
        }

        private async void OnPaperClicked(object? sender, EventArgs e)
        {
            PlayerScore.TextColor = Colors.Black;
            ComputerScore.TextColor = Colors.Black;
            playerChoice = 1;
            int randomChoice = random.Next(0, 11);
            computerChoice = randomChoice % 3;

            await UpdateGameStatus();
            CheckWinner();
        }

        private async void OnScissorClicked(object? sender, EventArgs e)
        {
            PlayerScore.TextColor = Colors.Black;
            ComputerScore.TextColor = Colors.Black;
            playerChoice = 2;
            int randomChoice = random.Next(0, 11);
            computerChoice = randomChoice % 3;

            await UpdateGameStatus();
            CheckWinner();
        }


        private void OnRulesClicked(object? sender, EventArgs e)
        {
            modal modal = new modal();
            Navigation.PushModalAsync(modal, true);
        }

        private async Task UpdateGameStatus()
        {
            await YourImage.FadeTo(0, 350);
            await CompImage.FadeTo(0, 350);
            switch (playerChoice)
            {
                case 0:
                    YourChoice.Text = "You chose Rock";
                    YourImage.Source = "rock.png";
                    break;
                case 1:
                    YourChoice.Text = "You chose Paper";
                    YourImage.Source = "paper.png";
                    break;
                case 2:
                    YourChoice.Text = "You chose Scissor";
                    YourImage.Source = "scissors.png";
                    break;
            }

            await YourImage.FadeTo(1, 350);

            switch (computerChoice)
            {
                case 0:
                    ComputerChoice.Text = "Computer chose Rock";
                    CompImage.Source = "rock.png";
                    break;
                case 1:
                    ComputerChoice.Text = "Computer chose Paper";
                    CompImage.Source = "paper.png";
                    break;
                case 2:
                    ComputerChoice.Text = "Computer chose Scissor";
                    CompImage.Source = "scissors.png";
                    break;
            }

            await CompImage.FadeTo(1, 350);
        }

        //Rock:0, Paper: 1, Scissor: 2
        private async void CheckWinner()
        {
            if (computerChoice == playerChoice)
            {
                await DisplayAlert("Draw!", "Game ended in a draw!", "OK");
            }
            else if ((playerChoice == 0 && computerChoice == 2) || (playerChoice == 1 && computerChoice == 0) ||
                     (playerChoice == 2 && computerChoice == 1))
            {
                playerScore++;
                PlayerScore.TextColor = Colors.Red;
            PlayerScore.Text = "Player Score: " + playerScore;
            }
            else
            {
                computerScore++;
                ComputerScore.TextColor = Colors.Red;
            ComputerScore.Text = "Computer Score: " + computerScore;
            }

        }

        private async void OnResetClicked(object? sender, EventArgs e)
        {
            PlayerScore.TextColor = Colors.Black;
            ComputerScore.TextColor = Colors.Black;
            computerScore = 0;
            CompImage.FadeTo(0, 200);
            await YourImage.FadeTo(0, 200);
            ComputerChoice.Text = "Computer Choice";
            ComputerScore.Text = "Computer Score: 0";
            CompImage.Source = "robot.png";
            playerScore = 0;
            YourChoice.Text = "Your Choice";
            PlayerScore.Text = "Player Score: 0";
            YourImage.Source = "singleplayer.png";
            CompImage.FadeTo(1, 200);
            await YourImage.FadeTo(1, 200);
        }
    }
}