using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseCamera : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeedX = 5;
    public float rotateSpeedY = 2;
    float horizontal;
    float yaw;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Cursor.lockState = CursorLockMode.Locked;
        horizontal = Input.GetAxis("Mouse X") * rotateSpeedX;
        target.transform.Rotate(0, horizontal, 0);

        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * offset);
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeedY;
        yaw += vertical;
        yaw = Mathf.Clamp(yaw,-30,30);
        transform.LookAt(new Vector3(target.transform.forward.x * 100,(target.transform.forward.y * 100) + yaw, target.transform.forward.z * 100));

    }
}
