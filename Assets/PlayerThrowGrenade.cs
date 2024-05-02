using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowGrenade : MonoBehaviour
{
    [SerializeField] GameObject GrenadePrefab;
    [SerializeField] float ThrowForce;
    Camera MainCam;
    Rigidbody2D TheRB;
    int ThrowCD = 0;
    public GameObject CurrentGrenade;
    public bool HoldingGrenade = false;
    // Start is called before the first frame update
    void Start()
    {
        MainCam = Camera.main;
        TheRB = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        ThrowCD--;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ThrowCD <= 0)
        {
            InstantiateGrenade();
        }

        if (Input.GetMouseButtonUp(0) && HoldingGrenade)
        {
            ThrowIt();
        }
    }

    void InstantiateGrenade()
    {
        /*
        CurrentGrenade = Instantiate(GrenadeObj, transform.position, Quaternion.identity);
        
        */
        CurrentGrenade = Instantiate(GrenadePrefab, transform.position, Quaternion.identity, transform);

        CurrentGrenade.GetComponent<Grenade>().ThrowingScript = this;

        HoldingGrenade = true;
    }
    void ThrowIt()
    {
        CurrentGrenade.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        Vector2 ForceToAdd = MainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10)) - transform.position;
        ForceToAdd.Normalize();
        float ThrowDir = Mathf.Atan2(ForceToAdd.y, ForceToAdd.x) * Mathf.Rad2Deg;
        CurrentGrenade.GetComponent<Rigidbody2D>().AddForce(ForceToAdd * ThrowForce);
        CurrentGrenade.transform.rotation = Quaternion.Euler(0, 0, ThrowDir + 90);
        CurrentGrenade.GetComponent<Rigidbody2D>().angularVelocity = UnityEngine.Random.Range(90f, -90f);
        ThrowCD = 50;

        CurrentGrenade.transform.parent = null;
        HoldingGrenade = false;
    }
}
