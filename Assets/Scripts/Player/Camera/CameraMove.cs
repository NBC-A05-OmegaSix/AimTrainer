using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float sesitivity = 500f;
    //¹Î°¨µµ
    public float rotationX;
    public float rotationY;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseMoveX = Input.GetAxis("Mouse X");
        float mousemoveY = Input.GetAxis("Mouse Y");
        rotationY += mouseMoveX * sesitivity * Time.deltaTime;
        rotationX += mousemoveY * sesitivity * Time.deltaTime;


        if (rotationX > 35f)
        {
            rotationX = 35f;
        }

        if (rotationX > -30f)
        {
            rotationX = -30f;
        }

        transform.eulerAngles = new Vector3(-rotationX, rotationY, 0);
    }
}
