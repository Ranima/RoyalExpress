using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    //this is to hold the statistics for characters in game
    public int health = 100;
    public int Mana = 100;
    public int armor = 0;

    public int damageDealt = 0;

    public int stunDealt = 0;

    public int turnsStuned = 0;

    public int poisonDealt = 0;
    public int poisonDDealt = 0;

    public int turnsPoisoned = 0;
    public int poisonDamage = 0;

    public bool isPlaying = false;
    public bool isPlayer = false;
    public bool isDoingAction = false;

    private Ability[] abilities;

    //applies any special effects
    public void applySpecial ()
    {
        if(turnsPoisoned != 0)
        {
            health -= poisonDamage;

            if (turnsPoisoned < 0) turnsPoisoned = 0;

        }
        if(turnsStuned != 0)
        {
            turnsStuned--;
            isPlaying = false;
        }
    }

    public void AiAction()
    {
        int i = 0;
        while (i <= GetComponents<Ability>().Length)
        {
            abilities[i] = GetComponents<Ability>()[i];
            i++;
        }

        i = Random.Range(0, 3);
        abilities[i].DoAction();
    }

    public void healthcheck()
    {
        if(health <= 0)
        {
            isPlaying = false;
        }
    }
}
