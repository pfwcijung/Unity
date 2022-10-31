using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraMoving : MonoBehaviour
{
    Camera camera;

    public Transform target1;
    public Transform target2;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.Lerp(transform.position, target2.position, Time.deltaTime * 2f));
    }
}
