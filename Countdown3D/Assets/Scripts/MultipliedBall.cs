using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipliedBall : MonoBehaviour
{
    public GameObject bullet;
    public float speed;
    public Rigidbody rb;
    public bool canMultiply;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(BulletMultiply());
    }

    void Update () {
         
        rb.MovePosition(transform.position + (Time.deltaTime * speed * Vector3.up));
             
             
             
    }

   
    
    


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(this.gameObject);
            //gameManager.playerState = GameManager.PlayerState.Died;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("4x"))
        {
            if (canMultiply)
            {
                for (int i = 0; i < 4; i++)
                {
                    Instantiate(bullet, transform.position, Quaternion.identity);
                }

                canMultiply = false;

                StartCoroutine(BulletMultiply());
            }
            
        }    
    }
    
    IEnumerator BulletMultiply()
    {
        yield return new WaitForSeconds(2);
        canMultiply = true;
    }
    
   
}
