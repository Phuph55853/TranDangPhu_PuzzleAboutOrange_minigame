using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // Gọi hàm này khi nhấn nút Play
    public void LoadLevelScene()
    {
        SceneManager.LoadScene("Level"); // hoặc dùng chỉ số nếu cần: LoadScene(1);
    }

    public void LoadLeve1lScene()
    {
        SceneManager.LoadScene("Level1"); // hoặc dùng chỉ số nếu cần: LoadScene(1);
    }
    public void LoadLeve2lScene()
    {
        SceneManager.LoadScene("Level2"); // hoặc dùng chỉ số nếu cần: LoadScene(1);
    }
    public void LoadLeve3lScene()
    {
        SceneManager.LoadScene("Level3"); // hoặc dùng chỉ số nếu cần: LoadScene(1);
    }
    public void LevelScene()
    {
        SceneManager.LoadScene("Level"); // hoặc dùng chỉ số nếu cần: LoadScene(1);
    }
    public void NextlScene()
    {
        SceneManager.LoadScene("Menu"); // hoặc dùng chỉ số nếu cần: LoadScene(1);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
