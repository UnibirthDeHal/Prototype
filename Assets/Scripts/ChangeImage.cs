using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Sprite Human;
    public Sprite Dragon;
    public Sprite Fish;

    Color imagecolor = new Color();
    // Start is called before the first frame update
    void Start()
    {
        imagecolor.a = 0;
        this.GetComponent<Image>().sprite = Human;

        if (this.GetComponent<Image>().sprite == null)
        {
            this.GetComponent<Image>().color = imagecolor;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangePartImage(int state)
    {
        switch (state)
        {
            case 0:
                this.GetComponent<Image>().sprite = Human;
                break;
            case 1:
                this.GetComponent<Image>().sprite = Dragon;
                break;
            case 2:
                this.GetComponent<Image>().sprite = Fish;
                break;
        }

        if (this.GetComponent<Image>().sprite == null)
        {
            this.GetComponent<Image>().color = imagecolor;
        }
    }
}
