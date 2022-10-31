using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField] private GameObject itemObj;
    public List<GameObject> objs = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        // int rand = Random.Range(0, objs.Count);
        // Destroy(objs[rand]);
        int hp = (int)TimeController.Instance.timer;
        foreach(var item in objs)
        {
            item.GetComponent<Enemy>()
                .SetHP(hp)
                .SetItemObj(itemObj);
        }
    }
    
    /*
     * 여러줄의 주석
     * 
    */

    // 한줄의 주석

    float time = 0;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 5f);

        time += Time.deltaTime;
        if(time > 5)
        {
            Destroy(gameObject);
        }
    }
}
