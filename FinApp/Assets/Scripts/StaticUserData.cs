using System.Diagnostics;

public static class StaticUserData
{
    public static string Name;
    public static string LastName;
    public static string Email;
    public static string Login;
    public static string Password;

    public static void SaveUserData(string name, string lastName, string email, string login, string passwod)
    {
        StaticUserData.Name = name;
        StaticUserData.LastName = lastName;
        StaticUserData.Email = email;
        StaticUserData.Login = login;
        StaticUserData.Password = passwod;
        Debug.Write(name + lastName + email + login + passwod);
    }
}
