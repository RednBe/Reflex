using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OneControlerGameMenager : MonoBehaviour
{
    [SerializeField] ControlerMenager controler;
    [SerializeField] CounterMenager counter;

    [Header("Panels")]
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject winPanel;

    float WaitTime = 1f;
    float random;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        controler.isActive = false;
        PlayerMenager.instance.isGameOver = false;

        WaitTime = MenuMenager.CurrentWaitTime;
        StartCoroutine(AdjustControler());
    }

    private IEnumerator AdjustControler()
    {
        while (!PlayerMenager.instance.isGameOver)
        {
            random = Random.Range(1f, 3f);
            yield return new WaitForSeconds(random);

            if (!PlayerMenager.instance.isGameOver)
                controler.ToggleActive();

            yield return new WaitForSeconds(WaitTime);

            counter.isReseted = false;

            if (controler.isActive)
            {
                controler.ToggleActive();
                PlayerMenager.instance.IncreaseMistakes();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void OpenLosePanel()
    {
        Time.timeScale = 0;
        losePanel.SetActive(true);
    }

    public void OpenWinPanel()
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
