using UnityEngine;
using ExpPlus.Phariables;

public class HighScoreManager : MonoBehaviour
{

    [Header("Level Name"),SerializeField]
    private StringPhariable levelName;

    [Header("Time Phariables"), SerializeField]
    private IntPhariable timerSeconds;
    [SerializeField]
    private IntPhariable timerMinutes;

    [Header("Highscore Phariables"), SerializeField]
    private IntPhariable highscoreSeconds;
    [SerializeField]
    private IntPhariable highscoreMinutes;

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

    private void SaveHighScore()
    {
        highscoreSeconds.value = PlayerPrefs.GetInt(levelName.value + "_highscore_seconds");
        highscoreMinutes.value = PlayerPrefs.GetInt(levelName.value + "_highscore_minutes");

        if((timerMinutes.value <= highscoreMinutes.value && timerSeconds.value < highscoreSeconds.value) || (highscoreSeconds.value == 0 && highscoreMinutes.value == 0))
        {
            PlayerPrefs.SetInt(levelName.value + "_highscore_seconds", timerSeconds.value);
            PlayerPrefs.SetInt(levelName.value + "_highscore_minutes", timerMinutes.value);

            highscoreSeconds.value = timerSeconds.value;
            highscoreMinutes.value = timerMinutes.value;

            isNewHighscore.value = true;
        }
        else
        {
            isNewHighscore.value = false;
        }
    }

    [ContextMenu("Reset Highscore")]
    public void ResetHighScore()
    {
        PlayerPrefs.SetInt(levelName.value + "_highscore_seconds", 0);
        PlayerPrefs.SetInt(levelName.value + "_highscore_minutes", 0);
    }
}