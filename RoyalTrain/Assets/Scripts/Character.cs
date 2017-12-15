using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    //this is to hold the statistics for characters in game
    public int health = 100;
    public int Mana = 100;
    public int armor = 0;
    public bool hasArmor = false;
    public int turnsStuned = 0;
    public bool isStuned = false;
    public bool isPlaying = false;
    public bool isPlayer = false;
}
