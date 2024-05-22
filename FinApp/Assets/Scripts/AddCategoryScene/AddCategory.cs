using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.IO;
using SFB;
using TMPro;

public class AddCategory : MonoBehaviour
{
    public TextMeshProUGUI nameTmp;
    public TMP_Dropdown typeDrp;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnAddCategotyClick()
    {
        if (nameTmp.text.Length > 0)
        {
            var category = new ExpenceCategory();
            category.Name = nameTmp.text.Remove(nameTmp.text.Length - 1, 1);
            category.Type = typeDrp.value == 0 ? CategoryType.Income : CategoryType.Expence; 

            StaticUserData.AddUserCategory(category);

            var manager = AppManager.instance;
            manager.ChangeSceneTo("AddExpenceScene");
        }
    }
}
