using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FireArrow
{
    None,
    Up,
    Down,
    Forward,
    Back,
    Left,
    Right
}

public enum GameState
{
    Play,
    Pause,
    Stop,
    None,
}

public class BulletManager : MonoBehaviour
{
    public GameObject prefab;

    // 0~6
    public int fireArrow_ = 0;
    public FireArrow fireArrow = FireArrow.None;

    public int firstFireTime = 0;
    public int delayFire = 0;

    float time = 10;
    void Update()
    {
        time += Time.deltaTime;
        if(time > delayFire)
        {
            if(Random.Range(1, 10) < 3)
            {
                Instantiate(prefab, transform)
                    .GetComponent<Bullet>()
                    .SetArrow(fireArrow)
                    .SetSpeed(Random.Range(1, 10));
            }
            else
            {
                Instantiate(prefab, transform)
                    .GetComponent<Bullet>()
                    .SetArrow(fireArrow);
            }
            time = 0;
        }
    }
}
