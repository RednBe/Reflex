using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] ControlerMenager rightControler;
    [SerializeField] ControlerMenager leftControler;
    [SerializeField] CounterMenager rightCounter;
    [SerializeField] CounterMenager leftCounter;
    [SerializeField] GameObject pausePanel;

    public float WaitTime = MenuMenager.CurrentWaitTime;

    private void Start()
    {
        WaitTime = MenuMenager.CurrentWaitTime;
        StartCoroutine(AdjustControlers());
    }

    private IEnumerator AdjustControlers()
    {

        while (PlayerMenager.instance == null)
            yield return null;

        while (PlayerMenager.instance.isGameOver == false)
        {
            byte random = (byte)Random.Range(0, 3);
            float waitTime = Random.Range(1f, 3f);

            yield return new WaitForSeconds(waitTime);
            if (random == 0)
            {
                rightControler.ToggleActive();
                rightCounter.isReseted = false;

                yield return new WaitForSeconds(WaitTime);

                if (rightControler.isActive)
                {
                    rightControler.ToggleActive();
                    PlayerMenager.instance.IncreaseMistakes();
                }
            }
            else if (random == 1)
            {
                leftControler.ToggleActive();
                leftCounter.isReseted = false;

                yield return new WaitForSeconds(WaitTime);

                if (leftControler.isActive)
                {
                    leftControler.ToggleActive();
                    PlayerMenager.instance.IncreaseMistakes();
                }
            }
            else if (random == 2)
            {
                rightControler.ToggleActive();
                leftControler.ToggleActive();

                rightCounter.isReseted = false;
                leftCounter.isReseted = false;

                yield return new WaitForSeconds(WaitTime);

                if (rightControler.isActive)
                {
                    rightControler.ToggleActive();
                    PlayerMenager.instance.IncreaseMistakes();
                }

                if (leftControler.isActive)
                {
                    leftControler.ToggleActive();
                    PlayerMenager.instance.IncreaseMistakes();
                }
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
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
}