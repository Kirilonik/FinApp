using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddExpence : MonoBehaviour
{
    public TextMeshProUGUI amount;
    public Button addBtn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (amount.text.Length > 1)
        {
            addBtn.interactable = true;
        }
        else
        {
            addBtn.interactable = false;
        }
    }
}
