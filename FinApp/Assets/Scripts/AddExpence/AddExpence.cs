using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class AddExpence : MonoBehaviour
{
    public TextMeshProUGUI amount;
    public Button addBtn;
    public Transform scrollViewContent;
    public GameObject categoryPrefab;
    public bool IncomeTabOpen;
    public TextMeshProUGUI Comment;

    private GameObject selectedCategory;
    private int selectedCategoryIndx;

    // Start is called before the first frame update
    void Start()
    {
        IncomeTabOpen = false;
        selectedCategoryIndx = -1;

        UpdateCategories();
    }

    void UpdateCategories()
    {
        if (selectedCategory != null
            && selectedCategory.TryGetComponent<Category>(out var categoryScript))
        {
            categoryScript.UnsetChoosen();
            selectedCategory = null;
            selectedCategoryIndx = -1;
        }
        foreach (Transform child in scrollViewContent)
        {
            Destroy(child.gameObject);
        }
        
        int i = 0;
        foreach (var category in StaticUserData.User.Categories)
        {
            if (IncomeTabOpen && category.Type == CategoryType.Income
                || !IncomeTabOpen && category.Type == CategoryType.Expence)
            {
                var newItem = Instantiate(categoryPrefab, scrollViewContent);
                if (newItem.TryGetComponent<Category>(out var categoryScript2))
                {
                    categoryScript2.ChangeName(category.Name);
                    categoryScript2.SetDbCategory(category);
                }

                int index = i; // Локальная копия переменной для замыкания
                var categoryBtn = newItem.GetComponent<Button>();
                categoryBtn.onClick.AddListener(() => SelectCategory(index, newItem));

                i++;
            }            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (amount.text.Length > 1 && selectedCategory != null && Comment.text.Length > 1)
        {
            addBtn.interactable = true;
        }
        else
        {
            addBtn.interactable = false;
        }
    }

    public void OnIncomeBtnClick()
    {
        IncomeTabOpen = true;

        UpdateCategories();
    }

    public void OnExpenceBtnClick()
    {
        IncomeTabOpen = false;

        UpdateCategories();
    }

    public void SelectCategory(int index, GameObject category)
    {
        if (selectedCategoryIndx == index)
            return;

        if (category.TryGetComponent<Category>(out var categoryScript))
        {
            categoryScript.SetChoosen();
        }
        if (selectedCategory != null
            && selectedCategory.TryGetComponent<Category>(out var categoryScript2))
        {
            categoryScript2.UnsetChoosen();
        }

        selectedCategory = category;
        selectedCategoryIndx = index;
    }

    public void OnAddBtnClick()
    {
        var expence = new Expence();
        float.TryParse(amount.text.Remove(amount.text.Length - 1, 1), out expence.Amount);
        expence.IsIncome = IncomeTabOpen;
        expence.Comment = Comment.text.Remove(Comment.text.Length - 1, 1);
        if (selectedCategory != null
            && selectedCategory.TryGetComponent<Category>(out var categoryScript2))
        {
            expence.Category = categoryScript2.dbCategory;
        }

        StaticUserData.AddExpence(expence);

        var manager = AppManager.instance;
        manager.ChangeSceneTo("MainScene");
    }
}
