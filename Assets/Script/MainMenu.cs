using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        GameManager.Instance.ShowSelectLevel();
    }

    public void HowToPlayButton()
    {
        GameManager.Instance.ShowHowToPlay();
    }
}