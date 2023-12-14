namespace VitaLink;

public partial class HomeScreen : ContentPage
{
    public static int peopleButtonSize = 50;

    public HomeScreen()
    {
        InitializeComponent();
        // Set the theme to light
        Application.Current.UserAppTheme = AppTheme.Light;

        // Add the buttons to the stacklayout
        Senior kees = new Senior(1, "Kees", "kees.jpg", 80);
        Senior peter = new Senior(2, "Peter", "peter.jpg", 75);
        List<Senior> people = new List<Senior>();
        people.Add(kees);
        people.Add(peter);

        User user = User.getInstance();
        user.Token = "123";
        user.Username = "Abel";
        user.FollowingList = people;

        for (int i = 0; i < user.FollowingList.Count; i++)
        {
            peopleButtons.Children.Add(CreateFollowerButton(user.FollowingList[i]));
        }

        accountbutton.Clicked += (sender, args) =>
        {
            // TODO Handle account
            Navigation.PushAsync(new SettingsPage());
        };
    }
    private Frame CreateFollowerButton(Senior senior)
    {
        // Create an image with the specified source
        var imageButton = new ImageButton
        {
            Source = senior.ImageUrl,
            Aspect = Aspect.AspectFit,
            WidthRequest = peopleButtonSize,
            HeightRequest = peopleButtonSize
        };
        imageButton.Clicked += (sender, args) =>
        {
            showStats(senior);
            // TODO Show stats of the person
        };

        // Create a frame to wrap the image
        var frame = new Frame
        {
            Content = imageButton,
            HasShadow = false,
            CornerRadius = 25, // Round the corners
            WidthRequest = peopleButtonSize,
            HeightRequest = peopleButtonSize,
            Margin = 5
        };

        return frame;
    }

    private void showStats(Senior senior)
    {
        throw new NotImplementedException();
    }
}