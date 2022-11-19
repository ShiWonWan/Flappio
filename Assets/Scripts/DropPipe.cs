using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPipe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Delete pipe
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pipe")
        {
            Destroy(other.gameObject);
        }
    }
}
