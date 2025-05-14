namespace P5_AgendaP;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();

        string usuarioGuardado = Preferences.Get("UsuarioActual", "");
        bool sesionActiva = Preferences.Get("SesionActiva", "false") == "true";

        if (sesionActiva && !string.IsNullOrEmpty(usuarioGuardado))
        {
            Navigation.PushAsync(new MainPage());
        }
    }

    protected override bool OnBackButtonPressed()
    {
        Application.Current.Quit();
        return true;
    }

    private void TapGestureRecognizerPwd_Tapped(object sender, TappedEventArgs e)
    {
        Label Reg = (sender as Label);
        var Msg = Reg.FormattedText.Spans[1].Text;
        //var customerName = (sender as Label).Text;
        DisplayAlert("Recuperar Password", $"Name : {Msg}", "ok");
    }
    private void TapGestureRecognizerReg_Tapped(object sender, TappedEventArgs e)
    {
        Label Reg = (sender as Label);
        var Msg = Reg.FormattedText.Spans[0].Text;
        //var customerName = (sender as Label).Text;
        DisplayAlert("Registrar Usuario", $"Name : {Msg}", "ok");
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        if (IsCredentialCorrect(Username.Text, Password.Text)) 
        {
            Preferences.Set("UsuarioActual", Username.Text.Trim());
            Preferences.Set("SesionActiva", "true");
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            Preferences.Remove("UsuarioActual"); 
            await DisplayAlert("Login failed", "Username or password is invalid", "Try again");
        }
    }
    private async void OnRegisterTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///RegisterPage");
    }

    private async void OnRecoverTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///RecoverPage"); 
    }

    bool IsCredentialCorrect(string username, string password)
    {
        return Username.Text == "admin" && Password.Text == "1234";
    }
}