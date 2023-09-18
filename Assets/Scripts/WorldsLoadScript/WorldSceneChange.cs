using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSceneChange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "WinterWorldEntry")
        {
            SceneManager.LoadScene(1);
        }
        else if(collision.tag == "DesertWorldEntry")
        {
            SceneManager.LoadScene(2);
        }
        else if (collision.tag == "FinalWorldEntry")
        {
            SceneManager.LoadScene(3);
        }
    }
}
