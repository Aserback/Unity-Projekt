using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static bool UIExists;
    private PlayerStats playerstats;
    public Text levelText;
    public Text attackLevelText;
    public Text defenceLevelText;


    void Start()
    {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        playerstats = GetComponent<PlayerStats>();
    }


    void Update()
    {
        levelText.text = "Lvl: " + playerstats.currentLevel;
        attackLevelText.text = "Attack: " + playerstats.currentAttack;
        defenceLevelText.text = "Defence: " + playerstats.currentDefence;
    }
}
