using TMPro;
using UnityEngine;

public class MenuMenager : MonoBehaviour
{
    public static MenuMenager instance;

    public static float CurrentWaitTime = 1f;
    public static sbyte CurrentMaxCorrects = 15;
    public static sbyte CurrentMaxMistakes = 3;

    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject startMenu;

    [Header("Inputs")]
    [SerializeField] TMP_InputField waitTimeInput;
    [SerializeField] TMP_InputField maxCorrectsInput;
    [SerializeField] TMP_InputField maxMistakesInput;

    public float WaitTime = 1f;
    public sbyte MaxCorrects = 15;
    public sbyte MaxMistakes = 3;

    private void Awake()
    {
        instance = this;
        CurrentWaitTime = WaitTime;
        CurrentMaxCorrects = MaxCorrects;
        CurrentMaxMistakes = MaxMistakes;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartTwoControlerGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void StartOneControlerGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void OpenSettingsMenu()
    {
        waitTimeInput.text = CurrentWaitTime.ToString();
        maxCorrectsInput.text = CurrentMaxCorrects.ToString();
        maxMistakesInput.text = CurrentMaxMistakes.ToString();

        settingsMenu.SetActive(true);
    }
    public void CloseSettingsMenu()
    {
        settingsMenu.SetActive(false);
    }

    public void ApplySettings()
    {
        if(string.IsNullOrEmpty(waitTimeInput.text) || string.IsNullOrEmpty(maxCorrectsInput.text) || string.IsNullOrEmpty(maxMistakesInput.text)) return;

        WaitTime = float.Parse(waitTimeInput.text);
        MaxCorrects = sbyte.Parse(maxCorrectsInput.text);
        MaxMistakes = sbyte.Parse(maxMistakesInput.text);

        CurrentWaitTime = WaitTime;
        CurrentMaxCorrects = MaxCorrects;
        CurrentMaxMistakes = MaxMistakes;
    }

    public void OpenStartMenu()
    {
        startMenu.SetActive(true);
    }
}
