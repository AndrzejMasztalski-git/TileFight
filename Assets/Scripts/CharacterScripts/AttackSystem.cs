using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    //private void OnMouseDown()
    //{
    //    Debug.Log("Attack!!!");
    //}

    public float speed = 5f;
    private Vector3 target;
    public Rigidbody2D fireball;

    public float destroyDelay = 3f;

    private void Start()
    {
        target = transform.parent.position;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Rigidbody2D fireballClone;
            fireballClone = Instantiate(fireball, transform.position, transform.rotation);
            
            
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            Destroy(gameObject, destroyDelay);
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);


        
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
