using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public Transform parent;
    public GameObject enemy;

    float time = 0f;
    float delayTime = 2f;

    int spawnCount = 0;
    int spawnArrow = 0;

    const int spawnMaxCount = 16;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(7f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (spawnArrow <= spawnMaxCount)
        {
            Create();
            time = 0f;
            spawnCount++;
        }
    }

    void Create()
    {
        if (spawnCount != 0 && spawnCount % (spawnMaxCount / 4) == 0)
        {
            spawnArrow++;

            if (spawnArrow == 1)
            {
                transform.position = new Vector3(-7f, 0f, 0f);
            }
            else if(spawnArrow == 2)
            {
                transform.position = new Vector3(0f, 0f, 7f);
            }
            else
            {
                transform.position = new Vector3(0f, 0f, -7f);
            }
        }
        GameObject obj = Instantiate(enemy, parent);
        obj.GetComponent<EnemyObj>().Init(spawnArrow, transform);
    }
}
