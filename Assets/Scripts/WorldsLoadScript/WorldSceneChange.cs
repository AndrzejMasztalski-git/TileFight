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
    public GameObject playerPrefab;
    public GameObject finalBossSpawn;
    GameObject finalBoss;
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
                Debug.Log("wejscie");
                Destroy(collision.gameObject);
                finalBoss = Instantiate(playerPrefab);
                finalBoss.transform.position = finalBossSpawn.transform.position;
                finalBoss.GetComponent<Enemy>().maxHealth = 150;
                finalBoss.GetComponent<Enemy>().currentHealth = 150;
            }
            else
            {
                Debug.Log("Brak wymaganej iloœci kluczy");
            }
            
        }
    }

    private void Update()
    {
        if (finalBoss.GetComponent<Enemy>().currentHealth <= 0) {
            Time.timeScale = 0;
            Debug.Log("YOU WIN");
        }
    }
}
