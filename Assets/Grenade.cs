using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    int Fuse = 125;
    [SerializeField] LayerMask EnemyMask;

    void FixedUpdate()
    {
        Fuse--;
        if(Fuse == 0)
        {
            Destroy(gameObject);
            RaycastHit2D[] HitEnemies = Physics2D.CircleCastAll(transform.position, 4, Vector2.right, 0f, EnemyMask);
            foreach(RaycastHit2D Enemy in HitEnemies)
            {
                Destroy(Enemy.collider.gameObject);
            }
        }
    }
}
