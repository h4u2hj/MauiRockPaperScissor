namespace RockPaperScissor;

public partial class TwoPlayer : ContentPage
{
    private int p1c;
    private int p2c;
    private int p1Score = 0;
    private int p2Score = 0;
    private bool player2turn = false;
    private Random random = new Random();


    public TwoPlayer()
    {
        InitializeComponent();
    }

    private void OnRulesClicked(object? sender, EventArgs e)
    {
        modal modal = new modal();
        Navigation.PushModalAsync(modal, true);
    }

    //Rock:0, Paper: 1, Scissor: 2
    private async void OnRockClicked(object? sender, EventArgs e)
    {
        if (!player2turn)
        {
            Player1Score.TextColor = Colors.Black;
            Player2Score.TextColor = Colors.Black;
            p1c = 0;
            player2turn = true;
            TurnLabel.Text = "Player 2's Turn";
            MainLayout.Rotation = 180;
        }
        else if (player2turn)
        {
            p2c = 0;
            TurnLabel.Text = "Player 1 start new game!";
            MainLayout.Rotation = 0;
            await UpdateGameStatus();
            CheckWinner();
            player2turn = false;
        }
    }

    private async void OnPaperClicked(object? sender, EventArgs e)
    {
        if (!player2turn)
        {
            Player1Score.TextColor = Colors.Black;
            Player2Score.TextColor = Colors.Black;
            p1c = 1;
            player2turn = true;
            TurnLabel.Text = "Player 2's Turn";
            MainLayout.Rotation = 180;
        }
        else if (player2turn)
        {
            p2c = 1;
            TurnLabel.Text = "Player 1 start new game!";
            MainLayout.Rotation = 0;
            await UpdateGameStatus();
            CheckWinner();
            player2turn = false;
        }
    }

    private async void OnScissorClicked(object? sender, EventArgs e)
    {
        if (!player2turn)
        {
            Player1Score.TextColor = Colors.Black;
            Player2Score.TextColor = Colors.Black;
            p1c = 2;
            player2turn = true;
            TurnLabel.Text = "Player 2's Turn";
            MainLayout.Rotation = 180;
        }
        else if (player2turn)
        {
            p2c = 2;
            TurnLabel.Text = "Player 1 start new game!";
            MainLayout.Rotation = 0;
            await UpdateGameStatus();
            CheckWinner();
            player2turn = false;
        }
    }


    private async Task UpdateGameStatus()
    {
        await YourImage.FadeTo(0, 350);
        await CompImage.FadeTo(0, 350);
        switch (p1c)
        {
            case 0:
                p1Choice.Text = "Player 1 chose Rock";
                YourImage.Source = "rock.png";
                break;
            case 1:
                p1Choice.Text = "Player 1 chose Paper";
                YourImage.Source = "paper.png";
                break;
            case 2:
                p1Choice.Text = "Player 1 chose Scissor";
                YourImage.Source = "scissors.png";
                break;
        }

        await YourImage.FadeTo(1, 350);

        switch (p2c)
        {
            case 0:
                p2Choice.Text = "Player 2 chose Rock";
                CompImage.Source = "rock.png";
                break;
            case 1:
                p2Choice.Text = "Player 2 chose Paper";
                CompImage.Source = "paper.png";
                break;
            case 2:
                p2Choice.Text = "Player 2 chose Scissor";
                CompImage.Source = "scissors.png";
                break;
        }

        await CompImage.FadeTo(1, 350);
    }

    //Rock:0, Paper: 1, Scissor: 2
    private async void CheckWinner()
    {
        if (p1c == p2c)
        {
            await DisplayAlert("Draw!", "Game ended in a draw!", "OK");
        }
        else if ((p1c == 0 && p2c == 2) || (p1c == 1 && p2c == 0) || (p1c == 2 && p2c == 1))
        {
            p1Score++;
            Player1Score.TextColor = Colors.Red;
            Player1Score.Text = "Player 1 Score: " + p1Score;
        }
        else
        {
            p2Score++;
            Player2Score.TextColor = Colors.Red;
        Player2Score.Text = "Player 2 Score: " + p2Score;
        }


    }

    private async void OnResetClicked(object? sender, EventArgs e)
    {
        Player1Score.TextColor = Colors.Black;
        Player2Score.TextColor = Colors.Black;
        p1Score = 0;
        p2Score = 0;
        MainLayout.Rotation = 0;
        CompImage.FadeTo(0, 200);
        await YourImage.FadeTo(0, 200);
        TurnLabel.Text = "Player 1 Start! Choose a symbol!";
        p1Choice.Text = "Player 1 Choice";
        p2Choice.Text = "Player 2 Choice";
        Player1Score.Text = "Player 1 Score: 0";
        Player2Score.Text = "Player 2 Score: 0";
        CompImage.Source = "twoplayer.png";
        YourImage.Source = "singleplayer.png";
        CompImage.FadeTo(1, 200);
        await YourImage.FadeTo(1, 200);
    }
}