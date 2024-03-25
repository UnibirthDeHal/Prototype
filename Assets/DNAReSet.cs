using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNAReSet : MonoBehaviour
{
    public GameObject dragon;
    public GameObject fish;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(dragon, new Vector3(43.5f, -3.0f, 0.0f), Quaternion.identity);
        Instantiate(dragon, new Vector3(47.5f, -3.0f, 0.0f), Quaternion.identity);
        Instantiate(fish, new Vector3(45.5f, -3.0f, 0.0f), Quaternion.identity);
        Instantiate(fish, new Vector3(49.5f, -3.0f, 0.0f), Quaternion.identity);
    }
}
