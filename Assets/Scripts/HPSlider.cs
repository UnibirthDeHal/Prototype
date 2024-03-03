using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    Slider hpSlider;
    Text hpText;

    float hp = 100f;

    // Start is called before the first frame update
    void Start()
    {
        hpSlider = GetComponent<Slider>();
        hpSlider.maxValue = hp;
        hpSlider.value = hp;

        hpText = transform.Find("HPText").GetComponent<Text>();
        hpText.text ="HPÅ@" + hpSlider.value.ToString() + "/" + hpSlider.maxValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            hp -= 10f;
            hpSlider.value = hp;
            hpText.text = "HPÅ@" + hpSlider.value.ToString() + "/" + hpSlider.maxValue.ToString();
        }
        
    }
}
