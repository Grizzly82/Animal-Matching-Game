namespace AnimalMatchingGame;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
        AnimalButtons.IsVisible = false;

        List<string> animalEmoji = new List<string>()
        {
            "🐻","🐻",
            "🐼","🐼",
            "🐘","🐘",
            "🐶","🐶",
            "😺","😺",
            "🐰","🐰",
            "🐋","🐋",
            "🦒","🦒",
        };

        foreach (var button in AnimalButtons.Children.OfType<Button>())
        {
            int index = Random.Shared.Next(animalEmoji.Count);
            string nexEmoji = animalEmoji[index];
            button.Text = nexEmoji;
            animalEmoji.RemoveAt(index);
            
        }
    }

    private void PlayAgainButton_Clicked(object sender, EventArgs e)
    {
        AnimalButtons.IsVisible = true;
        PlayAgainButton.IsVisible = false;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}

