using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    public Text timerText;            // UI đếm ngược
    public GameObject gameOverPanel;  // Kéo Text hoặc Panel thông báo vào đây

    private float timeRemaining = 45f;
    private bool isRunning = true;

    void Start()
    {
        gameOverPanel.SetActive(false);  // Ẩn thông báo ban đầu
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        while (timeRemaining > 0)
        {
            timerText.text = Mathf.CeilToInt(timeRemaining).ToString();
            yield return new WaitForSeconds(1f);
            timeRemaining -= 1f;
        }

        timerText.text = "0";
        isRunning = false;

        gameOverPanel.SetActive(true); // Hiện thông báo thua
    }

    void Update()
    {
        CheckIfFullOrangeIsVisible();
    }

    void CheckIfFullOrangeIsVisible()
    {
        GameObject fullOrange = GameObject.FindWithTag("FullOrange");
        if (fullOrange != null)
        {
            Vector3 viewportPoint = Camera.main.WorldToViewportPoint(fullOrange.transform.position);

            // Nếu trong khung hình camera (nằm trong viewport 0-1)
            if (viewportPoint.x >= 0 && viewportPoint.x <= 1 &&
                viewportPoint.y >= 0 && viewportPoint.y <= 1 &&
                viewportPoint.z > 0)
            {
                Debug.Log("WIN!");
                ShowWinMessage();
            }
        }
    }
    [SerializeField] GameObject winPanel;

    public void ShowWinMessage()
    {
        if (winPanel != null)
            winPanel.SetActive(true);
    }

}
