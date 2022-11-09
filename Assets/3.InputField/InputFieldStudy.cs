using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputFieldStudy : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputField;

    public void OnValueChangeEnd()
    {
        Debug.Log(inputField.text);
    }
}
