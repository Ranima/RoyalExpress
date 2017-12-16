using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour {

    //Character attached to
    private Character thisCharacter;

    //the base for all abilities in game
    public bool canCast = false;
    public int manaCost = 0;
    public int healthEffect = 0;
    public int armorEffect = 0;

    //special effects
    public bool isPoisonous = false;
    public int poisonDamage = 0;
    public int poisonDuration = 0;

    public bool isHeavy = false;
    public int stunDuration = 0;

    //sets the character this is attached to
    private void Awake()
    {
        thisCharacter = GetComponentInParent<Character>();
    }

    //Do this Action
    public void DoAction ()
    {
        if (canCast == true)
        {
            thisCharacter.damageDealt = healthEffect;
            if (isPoisonous)
            {
                thisCharacter.poisonDealt = poisonDuration;
                thisCharacter.poisonDDealt = poisonDamage;
            }
            if (isHeavy)
            {
                thisCharacter.stunDealt = stunDuration;
            }
            thisCharacter.Mana += manaCost;
            thisCharacter.isDoingAction = true;
        }
    }
}
