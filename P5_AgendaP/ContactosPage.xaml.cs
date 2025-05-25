using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls;
using P5_AgendaP.Modelos;
using P5_AgendaP.Datos;

namespace P5_AgendaP;

public partial class ContactosPage : ContentPage
{
    private readonly ContactoDatabase _database = new();

    public ContactosPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var contactos = await _database.ObtenerContactosAsync();
        ContactosListView.ItemsSource = contactos;
    }

    private async void IrDetalleContacto(object sender, EventArgs e)
    {
        var contactoSeleccionado = (Contacto)((Button)sender).BindingContext;
        await Navigation.PushAsync(new DetalleContactoPage(contactoSeleccionado));
    }
}
