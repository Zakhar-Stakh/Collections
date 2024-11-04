using System;
using System.Collections.Generic;

class Task
{
    public int TaskId { get; set; }
    public string Description { get; set; }

    public Task(int taskId, string description)
    {
        TaskId = taskId;
        Description = description;
    }
}

class TaskManager
{
    private List<Task> tasks;

    public TaskManager()
    {
        tasks = new List<Task>();
    }

    // Метод для додавання нового завдання
    public void AddTask(Task task)
    {
        tasks.Add(task);
        Console.WriteLine($"Task '{task.Description}' added with ID: {task.TaskId}");
    }

    // Метод для видалення завдання за ідентифікатором
    public void RemoveTask(int taskId)
    {
        Task taskToRemove = tasks.Find(t => t.TaskId == taskId);
        if (taskToRemove != null)
        {
            tasks.Remove(taskToRemove);
            Console.WriteLine($"Task with ID: {taskId} has been removed.");
        }
        else
        {
            Console.WriteLine($"Task with ID: {taskId} not found.");
        }
    }

    // Метод для виведення всіх завдань
    public void DisplayTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        Console.WriteLine("Current tasks:");
        foreach (var task in tasks)
        {
            Console.WriteLine($"ID: {task.TaskId}, Description: {task.Description}");
        }
    }
}

class Program
{
    static void Main()
    {
        TaskManager taskManager = new TaskManager();

        // Додавання завдань
        taskManager.AddTask(new Task(1, "Complete the project report"));
        taskManager.AddTask(new Task(2, "Prepare presentation for Monday"));
        taskManager.AddTask(new Task(3, "Update the documentation"));

        // Виведення всіх завдань
        taskManager.DisplayTasks();
        Console.WriteLine();

        // Видалення завдання за ідентифікатором
        taskManager.RemoveTask(2);
        Console.WriteLine();

        // Виведення всіх завдань після видалення
        taskManager.DisplayTasks();
    }
}