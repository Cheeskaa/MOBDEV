using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MauiApp9;

public class TodoService
{
    // Collection for tasks that are still pending
    public static ObservableCollection<TodoItem> PendingTasks { get; set; } = new ObservableCollection<TodoItem>();

    // Collection for tasks that have been completed
    public static ObservableCollection<TodoItem> CompletedTasks { get; set; } = new ObservableCollection<TodoItem>();
}