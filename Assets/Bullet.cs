using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    FireArrow fireArrow = FireArrow.None;
    float speed = 1;
    [HideInInspector]
    public int damage = 20;

    // Update is called once per frame
    void Update()
    {
        if (fireArrow == FireArrow.None)
            return;

        switch(fireArrow)
        {
            case FireArrow.Up:
                transform.Translate(Vector3.up * Time.deltaTime * speed);
                break;
            case FireArrow.Down:
                transform.Translate(Vector3.down * Time.deltaTime * speed);
                break;
            case FireArrow.Left:
                transform.Translate(Vector3.left * Time.deltaTime * speed);
                break;
            case FireArrow.Right:
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                break;
            case FireArrow.Forward:
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                break;
            case FireArrow.Back:
                transform.Translate(Vector3.back * Time.deltaTime * speed);
                break;
        }
    }

    public Bullet SetArrow(FireArrow arrow)
    {
        fireArrow = arrow;
        return this;
    }

    public Bullet SetSpeed(float spd)
    {
        speed = spd;
        return this;
    }
}
