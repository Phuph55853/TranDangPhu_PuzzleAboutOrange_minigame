using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject howToPlayPanel, selectLevelPanel, winPanel, losePanel, gameplayUI;
    public Text timerText;
    public Sprite[] backgrounds; // 0: Beach, 1: Garden
    public Image backgroundImage;
    private float timeLeft = 45f;
    private bool isPlaying = false;
    private int currentLevel = 1;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (isPlaying)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = $"Time: {Mathf.Ceil(timeLeft)}s";
            if (timeLeft <= 0)
            {
                LoseGame();
            }
        }
    }

    public void StartGame(int level)
    {
        currentLevel = level;
        SceneManager.LoadScene("Gameplay");
        backgroundImage.sprite = level < 3 ? backgrounds[0] : backgrounds[1];
        timeLeft = 45f;
        isPlaying = true;
        gameplayUI.SetActive(true);
        howToPlayPanel.SetActive(false);
        selectLevelPanel.SetActive(false);
    }

    public void ShowHowToPlay()
    {
        howToPlayPanel.SetActive(true);
    }

    public void ShowSelectLevel()
    {
        selectLevelPanel.SetActive(true);
    }

    public void WinGame()
    {
        isPlaying = false;
        winPanel.SetActive(true);
        gameplayUI.SetActive(false);
    }

    public void LoseGame()
    {
        isPlaying = false;
        losePanel.SetActive(true);
        gameplayUI.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void CheckWinCondition()
    {
        if (PieceManager.Instance.AreAllPiecesInPlace())
        {
            WinGame();
        }
    }
}