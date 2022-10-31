using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCapsule : MonoBehaviour
{
    public enum Type
    {
        Attack,
        Speed,
        Move
    }

    public Type type = Type.Move;

    float rotationZ = 0;

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 1f);
    }
}
