using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Category : MonoBehaviour
{
    public TextMeshProUGUI nameTmp;
    public GameObject SelectedImg;

    private bool selected;
    public ExpenceCategory dbCategory;

    // Start is called before the first frame update
    void Start()
    {
        selected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeName(string name)
    {
        nameTmp.text = name;
    }
    
    public void SetChoosen()
    {
        selected = true;
        SelectedImg.SetActive(true);
    }

    public void UnsetChoosen()
    {
        selected = false;
        SelectedImg.SetActive(false);
    }

    public void SetDbCategory(ExpenceCategory expenceCategory)
    {
        dbCategory = expenceCategory;
    }
}
