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
    public GameObject fireballPrefab;
    public SpriteRenderer fireballSprite;
    public float destroyDelay = 3f;

    private void Start()
    {
        target = transform.position;
        fireballSprite.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void Update()
    {
        
        if(Input.GetMouseButtonDown(1))
        {
          FireballMove();
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
       
    }

    public void FireballMove()
    {
        

        fireballSprite.GetComponent<SpriteRenderer>().enabled = true;

        GameObject fireballClone;
        fireballClone = Instantiate(fireballPrefab, transform.position, transform.rotation);


        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;

        Destroy(gameObject, destroyDelay);
        

    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(gameObject);
            //Debug.Log("TRAFIENIE");
        }
    }
}
