namespace P5_AgendaP;

public partial class ConfiguracionPage : ContentPage
{
    public ConfiguracionPage()
    {
        InitializeComponent();
    }

    private void CambiarTema(object sender, EventArgs e)
    {
        bool modoOscuro = notificacionesSwitch.IsToggled;
        Application.Current.UserAppTheme = modoOscuro ? AppTheme.Dark : AppTheme.Light;
    }
    private async void LogoutButton_Clicked(object sender, EventArgs e)
    {
        Preferences.Remove("UsuarioActual");
        Preferences.Set("SesionActiva", "false");

        await Shell.Current.GoToAsync("//LoginPage");
    }
}