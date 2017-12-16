using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {

    public Team playerTeam;
    public Team Ai;
    public Team Current;

    public GameObject Attacker;
    private Character attacker;
    private Character defender;

    public Image fade;
    public Text GameOver;

    public int manaUp = 5;
    public int wave = 0;

	// Use this for initialization
	void Start () {
        Round();
        NextWave();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown(Collider col)
    {
        if(col.gameObject.GetComponent<Character>() != null && Attacker != null)
        {
            defender = col.gameObject.GetComponent<Character>();
            DoAction();
        }
    }

    //do an action
    void DoAction ()
    {
        attacker = Attacker.GetComponent<Character>();
        attacker.applySpecial();

        if (defender.armor <= 0)
        {
            defender.health += attacker.damageDealt;
        }
        else
        {
            defender.armor += attacker.damageDealt;
            if(defender.armor > 0)
            {
                defender.health += defender.armor;
                defender.armor = 0;
            }
        }

        defender.turnsPoisoned = attacker.poisonDealt;
        defender.poisonDamage = attacker.poisonDDealt;

        defender.turnsStuned = attacker.stunDealt;

        attacker.isPlaying = false;
        attacker.poisonDealt = 0;
        attacker.poisonDDealt = 0;
        attacker.stunDealt = 0;

        Ai.alive();
        playerTeam.alive();

        Round();
        Wave();
    }

    void Round()
    {
        if (Current == Ai)
        {
            int i = 0;
            while (i <= Ai.thisTeam.Length)
            {
                Ai.thisTeam[i].AiAction();
            }
        }

        if (Current == null)
        {
            Current = playerTeam;
        }

        if (!Current.thisTeamsTurn)
        {
            int i = 0;
            while (i < Current.thisTeam.Length)
            {
                Current.thisTeam[i].Mana += manaUp;
            }
            if (Current == playerTeam)
            {
                Current = Ai;
            }
            else
            {
                Current = playerTeam;
            }
        }
    }

    void Wave()
    {
        if (!Ai.thisTeamAlive)
        {
            int i = 0;
            while (i <= Ai.thisTeam.Length)
            {
                Destroy(Ai.thisTeam[i].gameObject);
            }
            NextWave();
            Ai.thisTeamAlive = true;
        }
        if(!playerTeam.thisTeamAlive)
        {
            Gameover();
        }
    }

    void NextWave()
    {
        wave++;
        Ai.spawn();
    }

    void Gameover()
    {
        GameOver.gameObject.SetActive(true);
    }
}
