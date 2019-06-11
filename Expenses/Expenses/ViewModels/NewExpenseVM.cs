using Expenses.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Expenses.ViewModels
{
    public class NewExpenseVM : INotifyPropertyChanged
    {

        private string expenseName;
        public string ExpenseName
        {
            get { return expenseName; }
            set
            {
                expenseName = value;
                OnPropertyChanged("ExpenseName");
            }
        }
        private string expenseDescription;
        public string ExpenseDescription
        {
            get { return expenseDescription; }
            set
            {
                expenseDescription = value;
                OnPropertyChanged("ExpenseDescription");
            }
        }
        private float expenseAmount;
        public float ExpenseAmount
        {
            get { return expenseAmount; }
            set
            {
                expenseAmount = value;
                OnPropertyChanged("ExpenseAmount");
            }
        }
        private DateTime expenseDate;
        public DateTime ExpenseDate
        {
            get { return expenseDate; }
            set
            {
                expenseDate = value;
                OnPropertyChanged("ExpenseDate");
            }
        }
        private string expenseCategory;
        public string ExpenseCategory
        {
            get { return expenseCategory; }
            set
            {
                expenseCategory = value;
                OnPropertyChanged("ExpenseCategory");
            }
        }
        public Command SaveExpenseCommand
        {
            get;
            set;
        }
        public ObservableCollection<string> Categories
        {
            get;
            set;
        }
        public ObservableCollection<ExpensesStatus> ExpensesStatuses
        {
            get;
            set;
        }
        public NewExpenseVM()
        {
            Categories = new ObservableCollection<string>();
            ExpensesStatuses = new ObservableCollection<ExpensesStatus>();
            ExpenseDate = DateTime.Today;
            SaveExpenseCommand = new Command(InsertExpense);
            GetCategories();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InsertExpense()
        {
            Expense expense = new Expense()
            {
                Name = ExpenseName,
                Amount = ExpenseAmount,
                Category = ExpenseCategory,
                Date = ExpenseDate,
                Description = ExpenseDescription
            };
            int response = Expense.InserExpense(expense);
            if (response > 0)
                Application.Current.MainPage.Navigation.PopAsync();
            else
                Application.Current.MainPage.DisplayAlert("Error", "No items were inserted", "OK");
        }
        private void GetCategories()
        {
            Categories.Clear();
            Categories.Add("Housing");
            Categories.Add("Dept");
            Categories.Add("Health");
            Categories.Add("Food");
            Categories.Add("Personal");
            Categories.Add("Travel");
            Categories.Add("Other");

        }
        public void GetExpenseStatus()
        {
            ExpensesStatuses.Clear();
            ExpensesStatuses.Add(new ExpensesStatus()
            {
                Name = "random",
                Status = true
            });
            ExpensesStatuses.Add(new ExpensesStatus()
            {
                Name = "random 2",
                Status = true
            });
            ExpensesStatuses.Add(new ExpensesStatus()
            {
                Name = "random 3",
                Status = false
            });
        }
        public class ExpensesStatus
        { 
            public string Name
            {
                get;
                set;
            }
            public bool Status 
            {
                get;
                set; 
            }
        }
    }
}
