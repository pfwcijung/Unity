using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputFieldStudy : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputField_1st;
    [SerializeField]
    private TMP_InputField inputField_2nd;
    [SerializeField]
    private TMP_Text ResultText;

    int num1st = 0;
    int num2nd = 0;
    string str;

    bool isClick = false;

    private void Start()
    {
        Debug.Log("Start");
    }
    public void onSelect_1st()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("tab");
            inputField_2nd.ActivateInputField();
        }
    }
    public void OnValueChangeEnd_1st()
    {
        num1st = int.Parse(inputField_1st.text);
    }
    public void OnValueChangeEnd_2nd()
    {
        num2nd = int.Parse(inputField_2nd.text);
    }
    public void onClick()
    {
        if (!isClick)
        {
            if (num1st < num2nd && num1st > 0)
            {
                for (int i = 1; i < 10; i++)
                {
                    for (int j = num1st; j <= num2nd; j++)
                    {
                        str += ($"{j} * {i} = {i * j} \t");
                    }
                    str += "\n";
                }
                ResultText.text = string.Format(str);
                isClick = true;
            }
            else
            {
                ResultText.text = string.Format("�� ���� ���ڸ� �Է��߽��ϴ�.\n�ٽ� �Է����ּ���.");
            }
        }
    }

    public void onGameClear()
    {
        str = "";
        ResultText.text = string.Format(str);
        isClick = false;
    }
}
