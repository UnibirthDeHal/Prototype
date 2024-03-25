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
        Instantiate(dragon, new Vector3(-4.5f, 1.0f, 0.0f), Quaternion.identity);
        Instantiate(dragon, new Vector3(-6.5f, 1.0f, 0.0f), Quaternion.identity);
        Instantiate(fish, new Vector3(-8.5f, 1.0f, 0.0f), Quaternion.identity);
        Instantiate(fish, new Vector3(-10.5f, 1.0f, 0.0f), Quaternion.identity);
    }
}
