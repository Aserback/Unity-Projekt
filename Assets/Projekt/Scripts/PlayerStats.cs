using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;

    public int[] toLevelUp;

    public int[] attackLevels;
    public int[] defenceLevels;

    public int currentAttack;
    public int currentDefence;


    void Start()
    {
        currentAttack = attackLevels[currentLevel];
        currentDefence = defenceLevels[currentLevel];
    }


    void Update()
    {
        if (currentExp >= toLevelUp[currentLevel])
            LevelUp();
    }

    public void AddExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;
    }

    public void LevelUp()
    {
        currentLevel++;
        currentAttack = attackLevels[currentLevel];
        currentDefence = defenceLevels[currentLevel];
    }

}
