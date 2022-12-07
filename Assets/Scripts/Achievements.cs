using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    public AchievementUI AchievementUI;
    private bool CaptureAllFlags = false;

    private bool GotUnderThreeSeconds = false;

    private bool GotUnderFiveSeconds = false;

    private bool GotUnderSevenSeconds = false;

    private bool GotFailure = false;
    // Start is called before the first frame update
    void Start()
    {
        AchievementUI = GetComponent<AchievementUI>();
    }
    
    public void unlockAllAchievements()
    {
        AchievementUI.changeCheckTo(1, CheckTimerSevenAchievement());
        AchievementUI.changeCheckTo(2, CheckAllFlagsAchievement());
        AchievementUI.changeCheckTo(3, CheckFailureAchievement());
    }

    public void checkTimerSeven()
    {
        GotUnderSevenSeconds = true;
    }

    public void checkAllFlags()
    {
        CaptureAllFlags = true;
    }

    public void checkFailure()
    {
        GotFailure = true;
    }

    private bool CheckTimerSevenAchievement()
    {
        return GotUnderSevenSeconds;
    }

    private bool CheckAllFlagsAchievement()
    {
        return CaptureAllFlags;
    }
    
    private bool CheckFailureAchievement()
    {
        return GotFailure;
    }
}
