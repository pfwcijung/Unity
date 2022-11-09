using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderStudy : MonoBehaviour
{
    [SerializeField]
    private TMP_Text sliderText;
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private TMP_Text autoSliderText;
    [SerializeField]
    private Slider autoSlider;

    int maxCount = 2;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        autoSlider.value = 0;
        Invoke("MainAutoSlider", 2f);
        //InvokeRepeating("MainAutoSlider", 2f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        sliderText.text = string.Format("{0:0}%", slider.value * 100);
    }

    void MainAutoSlider()
    {
        if(count > maxCount)
        {
            CancelInvoke("MainAutoSlider");
            return;
        }
        StartCoroutine("AutoSlider");
        count++;
    }

    IEnumerator AutoSlider()
    {
        float max = 100;
        for(int i = 0; i <= max; i++)
        {
            autoSliderText.text = string.Format("{0:0}%", autoSlider.value * 100);
            autoSlider.value = (float)i / max;
            yield return new WaitForSeconds(0.1f);
        }
        //yield return new WaitForSeconds(2f);
        //autoSlider.value = 0;
        //StartCoroutine("AutoSlider");
    }
}
