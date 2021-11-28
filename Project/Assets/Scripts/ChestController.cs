using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    

    //anim.SetInteger("State", (int) state);

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.tag == "Player")
        {
            //Destroy(gameObject);
            //spriteRenderer.sprite = newSprite;
            spriteRenderer.sprite = newSprite;
        }


    }

    
     

}
