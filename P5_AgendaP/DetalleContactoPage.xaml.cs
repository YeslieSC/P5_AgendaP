using P5_AgendaP.Modelos;

namespace P5_AgendaP;

public partial class DetalleContactoPage : ContentPage
{
    private readonly Contacto contacto;

    public DetalleContactoPage(Contacto contactoSeleccionado)
    {
        InitializeComponent();
        contacto = contactoSeleccionado;

        NombreLabel.Text = contacto.Nombre;
        TelefonoLabel.Text = contacto.Telefono;
        CorreoLabel.Text = contacto.CorreoElectronico;
    }
}
