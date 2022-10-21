using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObj: MonoBehaviour
{
    // 0 L / 1 R / 2 F / 3 B
    public int moveArrow = 0;
    float speed = 0;
    float delayTime = 2f;
    float startTime = 0f;
    float deadTime = 8f;

    public void Init(int Arrow, Transform trans)
    {
        float rand = 0f;
        rand = Random.Range(-4.5f, 4.5f);
        switch (Arrow)
        {
            case 0:
            case 1:
                transform.position = new Vector3(trans.position.x, 0f, rand);
                break;
            case 2:
            case 3:
                transform.position = new Vector3(rand, 0f, trans.position.z);
                break;
        }
        speed = Random.Range(5, 10);
        moveArrow = Arrow;
    }

    
    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;

        if (startTime > delayTime)
        {
            switch (moveArrow)
            {
                case 0:
                    transform.Translate(Vector3.left * Time.deltaTime * speed);
                    break;
                case 1:
                    transform.Translate(Vector3.right * Time.deltaTime * speed);
                    break;
                case 2:
                    transform.Translate(Vector3.back * Time.deltaTime * speed);
                    break;
                case 3:
                    transform.Translate(Vector3.forward * Time.deltaTime * speed);
                    break;
            }
        }
        
        if (startTime > delayTime + deadTime)
        {
            Destroy(gameObject);
        }
    }
}
