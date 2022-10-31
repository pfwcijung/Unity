using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    float removeTimer = 0f;

    [HideInInspector]
    public int damage = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 7f);
        removeTimer += Time.deltaTime;
        if(removeTimer > 10)
        {
            Destroy(gameObject);
        }    
    }

    public void SetDamage(int aDamage)
    {
        damage += aDamage;
    }
}
