using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Arisa Takenaka Trombley & Sam Lash
 * 2375446 2366917
 * trombley@chapman.edu slash@chapman.edu
 * CPSC-245-01
 * Final
 * 
 */
public class Achievements : MonoBehaviour
{
    public AchievementUI AchievementUI;
    public GameView GameView;
    private bool CaptureAllFlags = false;

    private bool GotUnderThreeSeconds = false;

    private bool GotUnderFiveSeconds = false;

    private bool GotUnderSevenSeconds = false;

    private bool GotFailure = false;

    //public Text countText;

    //public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        AchievementUI = GetComponent<AchievementUI>();
    }

    private void FixedUpdate()
    {
        while (!CaptureAllFlags)
            checkAllFlags();
    }

    public void unlockAllAchievements() // trigger this once plesae thanks thoawepawe
    {
        AchievementUI.changeCheckTo(1, CheckAllFlagsAchievement());
        //AchievementUI.changeCheckTo(2, CheckTimerSevenAchievement());
        //AchievementUI.changeCheckTo(3, CheckFailureAchievement());
    }

    public void checkTimerSeven()
    {
        // if (GetComponent(timerText) > 7) 
            GotUnderSevenSeconds = true;
    }

    public void checkAllFlags()
    {
        if (GameView.countInt >= 3)
        {
            CaptureAllFlags = true;
            print("we got this homie");
        }
        unlockAllAchievements();
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
