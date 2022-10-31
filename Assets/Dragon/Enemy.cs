using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int hp = 0;

    GameObject itemObj;

    // 체력 셋팅
    public Enemy SetHP(int aHP)
    {
        if (aHP > 500)
        {
            hp = 500;
        }

        hp = aHP;

        return this;
    }

    public Enemy SetItemObj(GameObject obj)
    {
        itemObj = obj;
        return this;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            hp -= other.GetComponent<Bullet1>().damage;

            if(hp <= 0)
            {
                GameObject obj = Instantiate(itemObj, transform);
                obj.transform.SetParent(null);

                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
