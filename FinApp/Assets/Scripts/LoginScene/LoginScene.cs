using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginScene : MonoBehaviour
{
    public TextMeshProUGUI loginTmp;
    public TextMeshProUGUI passwordTmp;
    public TMP_InputField passwordTmp_input;
    public GameObject errorLoginPassword;
    public Button loginBtn;


    // Start is called before the first frame update
    void Start()
    {
        StaticUserData.LoadUserData();
    }

    // Update is called once per frame
    void Update()
    {
        if (loginTmp.text.Length > 1  && passwordTmp.text.Length > 1)
        {
            loginBtn.interactable = true;
        }
        else
        {
            loginBtn.interactable = false;
        }
    }

    public void OnLoginClick()
    {
        if (this.TryLogin())
        {
            this.errorLoginPassword.SetActive(false);
            AppManager.instance.ChangeSceneTo("MainScene");
        }
        else
        {
            this.errorLoginPassword.SetActive(true);
            this.ClearFields();
        }
    }

    private bool TryLogin()
    {
        if(StaticUserData.User == null)
        {
            return false;
        }
        if (StaticUserData.User.Login == loginTmp.text
            &&
            StaticUserData.User.Password == passwordTmp_input.text)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void ClearFields()
    {
        this.loginTmp.SetText("");
        this.passwordTmp.SetText("");
    }
}
