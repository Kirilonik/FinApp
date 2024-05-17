using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginScene : MonoBehaviour
{
    public TextMeshProUGUI loginTmp;
    public TextMeshProUGUI passwordTmp;
    public Button loginBtn;


    // Start is called before the first frame update
    void Start()
    {
        
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
}
