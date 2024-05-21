using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RegistrationScene : MonoBehaviour
{
    public TextMeshProUGUI nameTmp;
    public TextMeshProUGUI secondNameTmp;
    public TextMeshProUGUI lastNameTmp;
    public TextMeshProUGUI emailTmp;
    public TextMeshProUGUI loginTmp;
    public TextMeshProUGUI passwordTmp;
    public TMP_InputField passwordTmp_input;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDoneButtonClick()
    {
        StaticUserData.SaveUserData(
            this.nameTmp.text,
            this.secondNameTmp.text,
            this.lastNameTmp.text,
            this.emailTmp.text,
            this.loginTmp.text,
            this.passwordTmp_input.text
            );
    }
}
