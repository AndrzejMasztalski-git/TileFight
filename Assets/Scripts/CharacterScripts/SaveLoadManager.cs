using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{

    public Player player;
    private string saveFilePath => $"{Application.persistentDataPath}/playerdata.json";

    public void SaveGame(int health, int mana, int damage, int skillPoints)
    {
        PlayerData data = new PlayerData(health, mana, damage, skillPoints);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);
    }

    public PlayerData LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            return data;
        }
        return null;
    }

    public void SavePlayerData()
    {
        SaveGame(player.currentHealth, player.currentMana, player.playerDamage, player.skillPoints);
        Debug.Log(saveFilePath);
    }

    public void LoadPlayerData()
    {
        PlayerData data = LoadGame();
        if (data != null)
        {
            player.currentHealth = data.health;
            player.currentMana = data.mana;
            player.playerDamage = data.damage;
            player.skillPoints = data.skillPoints;
        }
    }
}

