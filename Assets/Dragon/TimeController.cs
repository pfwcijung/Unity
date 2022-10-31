using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController Instance;

    void Awake()
    {
        Instance = this;
    }

    [HideInInspector] public float timer = 0f;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
}
