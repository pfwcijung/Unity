using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonPlayer : MonoBehaviour
{
    public Text timeText;

    public GameObject bulletObj;
    float autoFireTime = 0;

    float speed = 5f;

    int tmpBulletDamage = 0;

    // Update is called once per frame
    void Update()
    {
        // 郴醚舅 积己 
        autoFireTime += Time.deltaTime;
        if(autoFireTime > 0.2f)
        {
            GameObject obj = Instantiate(bulletObj);
            obj.GetComponent<Bullet1>().SetDamage(tmpBulletDamage);
            float x1 = transform.position.x;
            float y1 = transform.position.y;
            float z1 = transform.position.z;

            obj.transform.position = new Vector3(x1, y1 + 2, z1);
            autoFireTime = 0;
        }
        // 厘局拱 积己
        timeText.text = $"{string.Format("{0:0.00}", TimeController.Instance.timer)}";
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 dir = new Vector3(x, 0f, 0f);
        if (transform.position.x > 4)
        {
            transform.position = new Vector3(4, -6, 5);
            return;
        }
        if (transform.position.x < -4)
        {
            transform.position = new Vector3(-4, -6, 5);
            return;
        }
        transform.position += dir * Time.deltaTime * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AItem")
        {
            switch(other.GetComponent<ItemCapsule>().type)
            {
                case ItemCapsule.Type.Attack:
                    {
                        tmpBulletDamage += 10;
                    }
                    break;

                case ItemCapsule.Type.Move:
                    break;

                case ItemCapsule.Type.Speed:
                    break;
            }
            Destroy(other.gameObject);
            return;
        }

        Debug.Log(" You Die");
        Time.timeScale = 0;
    }
}
