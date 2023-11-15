using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ComplexityClass
{
    private const int COUNT = 10;
    private const float MIN_TIME_BOMB_DROPS = 0.35f;
    private const float MAX_SPEED = 6f;


    public static void ChangeComplexity(GunParametrsClass gunParametrs,int points, ref int counter)
    {
        if (counter >= COUNT) {
            
            if (!CheckMaxComplexitySpeed(gunParametrs)) {
                ChangeSpeedParameter(gunParametrs);
            }
            
            if (!CheckMinTimeBombDrops(gunParametrs)) { 
                gunParametrs.setSecondsBetweenBombDrops(gunParametrs.getSecondsBetweenBombDrops()-0.05f);
            }
            
            counter = 0;
        }
        else {
            counter += points;
        }
    }

    private static void ChangeSpeedParameter(GunParametrsClass gunParametrs)
    {
        if (gunParametrs.getSpeed() > 0) {
            gunParametrs.setSpeed(gunParametrs.getSpeed() + 0.5f);
        }
        else {
            gunParametrs.setSpeed(gunParametrs.getSpeed() - 0.5f);
        }
    }

    private static bool CheckMaxComplexitySpeed(GunParametrsClass gunParametrs)
    {
        if(Mathf.Abs(gunParametrs.getSpeed()) == MAX_SPEED) {
            return true;
        }
        else {
            return false;
        }
    }

    private static bool CheckMinTimeBombDrops(GunParametrsClass gunParametrs)
    {
        if(gunParametrs.getSecondsBetweenBombDrops() == MIN_TIME_BOMB_DROPS) {
            return true;
        }
        else {
            return false;
        }
    }
}
