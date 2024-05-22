using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public static class StaticUserData
{
    public static User User = null;

    public static void SaveUserData(string name, string secondName, string lastName, string email, string login, string passwod)
    {
        User user = new User()
        {
            Name = name,
            SecondName = secondName,
            LastName = lastName,
            Email = email,
            Login = login,
            Password = passwod
        };
        StaticUserData.User = user;
        PlayerPrefs.SetString("Name", name);
        PlayerPrefs.SetString("SecondName", secondName);
        PlayerPrefs.SetString("LastName", lastName);
        PlayerPrefs.SetString("Email", email);
        PlayerPrefs.SetString("Login", login);
        PlayerPrefs.SetString("Password", passwod);
    }
    
    public static void LoadUserData()
    {
        User user = new User();
        user.Name = PlayerPrefs.GetString("Name");
        user.SecondName = PlayerPrefs.GetString("SecondName");
        user.LastName = PlayerPrefs.GetString("LastName");
        user.Email = PlayerPrefs.GetString("Email");
        user.Login = PlayerPrefs.GetString("Login");
        user.Password = PlayerPrefs.GetString("Password");
        user.Categories = LoadUserCategories();
        StaticUserData.User = user;
    }

    public static List<ExpenceCategory> LoadUserCategories()
    {
        var categories = new List<ExpenceCategory>();

        int count;
        if (!int.TryParse(PlayerPrefs.GetString("CategoryCount"), out count))
            count = 0;

        for (int i = 0; i < count + 1; i++)
        {
            var category = new ExpenceCategory();
            category.Name = PlayerPrefs.GetString($"CategoryName{i}");
            category.Type = PlayerPrefs.GetString($"CategoryType{i}") == "Income" ? CategoryType.Income : CategoryType.Expence;

            categories.Add(category);
        }

        return categories;
    }

    public static void AddUserCategory(ExpenceCategory category)
    {
        LoadUserData();
        User.Categories.Add(category);

        var indx = User.Categories.Count - 1;
        PlayerPrefs.SetString($"CategoryName{indx}", category.Name);
        PlayerPrefs.SetString($"CategoryType{indx}", category.Type.ToString());
        PlayerPrefs.SetString("CategoryCount", indx.ToString());
    }
}


public class User
{
    public string Name;
    public string SecondName;
    public string LastName;
    public string Email;
    public string Login;
    public string Password;

    public List<ExpenceCategory> Categories;
}

public class ExpenceCategory
{
    public string Name;
    public CategoryType Type;
}

public enum CategoryType 
{
    Income,
    Expence
}