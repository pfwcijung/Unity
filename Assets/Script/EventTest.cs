using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.name.Equals("Plane"))
        {
            Debug.Log("CollisionEnter " + collision.gameObject.name);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.name.Equals("Plane"))
        {
            Debug.Log("CollisionStay " + collision.gameObject.name);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!collision.gameObject.name.Equals("Plane"))
        {
            Debug.Log("CollisionExit " + collision.gameObject.name);
        }
    }
}
