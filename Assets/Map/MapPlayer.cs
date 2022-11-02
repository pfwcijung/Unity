using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapPlayer : MonoBehaviour
{
    Rigidbody rigid;
    float JumpPower = 5f;
    bool isJump = false;
    int lifeCount = 3;

    // TextMestProUGUI ==
    public TMP_Text timeText;
    public TMP_Text highScoreText;
    public Image[] images;

    bool isFinish = false;

    float highTime = 0;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();

        //내 컴퓨터에 저장된 키가 있는지 확인
        if (PlayerPrefs.HasKey("MapTime") == false)
        {
            highScoreText.text = $"HighScore:0.00";
        }
        else
        {
            highTime = PlayerPrefs.GetFloat("MapTime");
            highScoreText.text = string.Format("High Score:{0:0.00}", highTime);
        }
    }
    void Update()
    {
        if (lifeCount <= 0)
        {
            return;
        }
        if(isFinish == false)
        {
            timeText.text = string.Format("{0:0.00}", TimeController.Instance.timer);
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 pos = new Vector3(x, 0f, z);
        transform.Translate(pos * Time.deltaTime * 3f);

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isJump)
        {
            rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJump = true;
        }

        if (collision.gameObject.name == "Bottom")
        {
            lifeCount--;

            if(lifeCount >= 0)
            {
                images[lifeCount].gameObject.SetActive(false);
            }

            if(lifeCount <= 0)
            {
                return;
            }

            transform.position = new Vector3(0, 1.5f, 0);
            return;
        }

        if (collision.gameObject.tag == "Goal" && isFinish == false)
        {
            isFinish = true;
            Debug.Log("Game Clear!!");
            float finishTime = TimeController.Instance.timer;

            if (highTime == 0)
            {
                PlayerPrefs.SetFloat("MapTime", finishTime);
            }
            else if(highTime > finishTime)
            {
                PlayerPrefs.SetFloat("MapTime", finishTime);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isJump = false;
    }

    public void OnClick()
    {
        transform.position = new Vector3(0f, 1.5f, 0f);
        lifeCount = 3;
        foreach(var item in images)
        {
            item.gameObject.SetActive(true);
        }
    }
}
