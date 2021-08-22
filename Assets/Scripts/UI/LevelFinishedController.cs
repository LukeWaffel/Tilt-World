using UnityEngine;
using TMPro;
using ExpPlus.Phariables;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelFinishedController : MonoBehaviour
{
    [Header("References"), SerializeField]
    private GameObject container;

    [Header("Labels"), SerializeField]
    private TMP_Text time;
    [SerializeField]
    private TMP_Text highscore;
    [SerializeField]
    private GameObject trophy;

    [Header("Phariables"), SerializeField]
    private StringPhariable levelName;
    [SerializeField]
    private IntPhariable timerSeconds;
    [SerializeField]
    private IntPhariable timerMinutes;
    [SerializeField]
    private IntPhariable highscoreSeconds;
    [SerializeField]
    private IntPhariable highscoreMinutes;
    [SerializeField]
    private BoolPhariable isNewHighScore;

    [Header("Events"), SerializeField]
    private BoolPhariable finishLevel;

    private void OnEnable()
    {
        finishLevel.SubscribeToOnChangeSignal("Finish Level", ShowScreen);
    }

    private void OnDisable()
    {
        finishLevel.UnSubscribeFromOnChangeSignal("Finish Level", ShowScreen);
    }

    private void ShowScreen()
    {
        StartCoroutine(ShowScreenDelayed());
    }

    private IEnumerator ShowScreenDelayed()
    {
        yield return new WaitForEndOfFrame();

        string secondsString = timerSeconds.value < 10 ? "0" + timerSeconds.value.ToString() : timerSeconds.value.ToString();
        string minutesString = timerMinutes.value < 10 ? "0" + timerMinutes.value.ToString() : timerMinutes.value.ToString();
        time.text = minutesString + ":" + secondsString;

        string secondsHighString = highscoreSeconds.value < 10 ? "0" + highscoreSeconds.value.ToString() : highscoreSeconds.value.ToString();
        string minutesHighString = highscoreMinutes.value < 10 ? "0" + highscoreMinutes.value.ToString() : highscoreMinutes.value.ToString();

        highscore.text = minutesHighString + ":" + secondsHighString;

        trophy.SetActive(isNewHighScore.value);

        container.SetActive(true);
    }

    public void LoadScene(string sceneName)
    {
        levelName.value = sceneName;
        SceneManager.LoadScene(sceneName);
    }
}
