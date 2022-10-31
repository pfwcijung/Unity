using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFloor : MonoBehaviour
{
    Rigidbody floorRight;
    Rigidbody floorLeft;
    // Start is called before the first frame update
    void Start()
    {
        floorLeft = gameObject.transform.GetChild(0).GetComponent<Rigidbody>();
        floorRight = gameObject.transform.GetChild(1).GetComponent<Rigidbody>();

        floorLeft.useGravity = false;
        floorRight.useGravity = false;

        if (Random.Range(0, 2) == 0)
        {
            floorRight.isKinematic = true;
            floorLeft.isKinematic = false;
        }
        else
        {
            floorRight.isKinematic = false;
            floorLeft.isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
