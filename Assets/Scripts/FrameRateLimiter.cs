using UnityEngine;

public static class FrameRateLimiter
{
    //http://answers.unity.com/answers/560545/view.html
    public static void LimitTo(int fps)
    {
        QualitySettings.vSyncCount = 0;     //vsync must be disabled
        Application.targetFrameRate = fps;
    }

    public static void Unlimit()
    {
        LimitTo(-1);
    }
}
