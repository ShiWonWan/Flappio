using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
    public AudioSource pointSound, jumpSound, speedSound, deadSound;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Play point sound
    // @param none
    // @return void
    public void playPointSound()
    {
        pointSound.Play();
    }

    // Play point sound
    // @param none
    // @return void
    public void playSpeedSound()
    {
        speedSound.Play();
    }

    // Play jump sound
    // @param none
    // @return void
    public void playJumpSound()
    {
        jumpSound.Play();
    }

    // Play dead sound
    // @param none
    // @return void
    public void playDeadSound()
    {
        deadSound.Play();
    }


}
