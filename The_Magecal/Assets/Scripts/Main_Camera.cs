using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera : MonoBehaviour
{
    //let me select target in unity editor
    public Transform target;

    //it sets smoothness of camera
    public float smoothSpeed = 8;
    public Vector2 offset;
    //get minimum and maximum area of camera
    public float limitMinX, limitMaxX, limitMinY, limitMaxY;
    float cameraHalfWidth, cameraHalfHeight;

    private void Start()
    {
        //it gets size of x-axis and y-axis
        cameraHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        cameraHalfHeight = Camera.main.orthographicSize;
    }

    private void LateUpdate()
    {
        //let the camera don't go over the minimum and maximum values
        Vector3 desiredPosition = new Vector3(
            Mathf.Clamp(target.position.x + offset.x, limitMinX + cameraHalfWidth, limitMaxX - cameraHalfWidth),
            Mathf.Clamp(target.position.y + offset.y, limitMinY + cameraHalfHeight, limitMaxY - cameraHalfHeight),
            -10);
        //It lets camera move to target position.
        //it spits value closer to 0 if it's closer to stating position of camera
        //it spits value closer to 1 if it's closer to destination position of camera.
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
    }
}
