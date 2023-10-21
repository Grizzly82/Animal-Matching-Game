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


    Button lastClicked;
    bool findingMatch = false;
    int matchesFound; // initializes the variables matchesFound

    private void Button_Clicked(object sender, EventArgs e)
    {
        if(sender is Button buttonClicked)
        {
            if(!string.IsNullOrEmpty(buttonClicked.Text) && (findingMatch == false))
            {
                //when the button is clicked it turns the background color from lightblue 
                //to red, save the item on the button and compares it to the last one clicked
                buttonClicked.BackgroundColor = Colors.Red;
                lastClicked = buttonClicked;
                findingMatch = true;
            }
            else
            {
                //if the second button clicked does not match the first one 
                //reset both buttons to light blue
                if((buttonClicked != lastClicked) && (buttonClicked.Text == lastClicked.Text))
                {
                    matchesFound++;
                    lastClicked.Text = " ";
                    buttonClicked.Text = "";
                }
                lastClicked.BackgroundColor = Colors.LightBlue;
                buttonClicked.BackgroundColor = Colors.LightBlue;
                findingMatch = false;
            }
        }
        if(matchesFound == 8)
        {
            matchesFound = 0;
            AnimalButtons.IsVisible = false;
            PlayAgainButton.IsVisible = true;
        }

    }
}

