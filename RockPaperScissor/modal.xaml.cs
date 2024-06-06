using System.Threading.Tasks;

namespace RockPaperScissor;

public partial class modal : ContentPage
{
    public modal()
    {
        InitializeComponent();
    }

    private async void SwipeGestureRecognizer_OnSwiped(object? sender, SwipedEventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}