using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSceneChange : MonoBehaviour
{
    public GameObject player;
    public GameObject winterWorldExit;
    public Player playerScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DesertWorldEntry")
        {
            Debug.Log("Wejœcie");
        }
        else if(collision.tag == "WinterWorldEntry")
        {
            player.transform.position = winterWorldExit.transform.position;
        }
        else if (collision.tag == "FinalWorldEntry")
        {
            if(playerScript.keyCounter >=2)
            {
                Debug.Log("Wejœcie");
            }
            else
            {
                Debug.Log("Brak wymaganej iloœci kluczy");
            }
            
        }
    }
}
