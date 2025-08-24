using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float gravity;
    public float sprintSpeedMultiplyer;

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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveTo *= sprintSpeedMultiplyer;
        }
        controller.Move(moveTo * Time.deltaTime * moveSpeed);
    }
    public void setMoveSpeed()
    {
        moveSpeed = 3 + gameLogic.data.lvlSystem.agilityLvl * 0.5f;
    }
}
