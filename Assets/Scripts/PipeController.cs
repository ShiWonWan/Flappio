using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PipeController : MonoBehaviour
{

    public float velocity = 2f;
    public CharacterController charController;
    private Vector3 moveDirection;
    public GameObject[] pipes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.x = -velocity;
        charController.Move(moveDirection * Time.deltaTime);
    }
}
