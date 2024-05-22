using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddExpence : MonoBehaviour
{
    public TextMeshProUGUI amount;
    public Button addBtn;
    public Transform scrollViewContent;
    public GameObject categoryPrefab;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var category in StaticUserData.User.Categories)
        {
            var cat = Instantiate(categoryPrefab, scrollViewContent);
            if (cat.TryGetComponent<Category>(out var categoryScript))
            {
                categoryScript.ChangeName(category.Name);
            }
        }
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
