
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private void Awake()
    {
        currentHealth = startingHealth;
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if(currentHealth > 0)
        {
            //player hurt
        }
        else
        {
            // player dead
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {


            if (state == State.falling)
            {
                //Destroy(other.gameObject);
                //Instantiate(DeathAnimation, transform.position, Quaternion.identity);

                Destroy(other.gameObject);

                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                state = State.jump;
            }
            else
            {
                float hDirection = Input.GetAxis("Horizontal");
                state = State.hurt;
                rb.velocity = new Vector2(hurtBounce * hDirection, jumpForce / 2);

            }
        }


    }
}
