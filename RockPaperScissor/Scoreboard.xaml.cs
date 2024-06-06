namespace RockPaperScissor;

public partial class Scoreboard : ContentPage
{
    private int noPlayers = 0;
    bool isSet = false;

    public Scoreboard()
    {
        InitializeComponent();
    }

    private async void OnSetPClicked(object? sender, EventArgs e)
    {
        if (noPlayers > 0)
        {
            CheckWinner();
            return;
        }

        if (isSet)
        {
            board.Children.Clear();
            board.ColumnDefinitions.Clear();
            board.RowDefinitions.Clear();
            isSet = false;
        }

        try
        {
            noPlayers = Convert.ToInt32(await DisplayPromptAsync("Number of Players",
                "Set the number of players in the scoreboard", "Set", placeholder: "2-10"));
        }
        catch (FormatException)
        {
            await DisplayAlert("Error", "Please enter a valid number", "OK");
            noPlayers = 0;
        }

        if (noPlayers > 1 && noPlayers < 11)
        {
            setButton.Text = "Click to end the game!";
            setButton.WidthRequest = 180;
            SetBoard();
        }
        else if (noPlayers == 0)
        {
            return;
        }
        else
        {
            await DisplayAlert("Error", "The maximum number of players is 10 and the minimum is 2", "OK");
            noPlayers = 0;
        }
    }

    private async void CheckWinner()
    {
        int max = 0;
        int maxrow = 0;
        foreach (var child in board.Children)
        {
            if (board.GetColumn(child) == 1)
            {
                MyButton btn = (MyButton)child;
                if (btn.score > max)
                {
                    max = btn.score;
                    maxrow = btn.row;
                }

                btn.IsEnabled = false;
                btn.TextColor = Colors.White;
            }
        }

        await DisplayAlert("Winner", $"Player {maxrow + 1} is the winner with a score of {max}", "OK");
        isSet = true;
        setButton.Text = "Set players";
        setButton.WidthRequest = 100;
        noPlayers = 0;
    }

    private void SetBoard()
    {
        for (int i = 0; i < 2; i++)
        {
            board.AddColumnDefinition(new ColumnDefinition(200));
        }

        for (int i = 0; i < 10; i++)
        {
            board.AddRowDefinition(new RowDefinition(50));
        }

        board.RowSpacing = 5;
        Label label;
        MyButton button;
        for (int i = 0; i < noPlayers; i++)
        {
            label = new Label
            {
                Text = $"Player {i + 1}: ",
                FontSize = 24,
                WidthRequest = 120,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            board.Add(label, 0, i);

            button = new MyButton
            {
                Text = "0",
                Margin = new Thickness(10, 0, 0, 0),
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 100,
                CornerRadius = 25,
                Background = Colors.Purple
            };
            button.Clicked += OnScoreClicked;
            button.row = i;
            board.Add(button, 1, i);
        }
    }

    private void OnScoreClicked(object? sender, EventArgs e)
    {
        MyButton button = (MyButton)sender;
        button.score++;
        button.Text = button.score.ToString();
    }
}