using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Expenses.Model;
using System.Linq;
using Expenses.Interfaces;
using Xamarin.Forms;

namespace Expenses.ViewModels
{
    public class CategoriesVM
    {
        public ObservableCollection<string> Categories
        {
            get;
            set;
        }
        public ObservableCollection<CategoryExpenses> CategoryExpensesCollection
        {
            get;
            set;
        }
        public CategoriesVM()
        {
            Categories = new ObservableCollection<string>();
            CategoryExpensesCollection = new ObservableCollection<CategoryExpenses>();
            GetCategories();
            GetExpensesPerCategory();
        }

        public void GetExpensesPerCategory()
        {
            CategoryExpensesCollection.Clear();
            float totalExpensesAmount = Expense.TotalExpensesAmount();
            foreach(string c in Categories)
            {
                var expenses = Expense.GetExpenses(c);
                float expensesAmountInCategory = expenses.Sum(e => e.Amount);
                CategoryExpenses ce = new CategoryExpenses()
                {
                    Category = c,
                    ExpensesPercentage = expensesAmountInCategory / totalExpensesAmount
                };
                CategoryExpensesCollection.Add(ce);
            }
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
        public void ShareReport()
        {
            IShare shareDependency = DependencyService.Get<IShare>();
            shareDependency.Show("", "", "");
        }
        public class CategoryExpenses
        {
            public string Category
            {
                get;
                set;
            }
            public float ExpensesPercentage
            {
                get;
                set;
            }
        }
    }
}
