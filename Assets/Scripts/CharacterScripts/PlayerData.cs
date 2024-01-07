using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class PlayerData
{


    public int health;
    public int mana;
    public int damage;
    public int skillPoints;

    public PlayerData(int health, int mana, int damage, int skillPoints)
    {
        this.health = health;
        this.mana = mana;
        this.damage = damage;
        this.skillPoints = skillPoints;
    }

}
