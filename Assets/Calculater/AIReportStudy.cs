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

    float Date = 75;
    float ActiveCount = 20;

    float avgJipJung = 75;
    float curJipJung = 150;

    // Start is called before the first frame update
    void Start()
    {
        PercentTodo.fillAmount = curTodo / maxTodo;
        PercentCorrect.fillAmount = curCorrect / maxCorrect;
        StudyTimeCal();
        float x1 = curJipJung - avgJipJung;
        obj.transform.position = new Vector3(200f + x1, 40f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        PercentCorrectTxt.text = string.Format("{0:0}%", (curCorrect / maxCorrect) * 100);
        PercentTodoTxt.text = string.Format("{0:0}%", (curTodo / maxTodo) * 100);

        StudyTimeTxt.text = string.Format("{0:0}시간 {1:0}분", StudyTimeHour, StudyTimeMinute);
        DateTxt.text = string.Format("{0:0}일", Date);
        AvgTimeTxt.text = string.Format("1일 평균 || {0:0}분", StudyTime / Date);
        AvgTime2Txt.text = string.Format("1회 평균 || {0:0}분", StudyTime / ActiveCount);

    }

    void StudyTimeCal()
    {
        StudyTimeHour = StudyTime / 60;
        StudyTimeMinute = StudyTime % 60;
    }
}
