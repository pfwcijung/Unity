using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AIReportStudy : MonoBehaviour
{
    [SerializeField]
    private TMP_Text StudyTimeTxt;
    [SerializeField]
    private TMP_Text DateTxt;
    [SerializeField]
    private TMP_Text AvgTimeTxt;
    [SerializeField]
    private TMP_Text AvgTime2Txt;
    [SerializeField]
    private TMP_Text PercentTodoTxt;
    [SerializeField]
    private TMP_Text PercentCorrectTxt;

    [SerializeField]
    private Image PercentTodo;
    [SerializeField]
    private Image PercentCorrect;

    public GameObject obj;

    float curTodo = 70;
    float curCorrect = 80;

    float maxTodo = 100;
    float maxCorrect = 100;

    float StudyTime = 1340;
    float StudyTimeHour = 0;
    float StudyTimeMinute = 0;

    int Date = 75;
    float ActiveCount = 20;

    float avgJipJung = 75;
    float curJipJung = 100;

    // Start is called before the first frame update
    void Start()
    {
        Date = Random.Range(50, 100);
        PercentTodo.fillAmount = curTodo / maxTodo;
        PercentCorrect.fillAmount = curCorrect / maxCorrect;
        StudyTimeCal();
        float x1 = avgJipJung - curJipJung;
        obj.transform.rotation = Quaternion.Euler(0, 0, x1);
    }

    // Update is called once per frame
    void Update()
    {
        PercentCorrectTxt.text = string.Format("{0:0}%", (curCorrect / maxCorrect) * 100);
        PercentTodoTxt.text = string.Format("{0:0}%", (curTodo / maxTodo) * 100);

        StudyTimeTxt.text = string.Format("{0:0}�ð� {1:0}��", StudyTimeHour, StudyTimeMinute);
        DateTxt.text = string.Format("{0:0}��", Date);
        AvgTimeTxt.text = string.Format("1�� ��� || {0:0}��", StudyTime / Date);
        AvgTime2Txt.text = string.Format("1ȸ ��� || {0:0}��", StudyTime / ActiveCount);

    }

    void StudyTimeCal()
    {
        StudyTimeHour = StudyTime / 60;
        StudyTimeMinute = StudyTime % 60;
    }
}
