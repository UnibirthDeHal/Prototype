using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BURDENSlider : MonoBehaviour
{
    Slider burdenSlider;
    Text burdenText;

    public float burden = 0f;
    public bool ischange=false;
    // Start is called before the first frame update
    void Start()
    {
        burdenSlider = GetComponent<Slider>();
        burdenSlider.minValue = burden;
        burdenSlider.maxValue = 100f;
        burdenSlider.value = burden;

        burdenText = transform.Find("BURDENText").GetComponent<Text>();
        burdenText.text = "BURDENÅ@" + burdenSlider.value.ToString() + "/" + burdenSlider.maxValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (ischange == true) 
        {
            burdenSlider.value = burden;
            burdenText.text = "BURDENÅ@" + burdenSlider.value.ToString() + "/" + burdenSlider.maxValue.ToString();
            ischange = false;
        }
    }
}
