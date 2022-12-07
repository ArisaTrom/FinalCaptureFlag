using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementUI : MonoBehaviour
{
    public GameObject achievementCheck1;

    public GameObject achievementCheck2;

    public GameObject achievementCheck3;

    public bool isAchievement1Unlocked;
    public bool isAchievement2Unlocked;
    public bool isAchievement3Unlocked;
    // Start is called before the first frame update
    void Start()
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
        achievementCheck1.SetActive(isAchievement1Unlocked);
        achievementCheck2.SetActive(isAchievement2Unlocked);
        achievementCheck3.SetActive(isAchievement3Unlocked);
    }
}
