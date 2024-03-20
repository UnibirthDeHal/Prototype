using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    public Control_Player player;

    Slider hpSlider;
    Text hpText;

    //float hp = 100f;

    // Start is called before the first frame update
    void Start()
    {
        hpSlider = GetComponent<Slider>();

        if (player)
        {
            hpSlider.maxValue = player.hp_max;
            hpSlider.value = player.hp_cur;
        }

        //hpSlider.maxValue = hp;
        //hpSlider.value = hp;

        hpText = transform.Find("HPText").GetComponent<Text>();
        hpText.text = "HP　" + hpSlider.value.ToString() + "/" + hpSlider.maxValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    hp -= 10f;
        //    hpSlider.value = hp;
        //    hpText.text = "HP　" + hpSlider.value.ToString() + "/" + hpSlider.maxValue.ToString();
        //}

    }

    //HPデータを更新
    public void RefreshHealth()
    {
        if (player) 
        {
            hpSlider.maxValue = player.hp_max;
            hpSlider.value = player.hp_cur;
            hpText.text = "HP　" + hpSlider.value.ToString() + "/" + hpSlider.maxValue.ToString();
        }
    }

}
