using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{

    public GameObject CollectionAnimation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //cherry cconlection
        if (collision.tag == "Player")
        {

            

            //Cherryies += 1;

            Instantiate(CollectionAnimation, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }

        
    }
}
