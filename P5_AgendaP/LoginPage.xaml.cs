using P5_AgendaP.Modelos;
using P5_AgendaP.Datos;

namespace P5_AgendaP;

public partial class LoginPage : ContentPage
{
    private readonly UsuarioDatabase _database = new();

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
        DisplayAlert("Recuperar Password", $"Name : {Msg}", "ok");
    }
    private void TapGestureRecognizerReg_Tapped(object sender, TappedEventArgs e)
    {
        Label Reg = (sender as Label);
        var Msg = Reg.FormattedText.Spans[0].Text;
        DisplayAlert("Registrar Usuario", $"Name : {Msg}", "ok");
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        string email = Username.Text?.Trim() ?? "";
        string password = Password.Text?.Trim() ?? "";

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Error", "Por favor, ingresa tu correo y contraseña.", "OK");
            return;
        }

        var usuario = await _database.GetUsuarioPorEmailYPasswordAsync(email, password);

        if (usuario != null)
        {
            Preferences.Set("UsuarioActual", usuario.Email);
            Preferences.Set("SesionActiva", "true");
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            Preferences.Remove("UsuarioActual");
            await DisplayAlert("Login fallido", "Correo o contraseña incorrectos.", "Intentar de nuevo");
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
}
