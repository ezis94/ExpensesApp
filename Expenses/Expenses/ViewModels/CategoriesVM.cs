﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Expenses.ViewModels
{
    public class CategoriesVM
    {
        public ObservableCollection<string> Categories
        {
            get;
            set;
        }
        public CategoriesVM()
        {
            Categories = new ObservableCollection<string>();
            GetCategories();
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
    }
}
