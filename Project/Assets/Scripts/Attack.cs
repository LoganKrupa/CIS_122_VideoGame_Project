using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject coin;
    public float launchForce;
    public float launchSpeed;
    public Transform throwPoint;
    public GameObject coinPrefab;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Throw();
        }


        
    }

    public void Throw()
    {
        Instantiate(coinPrefab, throwPoint.position, throwPoint.rotation);

    }

}
