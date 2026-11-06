namespace MauiAppHotel.Views;

public partial class ContrataçãoHospedagem : ContentPage
{

    App PropriedadesApp;
    public ContrataçãoHospedagem()
    {
        InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtpck_checkout.MinimumDate = dtpck_checkin.Date!.Value.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date!.Value.AddMonths(6);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new HospedagemContratada());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_checkin = elemento.Date ?? DateTime.Today;

        dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }
    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ContatoLocalizacao());
    }
}