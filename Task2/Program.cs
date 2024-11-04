using System;
using System.Collections.Generic;

class User
{
    public int Id { get; set; }
    public string Name { get; set; }

    public User(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}";
    }
}

class UserManager
{
    private List<User> users;

    public UserManager()
    {
        users = new List<User>();
    }

    // Метод для додавання нового користувача
    public void AddUser(User user)
    {
        users.Add(user);
        Console.WriteLine($"User '{user.Name}' added with ID: {user.Id}");
    }

    // Метод для видалення користувача за ідентифікатором
    public void RemoveUser(int id)
    {
        User userToRemove = users.Find(u => u.Id == id);
        if (userToRemove != null)
        {
            users.Remove(userToRemove);
            Console.WriteLine($"User with ID: {id} has been removed.");
        }
        else
        {
            Console.WriteLine($"User with ID: {id} not found.");
        }
    }

    // Метод для пошуку користувача за ідентифікатором
    public User FindUser(int id)
    {
        return users.Find(u => u.Id == id);
    }

    // Метод для виведення всіх користувачів
    public void DisplayUsers()
    {
        if (users.Count == 0)
        {
            Console.WriteLine("No users available.");
            return;
        }

        Console.WriteLine("Current users:");
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
    }
}

class Program
{
    static void Main()
    {
        UserManager userManager = new UserManager();

        // Додавання користувачів
        userManager.AddUser(new User(1, "Alice"));
        userManager.AddUser(new User(2, "Bob"));
        userManager.AddUser(new User(3, "Charlie"));

        // Виведення всіх користувачів
        userManager.DisplayUsers();
        Console.WriteLine();

        // Пошук користувача за ідентифікатором
        int searchId = 2;
        User foundUser = userManager.FindUser(searchId);
        if (foundUser != null)
        {
            Console.WriteLine($"Found user: {foundUser}");
        }
        else
        {
            Console.WriteLine($"User with ID: {searchId} not found.");
        }
        Console.WriteLine();

        // Видалення користувача за ідентифікатором
        userManager.RemoveUser(2);
        Console.WriteLine();

        // Виведення всіх користувачів після видалення
        userManager.DisplayUsers();
    }
}