using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Category : MonoBehaviour
{
    public TextMeshProUGUI nameTmp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeName(string name)
    {
        nameTmp.text = name;
    }
}
