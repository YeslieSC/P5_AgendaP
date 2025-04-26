using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace P5_AgendaP;

public partial class ContactosPage : ContentPage
{
    public static List<object> contactos = new List<object>();
    
    public ContactosPage()
    {
        InitializeComponent();
        ContactosListView.ItemsSource = contactos;
    }

    private async void IrDetalleContacto(object sender, EventArgs e)
    {
        var contactoSeleccionado = (object)((Button)sender).BindingContext;
        await Navigation.PushAsync(new DetalleContactoPage(contactoSeleccionado));
    }
}