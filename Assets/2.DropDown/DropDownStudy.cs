using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DropDownStudy : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown dropdown;

    string[] str = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K" };

    // Start is called before the first frame update
    void Start()
    {
        dropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> optionDatas = new List<TMP_Dropdown.OptionData>();
        for(int i = 0; i < str.Length; i++)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            data.text = str[i];
            optionDatas.Add(data);
        }
        dropdown.AddOptions(optionDatas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnValueChange()
    {
        Debug.Log(str[dropdown.value]);
    }
}
