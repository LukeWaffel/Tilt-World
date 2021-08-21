using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using ExpPlus.Phariables;

public class LevelCardController : MonoBehaviour
{
    public string levelName;

    [SerializeField]
    private StringPhariable levelNamePhar;

    [SerializeField]
    private Button button;
    [SerializeField]
    private TMP_Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(() => { levelNamePhar.value = levelName; SceneManager.LoadScene(levelName);});

        int highscoreSeconds = PlayerPrefs.GetInt(levelName + "_highscore_seconds");
        int highScoreMinutes = PlayerPrefs.GetInt(levelName + "_highscore_minutes");

        string highSecondsString = highscoreSeconds < 10 ? "0" + highscoreSeconds.ToString() : highscoreSeconds.ToString();
        string highMinutesString = highScoreMinutes < 10 ? "0" + highScoreMinutes.ToString() : highScoreMinutes.ToString();

        highScoreText.text = highMinutesString + ":" + highSecondsString;
    }
}
