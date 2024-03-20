using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//===================================================================
//  頭(Head)の管理（継承して管理したほうがいい）
//===================================================================

public class UI_State_Head : MonoBehaviour         
{
    Control_Player player;
    [HideInInspector] public string state_name;
    [HideInInspector] public Text cangeText;

    //public Image part_image;

    public Sprite[] sprites_head;



    // Start is called before the first frame update
    void Start()
    {
        state_name = "HUMAN";
        cangeText.text = "HEAD　" + state_name;
        //part_image= this.GetComponent<Sprite>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePart(string new_state)
    {
        if (new_state == "Dragon")
        {
            state_name = "DRAGON";
            cangeText.text = "HEAD　" + state_name;
            this.gameObject.GetComponent<Image>().sprite = sprites_head[1];
           
        }
        else if (new_state == "Fish")
        {
            state_name = "FISH";
            cangeText.text = "HEAD　" + state_name;
            this.gameObject.GetComponent<Image>().sprite = sprites_head[2];
        }
    }

}
