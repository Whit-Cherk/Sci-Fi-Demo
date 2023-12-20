using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    // Referencias
    private CharacterController _controller; // Character Controller of the player. 

    // Componentes
    [SerializeField] private float _speed = 3.5f; // Speed variable for movement
    private float _gravity = 9.81f;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //Input en el eje X
        float verticalInput = Input.GetAxis("Vertical"); //Input en el eje Z
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput); // Getting the position via user input
        Vector3 velocity = direction * _speed; // summarized formula for use below
        velocity.y -= _gravity; //Apply gravity to the player
        velocity = transform.transform.TransformDirection(velocity); //This is supposed to make the world direction change to the player direction.
        _controller.Move(Time.deltaTime * velocity);
    }
}
