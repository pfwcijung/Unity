using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    public Transform trans;
    private float speed = 3f;
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

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
    }
}
