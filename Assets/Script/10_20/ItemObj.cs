using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObj : MonoBehaviour
{
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject)
        {
            Destroy(gameObject);
            score += 10;
            if (score >= 50)
            {
                Debug.Log("Game Clear");
            }
        }
    }
}
