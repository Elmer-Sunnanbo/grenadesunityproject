using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowGrenade : MonoBehaviour
{
    [SerializeField] GameObject GrenadePrefab;
    GameObject CurrentGrenade;

    [SerializeField] float ThrowForce;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CurrentGrenade = Instantiate(GrenadePrefab, transform.position, Quaternion.identity);
            Vector3 ForceToAdd = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            ForceToAdd -= transform.position;
            ForceToAdd.Normalize();
            CurrentGrenade.GetComponent<Rigidbody2D>().AddForce(ForceToAdd * ThrowForce);
        }
    }
}
