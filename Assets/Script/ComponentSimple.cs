using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentSimple : MonoBehaviour
{
    float speed = 3;
    public float delayTime = 3f;
    float time = 0f;
    float deadTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > delayTime)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if(time > delayTime + deadTime)
        {
            Destroy(gameObject);
        }
    }
}
