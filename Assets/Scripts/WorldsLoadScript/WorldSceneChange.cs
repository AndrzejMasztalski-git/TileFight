using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSceneChange : MonoBehaviour
{

    public Player player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DesertWorldEntry")
        {
            SceneManager.LoadScene(1);
        }
        else if(collision.tag == "WinterWorldEntry")
        {
            SceneManager.LoadScene(2);
        }
        else if (collision.tag == "FinalWorldEntry")
        {
            if(player.keyCounter >=2)
            {
                SceneManager.LoadScene(3);
            }
            else
            {
                Debug.Log("Brak wymaganej iloœci kluczy");
            }
            
        }
    }
}
