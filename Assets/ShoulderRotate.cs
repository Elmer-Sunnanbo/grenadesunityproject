using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoulderRotate : MonoBehaviour
{
    Camera MainCam;
    Vector2 MousePos;
    float MouseAngle;
    // Start is called before the first frame update
    void Start()
    {
        MainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        MousePos = MainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10)) - transform.position;
        MouseAngle = Mathf.Atan2(MousePos.y, MousePos.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, MouseAngle);
    }
}
