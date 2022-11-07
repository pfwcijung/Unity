using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleUI : MonoBehaviour
{
    public enum ToggleType
    {
        None,
        Weapon,
        Armor,
        Etc,
        Potion
    }

    private ToggleType toggleType = ToggleType.Weapon;
    private ToggleType currentType = ToggleType.None;

    [SerializeField] private Image hpImage;

    float currentHP = 0;
    float maxHP = 0;

    float level = 1;
    const float addHP = 10;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = 100;
        hpImage.fillAmount = currentHP / maxHP;
        toggleType = ToggleType.Weapon; 
        currentType = ToggleType.None;
    }

    // Update is called once per frame
    void Update()
    {
        //add HP
        if (Input.GetKeyDown(KeyCode.F1))
        {
            currentHP += addHP;
            hpImage.fillAmount = currentHP / maxHP;
        }
        //minus HP
        if (Input.GetKeyDown(KeyCode.F2))
        {
            currentHP -= addHP;
            hpImage.fillAmount = currentHP / maxHP;
        }
        //Level UP
        if (Input.GetKeyDown(KeyCode.F3))
        {
            maxHP += addHP;
            level++;
            hpImage.fillAmount = currentHP / maxHP;
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            Debug.Log($"curHp = {currentHP}, maxHp = {maxHP}, level = {level}");
        }
    }

    public void OnToggle(Toggle toggle)
    {
        if (toggle.isOn)
        {
            if(currentType == toggleType)
            {
                return;
            }
            else
            {
                switch (toggle.name)
                {
                    case "Toggle":
                        currentType = toggleType = ToggleType.Weapon;
                        break;
                    case "Toggle (1)":
                        currentType = toggleType = ToggleType.Armor;
                        break;
                    case "Toggle (2)":
                        currentType = toggleType = ToggleType.Etc;
                        break;
                    case "Toggle (3)":
                        currentType = toggleType = ToggleType.Potion;
                        break;
                }
                Debug.Log(toggle.name);
            }           
        }
    }
}
