using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameManager gameManager;
    public GameObject bullet, bulletInactive;
    public float speed;
    public bool attack;
    public Rigidbody rb;
    public bool isShoot, canMultiply;
    
    public Vector3 startPosition;
    
    [Header("Touch Settings")]
    [SerializeField] bool isTouching;
    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.GetComponent<SphereCollider>().enabled = true;
        
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        rb = gameObject.GetComponent<Rigidbody>();
        startPosition = transform.position;
        attack = false;
        isShoot = false;
        canMultiply = true;

    }

    void Update () {
         
            

             if (attack)
             {
                 rb.MovePosition(transform.position + (Time.deltaTime * speed * Vector3.up));
             }
             
             
    }

    private void FixedUpdate()
    {
        if (gameManager.playerState == GameManager.PlayerState.Playing)
        {
            GetInput();

            
            if (isTouching)
            {
                attack = true;

                if (!isShoot)
                {
                    isShoot = true;
                    //Instantiate(bulletInactive, gameObject.transform.position, Quaternion.identity);
                    StartCoroutine(SpawnBottomAmmo());
                }
            }
            
            

            
        }
    }
    
    void GetInput()
    {
        if (Input.GetMouseButton(0))
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }
    


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
            Destroy(this.gameObject,4);
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
                    Instantiate(bullet, transform.position + (new Vector3(-0.4f * i,-0.4f,0)), Quaternion.identity);
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
    
    IEnumerator SpawnBottomAmmo()
    {
        yield return new WaitForSeconds(2);
        Instantiate(bulletInactive, startPosition, Quaternion.identity);
    }
}
