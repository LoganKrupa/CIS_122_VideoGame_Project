using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControler : MonoBehaviour
{

    public Rigidbody2D rb;
    public GameObject coin;
    public float launchForce;
    public float launchSpeed;
    public Transform shotPoint;

    //public int coins = 0; 

    //private enum State {Collection}
    



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void Throw()
    {
        
    }

}
