using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float gravity;

    CharacterController controller;
    float moveForward;
    float moveSideway;
    Vector3 moveTo;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        move();
    }
    void move()
    {
        moveForward = Input.GetAxis("Vertical");
        moveSideway = Input.GetAxis("Horizontal");
        moveTo = transform.forward * moveForward + transform.right * moveSideway + transform.up * gravity * -1;
        controller.Move(moveTo * Time.deltaTime * moveSpeed);
    }
}
