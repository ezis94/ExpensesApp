using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expenses.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Expenses.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewExpensePage : ContentPage
	{
        NewExpenseVM ViewModel;
		public NewExpensePage ()
		{
			InitializeComponent ();
            ViewModel = Resources["vm"] as NewExpenseVM;
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.GetExpenseStatus();
            int count = 0;
            foreach(var es in ViewModel.ExpensesStatuses)
            {
                var cell = new SwitchCell { Text = es.Name };
                Binding binding = new Binding();
                binding.Source = ViewModel.ExpensesStatuses[count];
                binding.Path = "Status";
                binding.Mode = BindingMode.TwoWay;
                cell.SetBinding(SwitchCell.OnProperty, binding);
                var section = new TableSection("Statuses");
                section.Add(cell);
                expenseTableView.Root.Add(section);
                count++;
            }
        }
    }
}