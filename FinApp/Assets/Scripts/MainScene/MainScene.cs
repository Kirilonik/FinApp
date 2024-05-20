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

    // Start is called before the first frame update
    void Start()
    {
        isInputDropdownOpen = false;
        isExpensesDropdownOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
