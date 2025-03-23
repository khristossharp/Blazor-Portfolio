using MudBlazor;


namespace Portfolio.Pages
{
    public partial class Home
    {

    private string AnimationEntrance = "backInDown";
    private string AnimationExit = "backOutDown";
    private int _selectTab = 0;

    private string NavBarClass = string.Empty;
    private bool isOpen = false;

    private void MoveBar()
    {
        NavBarClass = "move-up";
    }

    private void ChangeThePage(int par)
    {
        _selectTab = par;
    }

    private void Open()
    {
        isOpen = true;
    }

    private Task OpenRegistrationFormAsync()
    {
        var options = new DialogOptions { BackgroundClass = "my-custom-class", CloseButton = true };

        return DialogService.ShowAsync<DialogForm>("", options);
    }


    }
}
