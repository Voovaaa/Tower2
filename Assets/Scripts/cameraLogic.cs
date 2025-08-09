using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLogic : MonoBehaviour
{
    public float rotationSpeed;

    float rotationX;
    float rotationY;
    float maxAngleX = 90f;
    float minAngleX = -90f;
    void LateUpdate()
    {
        rotating();
    }

    public void rotating()
    {
        rotationX = Input.GetAxis("Mouse Y");
        rotationY = Input.GetAxis("Mouse X");

        rotationX = Mathf.Clamp(rotationX * Time.deltaTime * rotationSpeed * -1f + getXRotation(transform.eulerAngles.x), minAngleX, maxAngleX);
        rotationY = rotationY * Time.deltaTime * rotationSpeed + transform.parent.eulerAngles.y;

        transform.parent.eulerAngles = new Vector3(0f, rotationY, 0f);
        transform.localEulerAngles = new Vector3(rotationX, 0f, 0f);
        
    }

    public float getXRotation(float value)
    {
        if (value >= 270 && value <=360)
        {
            return value - 360;
        }
        return value;
    }
}
