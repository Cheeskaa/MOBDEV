using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ToDoFull_CHIZ2.Models;

namespace ToDoFull_CHIZ2;

public partial class CompletedPage : ContentPage
{
    public ObservableCollection<ToDoItem> CompletedTasks { get; set; }

    public CompletedPage(ToDoItem completedTask)
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

        // Initialize completed tasks list
        CompletedTasks = new ObservableCollection<ToDoItem>();

        if (completedTask != null)
        {
            CompletedTasks.Add(completedTask);
        }

        BindingContext = this;
    }
}