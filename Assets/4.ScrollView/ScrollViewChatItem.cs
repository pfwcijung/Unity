using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScrollViewChatItem : MonoBehaviour
{
    [SerializeField]
    private TMP_Text chatTxt;
    [SerializeField]
    private TMP_Text todayTxt;

    public ScrollViewChatItem SetText(string txt)
    {
        chatTxt.text = txt;
        return this;
    }
    public ScrollViewChatItem SetTodayText()
    {
        DateTime dt = DateTime.Now;

        todayTxt.text = string.Format("{0:00}½Ã {1:00}ºÐ", dt.Hour, dt.Minute);
        return this;
    }
}
