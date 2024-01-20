using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIScript : MonoBehaviour
{
    public Button returnButton;
    public TMPro.TextMeshProUGUI loseText;
    public TMPro.TextMeshProUGUI winText;
    void Start()
    {
        winText.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
        loseText.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
        returnButton.gameObject.SetActive(false);
    }

    public void ReturnIfEndGame()
    {
        winText.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
        loseText.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
        returnButton.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
