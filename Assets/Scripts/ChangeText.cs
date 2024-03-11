using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Text cangeText;
    // Start is called before the first frame update
    void Start()
    {
        cangeText.text = "HEAD　HUMAN\nBODY　HUMAN\nHAND　HUMAN\nHAND　NONE\nFOOT　HUMAN\nFOOT　NONE";
    }

    // Update is called once per frame
    void Update()
    {
        cangeText.text = "HEAD　HUMAN\nBODY　HUMAN\nHAND　HUMAN\nHAND　NONE\nFOOT　HUMAN\nFOOT　NONE";
    }
}
