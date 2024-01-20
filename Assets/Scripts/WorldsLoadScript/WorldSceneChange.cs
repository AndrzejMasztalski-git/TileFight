using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public GameObject finalBoss;
    public TMPro.TextMeshProUGUI winText;
    public Button returnButton;
    bool bossAlive = true;
    bool finalWorldEntered = false;
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
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FinalWorldEntry")
        {
            if (playerScript.keyCounter >= 2)
            {
                Debug.Log("wejscie");
                Destroy(collision.gameObject);
                finalBoss.SetActive(true);
                finalBoss.transform.position = finalBossSpawn.transform.position;
                finalBoss.GetComponent<Enemy>().maxHealth = 150;
                finalBoss.GetComponent<Enemy>().currentHealth = 150;
                finalWorldEntered = true;
            }
            else
            {
                Debug.Log("Brak wymaganej iloœci kluczy");
            }

        }
    }
    private void Start()
    {
        bossAlive = true;
        
    }

    public void CheckIfBossAlive()
    {
        if(finalWorldEntered && finalBoss.GetComponent<Enemy>().currentHealth <= 0)
        {
            bossAlive=false;
        }
    }

    private void Update()
    {

        CheckIfBossAlive();
        if (!bossAlive) {
            Time.timeScale = 0;
            winText.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
            returnButton.gameObject.SetActive(true);
            Debug.Log("YOU WIN");
        }
    }
}
