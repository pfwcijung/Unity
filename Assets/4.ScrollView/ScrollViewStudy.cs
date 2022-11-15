using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewStudy : MonoBehaviour
{
    [SerializeField]
    private Transform parent;
    [SerializeField]
    private GameObject itemObj;
    [SerializeField]
    private Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            Sprite sprite = sprites[Random.Range(0, sprites.Length)];
            Instantiate(itemObj, parent).GetComponent<ScrollViewItemStudy>().Init(sprite, i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
