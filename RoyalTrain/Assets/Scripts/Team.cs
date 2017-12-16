using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour {

    public BattleManager BM;
    public Character[] thisTeam;
    public bool thisTeamsTurn = false;
    public bool thisTeamAlive = true;
    public bool AITeam = true;
    private Transform[] spawnLocations;

    public GameObject cook;
    public GameObject officer;
    public GameObject security;

    public GameObject[] enemyTyps;

    private void Awake()
    {
        enemyTyps = new GameObject[2];
        int i = 0;
        while(i <= 1)
        {
            if (i == 0)
            {
                enemyTyps[i] = officer;
            }
            else
            {
                enemyTyps[i] = security;
            }

            ++i;
        }
        i = 0;

        var spawns = gameObject.GetComponentsInChildren<Transform>()[i];
        thisTeam = gameObject.GetComponentsInChildren<Character>();
    }

    //check to see if its this teams turn
    public void CheckTurn()
    {
        int i = 0;
        while ( i <= thisTeam.Length)
        {
            
            if (thisTeam[i].isPlaying)
            {
                thisTeamsTurn = true;
            }
            else
            {
                thisTeamsTurn = false;
            }
            i++;
        }
    }

    public void alive()
    {
        int i = 0;
        while(i <= thisTeam.Length)
        {
            if(thisTeam[i].health > 0)
            {
                break;
            }
            if(i == thisTeam.Length)
            {
                thisTeamAlive = false;
            }
        }
    }
    
    public void spawn()
    {
            int i = 0;
            while (i <= BM.wave && i < spawnLocations.Length)
            {
                int x = Random.Range(0, 1);
                Instantiate(enemyTyps[x], spawnLocations[i]);
            }
    }
}
