using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageStudy : MonoBehaviour
{
    [SerializeField]
    private Image hpImage;
    [SerializeField]
    private Image mpImage;
    [SerializeField]
    private Image skillDelayImage;
    [SerializeField]
    private TMP_Text skillDelay;

    float curHP = 100;
    float maxHP = 100;
    
    float curMp = 50;
    float maxMp = 50;

    float curSkillTime = 0f;
    float maxSkillTime = 3f;

    int level = 1;

    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        hpImage.fillAmount = curHP / maxHP;
        mpImage.fillAmount = curMp / maxMp;
        skillDelayImage.fillAmount = curSkillTime / maxSkillTime;
        skillDelay.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            curHP += 10;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            curHP -= 10;
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            if(curMp < 0)
                curMp = 0;
            else
                curMp -= 10;
            StopCoroutine("AutoMpRecovery");
            StartCoroutine("AutoMpRecovery");
            //StopCoroutine(AutoMpRecovery());
            //StartCoroutine(AutoMpRecovery());
            //문자열로 들어가야 일정한 속도로 함수가 실행된다
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            if (curSkillTime == 0f)
            {
                StartCoroutine(SkillDelayRecovery());
            }
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            maxMp += Random.Range(10, 15);
            maxMp += Random.Range(5, 10);
            level++;
        }

        hpImage.fillAmount = curHP / maxHP;
        mpImage.fillAmount = curMp / maxMp;
    }
    IEnumerator AutoMpRecovery()
    {
        for (int i = 0; i < 10; i++)
        {
            if (curMp < maxMp)
            {
                curMp += 2;
                mpImage.fillAmount = curMp / maxMp;
            }
            yield return new WaitForSeconds(0.2f);
        }

        yield return null;
    }
    // 1->0 값 이동
    IEnumerator SkillDelayRecovery()
    {
        skillDelayImage.fillAmount = 1f;
        curSkillTime = maxSkillTime;
        skillDelay.enabled = true;
        float time = maxSkillTime;

        while (curSkillTime > 0)
        {
            skillDelay.text = string.Format("{0}", (int)time);
            curSkillTime -= 0.1f;
            time -= 0.1f;
            skillDelayImage.fillAmount = curSkillTime / maxSkillTime;
            yield return new WaitForSeconds(0.01f);
        }

        curSkillTime = 0f;
        skillDelay.enabled = false;
        skillDelayImage.fillAmount = 0f;
    }
}
