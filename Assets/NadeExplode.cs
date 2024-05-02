using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NadeExplode : MonoBehaviour
{
    int Fuse = 10;
    [SerializeField] LayerMask EMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Fuse--;

        if(Fuse==0)
        {
            RaycastHit2D[] HitEnemies = Physics2D.CircleCastAll(transform.position, 4, Vector2.right, 0f, EMask);
            foreach (RaycastHit2D Enemy in HitEnemies)
            {
                Destroy(Enemy.collider.gameObject);
            }
            Destroy(gameObject);
        }
        
    }
}
