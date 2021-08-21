using UnityEngine;
using ExpPlus.Phariables;

public class HighScoreManager : MonoBehaviour
{

    [Header("Level Name"),SerializeField]
    private StringPhariable levelName;

    [Header("Highscore Phariables"), SerializeField]
    private IntPhariable timerSeconds;
    [SerializeField]
    private IntPhariable timerMinutes;

    [Space(10), SerializeField]
    private BoolPhariable isNewHighscore;

    [Header("Events"), SerializeField]
    private BoolPhariable finishEvent;

    private void OnEnable()
    {
        finishEvent.SubscribeToOnChangeSignal("Finish Level", SaveHighScore);
    }

    private void OnDisable()
    {
        finishEvent.UnSubscribeFromOnChangeSignal("Finish Level", SaveHighScore);
    }

    public void SaveHighScore()
    {
        int highSeconds = PlayerPrefs.GetInt(levelName.value + "_highscore_seconds");
        int highMinutes = PlayerPrefs.GetInt(levelName.value + "_highscore_minutes");

        if((timerMinutes.value <= highMinutes && timerSeconds.value < highSeconds) || (highSeconds == 0 && highMinutes == 0))
        {
            Debug.Log("[HIGHSCORE MANAGER] Highscore saved!");
            PlayerPrefs.SetInt(levelName.value + "_highscore_seconds", timerSeconds.value);
            PlayerPrefs.SetInt(levelName.value + "_highscore_minutes", timerMinutes.value);

            isNewHighscore.value = true;
        }
        else
        {
            Debug.Log("[HIGHSCORE MANAGER] Current time is no new highscore.");
            isNewHighscore.value = false;
        }
    }
}