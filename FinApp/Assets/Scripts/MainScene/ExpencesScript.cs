using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExpencesScript : MonoBehaviour
{
    public TextMeshProUGUI commentTmp;
    public TextMeshProUGUI amountTmp;
    public TextMeshProUGUI categoryTmp;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetComment(string comment)
    {
        commentTmp.text = comment;
    }
    
    public void SetAmount(float amount)
    {
        amountTmp.text = amount.ToString("0.00");
    }

    public void SetCategory(string category)
    {
        categoryTmp.text = category;
    }
}
