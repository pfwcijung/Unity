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
    public Image[] images;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (lifeCount <= 0)
        {
            return;
        }

        timeText.text = string.Format("{0:0.00}", TimeController.Instance.timer);

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

        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("Game Clear!!");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isJump = false;
    }
}
