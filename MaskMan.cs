using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskMan : MonoBehaviour
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    [SerializeField] private float jumpLength = 2;
    [SerializeField] private float jumpHeight = 2;
    
    [SerializeField] private LayerMask Ground;

    private Collider2D coll;
    private Rigidbody2D rb;



    private bool facingLeft = true;


    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {

        // Showing that when the enemy hits a barrier it will turn around
        if (facingLeft)
        {
            if(transform.position.x > leftCap)
            {

                if(transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                if (coll.IsTouchingLayers(Ground))
                {
                    rb.velocity = new Vector2(-jumpLength, jumpHeight);
                }


            }

            else
            {
                facingLeft = false;
            }





        }
        else
        {
            if (transform.position.x < rightCap)
            {

                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                if (coll.IsTouchingLayers(Ground))
                {
                    rb.velocity = new Vector2(jumpLength, jumpHeight);
                }


            }

            else
            {
                facingLeft = true;
            }
        }            

        
    }
}
