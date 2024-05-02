using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    float Fuse;
    
    [SerializeField] GameObject ExplosionParticle;
    [SerializeField] GameObject SmokeParticle;
    [SerializeField] GameObject Explosion;
    public PlayerThrowGrenade ThrowingScript;
    SpriteRenderer TheSR;
    // Start is called before the first frame update
    void Start()
    {
        Fuse = 100;
        TheSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Fuse--;
        if(Fuse <= 0)
        {
            Instantiate(ExplosionParticle, transform.position, Quaternion.identity);
            Instantiate(SmokeParticle, transform.position, Quaternion.identity);
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);

            if(ThrowingScript.CurrentGrenade == gameObject)
            {
                ThrowingScript.HoldingGrenade = false;
            }
        }
    }

    private void Update()
    {
        TheSR.color = new Color(1-(Fuse/100), Fuse/100, 0);
    }
}
