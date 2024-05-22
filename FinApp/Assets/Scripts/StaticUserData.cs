using System;
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
        PlayerPrefs.SetFloat("Money", 0);
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
        user.Expences = LoadUserExpences(user.Categories);
        user.Money = PlayerPrefs.GetFloat("Money");

        StaticUserData.User = user;
    }

    public static List<ExpenceCategory> LoadUserCategories()
    {
        var categories = new List<ExpenceCategory>();

        int count;
        if (!int.TryParse(PlayerPrefs.GetString("CategoryCount"), out count))
            count = -1;

        for (int i = 0; i < count + 1; i++)
        {
            var category = new ExpenceCategory();
            category.Name = PlayerPrefs.GetString($"CategoryName{i}");
            category.Type = PlayerPrefs.GetString($"CategoryType{i}") == "Income" ? CategoryType.Income : CategoryType.Expence;

            categories.Add(category);
        }

        return categories;
    }

    public static List<Expence> LoadUserExpences(List<ExpenceCategory> categories)
    {
        var expences = new List<Expence>();

        int count;
        if (!int.TryParse(PlayerPrefs.GetString("ExpenceCount"), out count))
            count = -1;

        for (int i = 0; i < count + 1; i++)
        {
            var expence = new Expence();
            expence.Amount = PlayerPrefs.GetFloat($"ExpenceAmount{i}");
            expence.IsIncome = PlayerPrefs.GetString($"ExpenceType{i}") == "i";
            expence.Comment = PlayerPrefs.GetString($"ExpenceComment{i}");
            var categoryIndx = PlayerPrefs.GetInt($"ExpenceCategoryIndx{i}");
            expence.Category = categories[categoryIndx];

            expences.Add(expence);
        }

        return expences;
    }

    public static void AddUserCategory(ExpenceCategory category)
    {
        User.Categories.Add(category);

        var indx = User.Categories.Count - 1;
        PlayerPrefs.SetString($"CategoryName{indx}", category.Name);
        PlayerPrefs.SetString($"CategoryType{indx}", category.Type.ToString());
        PlayerPrefs.SetString("CategoryCount", indx.ToString());
    }

    public static void AddExpence(Expence expence)
    {
        User.Expences.Add(expence);

        var categoryIndex = User.Categories.FindLastIndex(e => e == expence.Category);
        var indx = User.Expences.Count - 1;
        PlayerPrefs.SetFloat($"ExpenceAmount{indx}", expence.Amount);
        PlayerPrefs.SetString($"ExpenceType{indx}", expence.IsIncome ? "i" : "e");
        PlayerPrefs.SetInt($"ExpenceCategoryIndx{indx}", categoryIndex);
        PlayerPrefs.SetString($"ExpenceComment{indx}", expence.Comment);
        PlayerPrefs.SetString("ExpenceCount", indx.ToString());

        UpdateUserMoney(expence.Amount, expence.IsIncome);
    }

    private static void UpdateUserMoney(float dif, bool income)
    {
        if (income)
            User.Money += dif;
        else
            User.Money -= dif;

        PlayerPrefs.SetFloat("Money", User.Money);
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

    public float Money;
    public List<ExpenceCategory> Categories;
    public List<Expence> Expences;
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

public class Expence
{
    public float Amount;
    public ExpenceCategory Category;
    public bool IsIncome;
    public string Comment;
}