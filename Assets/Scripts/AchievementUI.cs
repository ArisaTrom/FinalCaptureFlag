using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Arisa Takenaka Trombley & Sam Lash
 * 2375446 2366917
 * trombley@chapman.edu slash@chapman.edu
 * CPSC-245-01
 * Final
 * 
 */
public class AchievementUI : MonoBehaviour
{
    public GameObject achievementCheck1;

    public GameObject achievementCheck2;

    public GameObject achievementCheck3;

    public bool isAchievement1Unlocked;
    public bool isAchievement2Unlocked;
    public bool isAchievement3Unlocked;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        UpdateChecks();
    }

    public void changeCheckTo(int achievementNumber, bool status)
    {
        switch (achievementNumber)
        {
            case 1:
                isAchievement1Unlocked = status;
                break;
            case 2:
                isAchievement2Unlocked = status;
                break;
            case 3:
                isAchievement3Unlocked = status;
                break;
        }
    }

    private void UpdateChecks()
    {
        if (isAchievement1Unlocked)
        {
            achievementCheck1.SetActive(isAchievement1Unlocked);
            StartCoroutine(Sleep(achievementCheck1));
        }

        //achievementCheck2.SetActive(isAchievement2Unlocked);
        //achievementCheck3.SetActive(isAchievement3Unlocked);
    }

    IEnumerator Sleep(GameObject achievementTag)
    {
        yield return new WaitForSeconds(3f);
        achievementTag.SetActive(false);
    }
}
