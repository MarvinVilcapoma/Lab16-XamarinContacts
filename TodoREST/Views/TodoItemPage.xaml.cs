using System;
using Xamarin.Forms;
using Acr.UserDialogs;
using System.Threading.Tasks;

namespace TodoREST
{
	public partial class TodoItemPage : ContentPage
	{
		bool isNewItem;

		public TodoItemPage (bool isNew = false)
		{
			InitializeComponent ();
			isNewItem = isNew;
		}

		async void OnSaveButtonClicked (object sender, EventArgs e)
		{
			UserDialogs.Instance.ShowLoading("Registrando Contacto");			 
			var todoItem = (TodoItem)BindingContext;
			await Task.Delay(3000);
			UserDialogs.Instance.HideLoading();
			await DisplayAlert("Contacto Agregado", "El contacto ha sido agregado exitosamente", "Ok");
			await App.TodoManager.SaveTaskAsync (todoItem, isNewItem);
			await Navigation.PopAsync ();
		}

		async void OnDeleteButtonClicked (object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			await App.TodoManager.DeleteTaskAsync (todoItem);
			await Navigation.PopAsync ();
		}

		async void OnCancelButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PopAsync ();
		}
	}
}
