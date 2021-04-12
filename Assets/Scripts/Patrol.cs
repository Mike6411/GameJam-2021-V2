using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public bool mustPatrol;
    private bool mustTurn;

    public LayerMask groundLayer;
    public Rigidbody2D rb;
    public Transform groundCheckPos;

    public void Start()
    {
        mustPatrol = true;
    }


    public void Update()
    {
        if (mustPatrol) {
            PAtrol();
        }
    }

    public void FixedUpdate()
    {
        if (mustPatrol) {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    public void PAtrol(){
        if (mustTurn) {
            FLip();
        }
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
    }

    public void FLip() {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        mustPatrol = true;
    }

}
