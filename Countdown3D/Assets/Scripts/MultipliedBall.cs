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
    public bool threex, fourx;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(BulletMultiply());
        rb.useGravity = true;
    }

    void Update () {
         
        //rb.MovePosition(transform.position + (Time.deltaTime * speed * Vector3.up));
             
             
             
    }

   
    
    


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(this.gameObject);
            //gameManager.playerState = GameManager.PlayerState.Died;
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("4x"))
        {
            if (canMultiply && fourx)
            {
                for (int i = 0; i < 4; i++)
                {
                    //Instantiate(bullet, transform.position, Quaternion.identity);
                    var bulletMu = Instantiate(bullet, transform.position + (new Vector3(-0.2f * i,0.2f,0)), Quaternion.identity);
                    bulletMu.GetComponent<MultipliedBall>().fourx = false;
                }

                //canMultiply = false;

                //StartCoroutine(BulletMultiply());
            }
            
        }    
        
        if (other.gameObject.CompareTag("3x"))
        {
            if (canMultiply & threex)
            {
                for (int i = 0; i < 3; i++)
                {
                    var bulletMu = Instantiate(bullet, transform.position + (new Vector3(-0.2f * i,0.2f,0)), Quaternion.identity);
                    bulletMu.GetComponent<MultipliedBall>().threex = false;
                    



                }

                //canMultiply = false;

                //StartCoroutine(BulletMultiply());
            }
            
        }    
    }
    
    
    
    IEnumerator BulletMultiply()
    {
        yield return new WaitForSeconds(1f);
        canMultiply = true;
        
    }
    
   
}
