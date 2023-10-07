using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 target;
    public GameObject fireballPrefab;
    public SpriteRenderer fireballSprite;
    public float destroyDelay = 3f;
    public Player player;
    public GameObject character;
    private void Start()
    {
        target = transform.position;
        fireballSprite.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void Update()
    {
        
        if(Input.GetMouseButtonDown(1) && player.currentMana >= 5)
        {
                FireballMove();
        }
        else if(player.currentMana < 5)
        {
            Debug.Log("Not enough Mana!");
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
       
    }

    public void FireballMove()
    {
        
        gameObject.transform.position = character.transform.position;
        

        fireballSprite.GetComponent<SpriteRenderer>().enabled = true;

        GameObject fireballClone;
        fireballClone = Instantiate(fireballPrefab, character.transform.position, character.transform.rotation);


        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;

        Destroy(gameObject, destroyDelay);
        

    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(gameObject);
            
        }
    }
}
