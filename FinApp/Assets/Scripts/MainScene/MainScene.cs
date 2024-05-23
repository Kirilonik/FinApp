using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainScene : MonoBehaviour
{
    public GameObject inputDropdown;
    public GameObject expensesDropdown;
    public bool isInputDropdownOpen;
    public bool isExpensesDropdownOpen;
    public TMP_Text inputArrow;
    public TMP_Text expensesArrow;
    public TextMeshProUGUI amount;
    public Transform ExpencesScrollViewContent;
    public GameObject ExpencePrefab;
    public Transform IncomeScrollViewContent;
    public TextMeshProUGUI incomeAmountTmp;
    public TextMeshProUGUI expenceAmountTmp;

    // Start is called before the first frame update
    void Start()
    {
        isInputDropdownOpen = false;
        isExpensesDropdownOpen = false;

        UpdateExpences();
    }

    void UpdateExpences()
    {
        foreach (Transform child in ExpencesScrollViewContent)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in IncomeScrollViewContent)
        {
            Destroy(child.gameObject);
        }

        int i = 0;
        foreach (var expence in StaticUserData.User.Expences)
        {
            if (!expence.IsIncome)
            {
                var newItem = Instantiate(ExpencePrefab, ExpencesScrollViewContent);
                if (newItem.TryGetComponent<ExpencesScript>(out var expencesScript))
                {
                    expencesScript.SetComment(expence.Comment);
                    expencesScript.SetAmount(expence.Amount);
                    expencesScript.SetCategory(expence.Category.Name);
                }

                i++;
            }
            else
            {
                var newItem = Instantiate(ExpencePrefab, IncomeScrollViewContent);
                if (newItem.TryGetComponent<ExpencesScript>(out var expencesScript))
                {
                    expencesScript.SetComment(expence.Comment);
                    expencesScript.SetAmount(expence.Amount);
                    expencesScript.SetCategory(expence.Category.Name);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        amount.text = StaticUserData.User.Money.ToString("0.00");

        float income = 0f;
        float expences = 0f;

        foreach (var expence in StaticUserData.User.Expences)
        {
            if (expence.IsIncome)
                income += expence.Amount;
            else
                expences += expence.Amount;
        }

        incomeAmountTmp.text = income.ToString();
        expenceAmountTmp.text = expences.ToString();
    }

    public void OnInputDropdownBtnClick()
    {

        inputDropdown.SetActive(!isInputDropdownOpen);
        isInputDropdownOpen = !isInputDropdownOpen;
        inputArrow.text = isInputDropdownOpen ? "▲" : "▼";
    }
    public void OnExpensesDropdownBtnClick()
    {
        expensesDropdown.SetActive(!isExpensesDropdownOpen);
        isExpensesDropdownOpen = !isExpensesDropdownOpen;
        expensesArrow.text = isExpensesDropdownOpen ? "▲" : "▼";
    }
}
