using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float _character_speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.0f;

    [SerializeField]
    private float _jumpHeight = 15.0f;
    private float _yVelocity;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal input
        float horizontal_movement = Input.GetAxis("Horizontal");    // -1 ... +1
        Vector3 direction = new Vector3(horizontal_movement, 0, 0);
        Vector3 velocity = direction * _character_speed;

        // Now move based on that direction.

        // if grounded, do nothing, else, apply gravity
        if(!_controller.isGrounded)
        {
            _yVelocity -= _gravity;
        } else // Jump, Jump!!
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity += _jumpHeight;
            }
        }
        velocity.y = _yVelocity;

        _controller.Move(velocity * Time.deltaTime);
    }
}
