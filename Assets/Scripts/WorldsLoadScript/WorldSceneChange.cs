using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSceneChange : MonoBehaviour
{
    public GameObject player;
    public GameObject winterWorldSpawn;
    public GameObject desertWorldSpawn;
    public GameObject startWorldSpawn;
    public Player playerScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DesertWorldEntry")
        {
            player.transform.position = desertWorldSpawn.transform.position;
        }
        else if (collision.tag == "DesertWorldExit" || collision.tag == "WinterWorldExit" || collision.tag == "FinalWorldExit")
        {
            player.transform.position = startWorldSpawn.transform.position;
        }
        else if(collision.tag == "WinterWorldEntry")
        {
            player.transform.position = winterWorldSpawn.transform.position;
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
