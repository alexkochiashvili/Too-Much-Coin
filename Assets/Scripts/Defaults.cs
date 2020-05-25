using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defaults : MonoBehaviour
{
    Player player;
    public GameObject[] coins;
    public GameObject[] enemies;
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        player.AmountOfCoins(coins.Length);
    }

    public void ResetToDefaults()
    {
        IterateOver(coins);
        IterateOver(enemies);
    }

    void IterateOver(GameObject[] toEnable)
    {
        for(int i = 0; i < toEnable.Length; i++)
        {
            toEnable[i].SetActive(true);
        }
    }
}