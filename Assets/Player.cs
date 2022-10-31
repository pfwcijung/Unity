using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp = 100;
    // Update is called once per frame
    Vector3 lookDir;
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, 0f, y);
        lookDir = x * Vector3.forward + y * Vector3.left;

        if (!(x == 0 && y == 0))
        {
            transform.position += dir * Time.deltaTime * 3f;
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.LookRotation(lookDir),
                Time.deltaTime * 100f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Debug.LogWarning(" Å¸°Ý ¹Þ¾Ñ´Ù ");
            hp -= other.GetComponent<Bullet>().damage;
            if(hp <= 0)
            {
                Debug.LogError(" You Die!! ");
                Destroy(gameObject);
            }
            else
            {
                Destroy(other.gameObject);
            }
            return;
        }

        if(other.tag == "Portal")
        {
            transform.position = other.GetComponent<Portal>().nextPos;
            Destroy(other.gameObject);
            return;
        }

        if(other.gameObject.name == "Finish")
        {
            Destroy(other.gameObject);
            Time.timeScale = 0;
            Debug.Log(" !!!!!!!!!! Game Clear !!!!!!!!!!!!!!!!");
        }
    }
}
