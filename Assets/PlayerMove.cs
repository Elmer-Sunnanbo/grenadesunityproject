using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D TheRB;
    [SerializeField] float JumpStrength;
    [SerializeField] float MoveSpeed;
    LayerMask GMask;
    int MovementDir;
    
    // Start is called before the first frame update
    void Start()
    {
        TheRB = gameObject.GetComponent<Rigidbody2D>();
        GMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(CheckGrounded())
            {
                //TheRB.AddForce(new Vector2(0, JumpStrength), ForceMode2D.Impulse);
                TheRB.velocity = new Vector2(TheRB.velocity.x, JumpStrength);
            }
        }

        MovementDir = 0;
        if (Input.GetKey(KeyCode.D)) MovementDir++;
        if (Input.GetKey(KeyCode.A)) MovementDir--;
        TheRB.velocity = new Vector2(MovementDir * MoveSpeed, TheRB.velocity.y);
    }

    bool CheckGrounded() 
    {
        RaycastHit2D TheHit = Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y - 1), new Vector2(1, 0.1f), 0, Vector2.down, 0, GMask);
        if (TheHit.collider!= null)
        {
            return true;
        }
        return false; 
    }
}
