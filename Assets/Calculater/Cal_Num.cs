using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cal_Num : MonoBehaviour
{
    int Num_1st = 0;
    int Num_2nd = 0;
    int Result = 0;
    int Cal_how = 4;
    bool Act_Num_1st = true;
    bool Act_Num_2nd = false;
    bool Act_setCal = true;
    List<int> calList = new List<int>();

    public TMP_Text verText;
    public TMP_Text calcText;
    public List<Button> buttons = new List<Button>();
    public List<Button> calc = new List<Button>();
    public List<Button> opt = new List<Button>();
    private void Start()
    {
        buttons[0].onClick.AddListener(() => setNum(0));
        buttons[1].onClick.AddListener(() => setNum(1));
        buttons[2].onClick.AddListener(() => setNum(2));
        buttons[3].onClick.AddListener(() => setNum(3));
        buttons[4].onClick.AddListener(() => setNum(4));
        buttons[5].onClick.AddListener(() => setNum(5));
        buttons[6].onClick.AddListener(() => setNum(6));
        buttons[7].onClick.AddListener(() => setNum(7));
        buttons[8].onClick.AddListener(() => setNum(8));
        buttons[9].onClick.AddListener(() => setNum(9));

        calc[0].onClick.AddListener(() => setCal(0));
        calc[1].onClick.AddListener(() => setCal(1));
        calc[2].onClick.AddListener(() => setCal(2));
        calc[3].onClick.AddListener(() => setCal(3));

        opt[0].onClick.AddListener(() => setOpt(0));
        opt[1].onClick.AddListener(() => setOpt(1));
    }
    private void Update()
    {
        string str = "_";
        switch (Cal_how)
        {
            case 0:
                str = "+";
                break;
            case 1:
                str = "-";
                break;
            case 2:
                str = "*";
                break;
            case 3:
                str = "/";
                break;
            case 4:
                str = " ";
                break;
        }
        verText.text = string.Format("{0} {1} {2}", Num_1st, str,  Num_2nd);
    }
    public void setNum(int aNum)
    {
        if (Act_Num_1st)
        {
            Num_1st = Num_1st * 10;
            Num_1st += aNum;
        }
        else if (Act_Num_2nd)
        {
            Num_2nd = Num_2nd * 10;
            Num_2nd += aNum;
        }
    }
    public void setCal(int aCal)
    {
        if (Act_setCal)
        {
            Act_Num_1st = false;
            Act_Num_2nd = true;
            Cal_how = aCal;
            Act_setCal = false;
            calList.Add(Num_1st);
        }
        else if (!Act_setCal)
        {
            Calculate(Cal_how);
            int Ex_Num_1st = Result;
            calList.Add(Num_2nd);
            Clear();
            Num_1st = Ex_Num_1st;
            Act_Num_1st = false;
            Act_Num_2nd = true;
            Cal_how = aCal;
            Act_setCal = false;
        }
    }
    public void setOpt(int aOpt)
    {
        switch (aOpt)
        {
            case 0:
                int aCal = Cal_how;
                Calculate(Cal_how);
                int Ex_Num_1st = Result;
                Clear();
                Num_1st = Ex_Num_1st;
                Act_Num_1st = false;
                Act_Num_2nd = true;
                Cal_how = aCal;
                Act_setCal = false;
                break;
            case 1:
                Clear();
                break;
        }
    }
    void Calculate(int aCal)
    {
        switch (aCal)
        {
            case 0:
                Result = Num_1st + Num_2nd;
                break;
            case 1:
                Result = Num_1st - Num_2nd;
                break;
            case 2:
                Result = Num_1st * Num_2nd;
                break;
            case 3:
                Result = Num_1st / Num_2nd;
                break;
        }
        ShowResult();
    }
    void ShowResult()
    {
        calcText.text = string.Format("Result : {0}", Result);
    }
    void Clear()
    {
        Num_1st = 0;
        Num_2nd = 0;
        Result = 0;
        Cal_how = 4;
        Act_Num_1st = true;
        Act_Num_2nd = false;
    }
}
