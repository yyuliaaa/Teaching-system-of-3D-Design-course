using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRot : MonoBehaviour
{
    public Transform target;
    public float x_Speed = 300;
    public float y_Speed = 300;
    public float mmSpeed = 10;
    public float xMinLimit = 5;
    public float xMaxLimit = 80;
    public float distance = 5;
    public float minDistance = 2;
    public float maxDistance = 30;
    public bool isNeedDamping = true;
    public float x_OriginAngle = 30f;
    public float y_OriginAngle = 0f;
    public float damping = 8f;

    public bool IsMove = true;

    private void LateUpdate()
    {
        if (!IsMove) return;
        if (target)
        {
            if (Input.GetMouseButton(0))
            {

                y_OriginAngle += Input.GetAxis("Mouse X") * x_Speed * Time.deltaTime;
                x_OriginAngle -= Input.GetAxis("Mouse Y") * y_Speed * Time.deltaTime;
                x_OriginAngle = ClampAngle(x_OriginAngle, xMinLimit, xMaxLimit);
            }
            distance -= Input.GetAxis("Mouse ScrollWheel") * mmSpeed;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
            Quaternion rotation = Quaternion.Euler(x_OriginAngle, y_OriginAngle, 0.0f);
            Vector3 disVector = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * disVector + target.position;
            if (isNeedDamping)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * damping);
                transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * damping);
            }
            else
            {
                transform.rotation = rotation;
                transform.position = position;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;

        }
        return Mathf.Clamp(angle, min, max);
    }

    public void ban()
    {
        IsMove = false;
    }
    public void Noban()
    {
        IsMove = true;
    }
}
