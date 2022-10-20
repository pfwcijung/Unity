using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObj : MonoBehaviour
{
    public Transform trans;
    float speed = 3f;
    int Hp = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float hol = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(hol, 0f, ver);
        trans.Translate(dir * Time.deltaTime * speed);

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Hp -= 10;
        Debug.Log($"HP : {Hp}");
        
        if (Hp <= 0)
        {
            Destroy(trans.gameObject);
            Debug.Log("Game Over");
        }
    }
}
