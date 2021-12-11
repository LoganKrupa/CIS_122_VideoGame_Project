using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private enum State { idle, run, jump, falling};
    private State state = State.idle;
    private Collider2d coll;
    [SerializeField] private int cherries = 0;
    [SerializeFiel] private Text cherryText;
    [SerializeField] private int coins = 0;
    [SerializeFiel] private Text coinText;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();



    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(1, 0);
            transform.localScale = new Vector2(1, 1);

        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-1, 0);
            transform.localScale = new Vector2(-11, 1);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }


        private void OnCollisionEnter2d(Collision2D other)
        {
            if(other.gameObject.tag == "Enemy" && state == State.falling)
            {
                Destroy(other.gameObject);
            }
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Collectable")
            {
                Destroy(collision.gameObject);
                cherries += 1;
                cherryText.text = cherries.ToString();
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Collectable")
            {
                Destroy(collision.gameObject);
                coins += 1;
                coinText.text = coins.ToString();
            }
        }

    }
}
