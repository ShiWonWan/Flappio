using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    private Vector3 respawnPosition;


    // Start is called before the first frame update
    void Start()
    {
        respawnPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        // When the player hit the kill area, respawn it
        if (other.tag == "Player")
        {
            SFXManager.instance.playDeadSound();
            GameManager.instance.Respawn();
        }
    }

}
