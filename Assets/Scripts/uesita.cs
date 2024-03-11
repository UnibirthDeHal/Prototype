using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uesita : MonoBehaviour
{
    public float speed = 2.0f; // ˆÚ“®‘¬“x
    public float height = 0.5f; // ˆÚ“®‚Ì‚‚³

    private Vector3 startPos; // ‰ŠúˆÊ’u

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // ã‰º‚É“®‚­“®‚«‚ğ‚Â‚¯‚é
        transform.position = startPos + new Vector3(0, Mathf.Sin(Time.time * speed) * height, 0);
    }
}

