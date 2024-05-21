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
        StaticUserData.User = user;
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
}