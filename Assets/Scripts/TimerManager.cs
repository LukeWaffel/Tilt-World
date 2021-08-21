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
    private BoolPhariable resetGame;
    [SerializeField]
    private BoolPhariable finishGame;

    private float seconds;

    private void OnEnable()
    {
        resetGame.SubscribeToOnChangeSignal("Reset Game", ResetTimer);
        finishGame.SubscribeToOnChangeSignal("Finish Level", DisableTimer);
    }

    private void OnDisable()
    {
        resetGame.UnSubscribeFromOnChangeSignal("Reset Game", ResetTimer);
        finishGame.UnSubscribeFromOnChangeSignal("Finish Level", DisableTimer);
    }

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

    private void DisableTimer()
    {
        timerEnabled.value = false;
    }

    private void ResetTimer()
    {
        seconds = 0;
        timeSeconds.value = 0;
        timeMinutes.value = 0;

        timerEnabled.value = true;
    }

    [ContextMenu("Reset Timer")]
    public void CallResetTimer()
    {
        resetGame.value = !resetGame.value;
    }
}
