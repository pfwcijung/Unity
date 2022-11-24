using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollViewChat : MonoBehaviour
{
    [SerializeField]
    private Transform parent;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private TMP_InputField inputField;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            OnInputEnd();
        }
    }

    public void OnInputEnd()
    {
        GameObject obj = Instantiate(prefab, parent);

            obj.GetComponent<ScrollViewChatItem>()
            .SetText(inputField.text)
            .SetTodayText();

        obj.transform.SetAsFirstSibling();

        inputField.text = "";
    }
}
