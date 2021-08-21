using UnityEngine;
using ExpPlus.Phariables;

public class TimerManager : MonoBehaviour
{
    [Header("State Phariable"),SerializeField]
    private BoolPhariable timerEnabled;

    [Header("Time Phariables"), SerializeField]
    private IntPhariable timeSeconds;
    [SerializeField]
    private IntPhariable timeMinutes;

    [Header("Events"),SerializeField]
    private BoolPhariable timerReset;

    private float seconds;

    // Update is called once per frame
    void Update()
    {
        if (!timerEnabled.value)
            return;

        seconds += Time.deltaTime;

        if(seconds >= 60f)
        {
            seconds = 0;
            timeMinutes.value++;
        }

        timeSeconds.value = (int)seconds;
    }

    public void ResetTimer()
    {
        seconds = 0;
        timeSeconds.value = 0;
        timeMinutes.value = 0;
    }
}
