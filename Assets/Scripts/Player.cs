using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float _character_speed = 5.0f;

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

        // Now move based on that direction.
        _controller.Move(direction * Time.deltaTime * _character_speed);
    }
}
