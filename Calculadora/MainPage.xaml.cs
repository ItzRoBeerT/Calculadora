using Calculadora.MVVM.ViewModels;

namespace Calculadora;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new CalcViewModel();
	}

}

