using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayer : MonoBehaviour
{
    Rigidbody rigid;
    float JumpPower = 5f;
    bool isJump = false;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 pos = new Vector3(x, 0f, z);
        transform.Translate(pos * Time.deltaTime * 3f);

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isJump)
        {
            rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            transform.position = new Vector3(0, 1.5f, 0);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJump = true;
        }
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("Game Clear!!");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isJump = false;
    }
}
