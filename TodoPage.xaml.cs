using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;

namespace MauiApp9;

public partial class TodoPage : ContentPage
{
    public ObservableCollection<TodoItem> Tasks { get; set; }

        public TodoPage()
        {
            InitializeComponent();

            // Use the global pending tasks collection
            Tasks = TodoService.PendingTasks;
            Tasks.CollectionChanged += (sender, args) => UpdateNoTasksMessage();
            // For demonstration, add some initial tasks if the list is empty
            UpdateNoTasksMessage();

            BindingContext = this;
        }
        private void UpdateNoTasksMessage()
        {
            NoTasksLabel.IsVisible = Tasks.Count == 0;
        }

        private async void OnAddTaskClicked(object sender, EventArgs e)
        {
            // Navigate to AddTodoPage to create a new todo
            await Shell.Current.GoToAsync("//AddTodoPage");
        }

        private void OnDeleteTaskClicked(object sender, EventArgs e)
        {
            if (sender is VisualElement element && element.BindingContext is TodoItem taskToDelete)
            {
                Tasks.Remove(taskToDelete);
            }
        }

        private void OnCheckBoxChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.BindingContext is TodoItem checkedItem)
            {
                if (e.Value)
                {
                    // Defer removal/navigation until the next UI cycle
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        TodoService.PendingTasks.Remove(checkedItem);
                        TodoService.CompletedTasks.Add(checkedItem);

                        await Shell.Current.GoToAsync("//CompletedTodoPage");
                    });
                }
            }
        }

        private async void OnTodoItemTapped(object sender, EventArgs e)
        {
            if (sender is VisualElement visualElement && visualElement.BindingContext is TodoItem tappedItem)
            {
                TodoService.SelectedItem = tappedItem;
                await Shell.Current.GoToAsync("//EditTodoPage");
            }
        }


        // Navigate to the CompletedTodoPage when the check icon is tapped
        private async void OnCheckClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//CompletedTodoPage");
        }

        private async void OnProfileClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//ProfilePage");
        }
    }

public class TodoItem : INotifyPropertyChanged
{
    private string title = string.Empty;
    private string description = string.Empty;
    private bool isCompleted;

    public string Title
    {
        get => title;
        set
        {
            if (title != value)
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
    }

    public string Description
    {
        get => description;
        set
        {
            if (description != value)
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
    }

    public bool IsCompleted
    {
        get => isCompleted;
        set
        {
            if (isCompleted != value)
            {
                isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }
    }

    public ICommand DeleteCommand => new Command(() =>
    {
        Shell.Current.DisplayAlert("Delete", $"Delete {Title}?", "OK");
    });

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

}