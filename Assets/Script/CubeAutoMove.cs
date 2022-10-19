using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAutoMove : MonoBehaviour
{
    public Transform trans;

    private float r = 0f;
    private float z = 0f;
    private bool reverse_scale = true;
    // Start is called before the first frame update
    void Start()
    {
        //위치
        trans.position = new Vector3(3, 0, 0);
        //크기
        trans.localScale = Vector3.zero;
        //회전
        trans.localRotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //trans.localRotation = Quaternion.Euler(r, r, r);
        r += 0.05f;
        trans.localScale = new Vector3(1, 1, z);
        if (reverse_scale)
        {
            z += 0.01f;
            if (z >= 3)
                reverse_scale = false;
        }
        else
        {
            z -= 0.01f;
            if (z <= 0)
                reverse_scale = true;
        }
    }
}
