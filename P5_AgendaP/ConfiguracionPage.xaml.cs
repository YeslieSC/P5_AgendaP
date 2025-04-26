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
}