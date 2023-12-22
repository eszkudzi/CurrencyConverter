using CurrencyConverter.View;

namespace CurrencyConverter;

public partial class App : Application
{
	public App()
    {
        InitializeComponent();

		MainPage = new CurrencyConverterPage();
	}
}

