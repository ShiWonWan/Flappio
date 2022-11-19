using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float jumpPower = 15f;
    public float gravityScale = 5f;

    private Vector3 moveDirection;
    public CharacterController charController;

    public bool isOnStart = true;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (!isOnStart)
            doJump();
    }

    // Manage Player Jump
    private void doJump()
    {
        // Store Y value
        float yStore = moveDirection.y;
        moveDirection.y = yStore;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveDirection.y = jumpPower;

            // Play sound
            SFXManager.instance.playJumpSound();
        }


        // Set Y value with gravity implemented.=
        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

        // Move the player with the previous calculated values
        charController.Move(moveDirection * Time.deltaTime);
    }


}
