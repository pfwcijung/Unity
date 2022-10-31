using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanEnemy : MonoBehaviour
{
    public GameObject prefab;

    float delayTime = 3;
    float time = 100f;
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
            Instantiate(prefab, transform);
            time = 0;
        }
    }
}
