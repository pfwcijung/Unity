using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingObj_Front: MonoBehaviour
{
    float speed = 3;
    public float delayTime = 3f;
    float startTime = 0f;
    float deadTime = 8f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;

        if (startTime > delayTime)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (startTime > delayTime + deadTime)
        {
            Destroy(gameObject);
        }
    }
}
