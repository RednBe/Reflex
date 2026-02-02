using TMPro;
using UnityEngine;

public class MenuMenager : MonoBehaviour
{
    public static MenuMenager instance;

    public static float CurrentWaitTime = 1f;
    public static sbyte CurrentMaxCorrects = 15;
    public static sbyte CurrentMaxMistakes = 3;

    [Header("Menus")]
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject startMenu;

    [Header("PlayerValues")]
    [SerializeField] TextMeshProUGUI txtAverage;

    [Header("Inputs")]
    [SerializeField] TMP_InputField waitTimeInput;
    [SerializeField] TMP_InputField maxCorrectsInput;
    [SerializeField] TMP_InputField maxMistakesInput;

    public float WaitTime;
    public sbyte MaxCorrects;
    public sbyte MaxMistakes;

    private void Awake()
    {
        instance = this;
        
        WaitTime = PlayerPrefs.GetFloat("WaitTime", 1f);
        MaxCorrects = (sbyte)PlayerPrefs.GetInt("MaxCorrects", 15);
        MaxMistakes = (sbyte)PlayerPrefs.GetInt("MaxMistakes", 3);

        CurrentWaitTime = WaitTime;
        CurrentMaxCorrects = MaxCorrects;
        CurrentMaxMistakes = MaxMistakes;
    }

    private void Start()
    {
        UpdateAverageText();
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
        if (string.IsNullOrEmpty(waitTimeInput.text) || string.IsNullOrEmpty(maxCorrectsInput.text) || string.IsNullOrEmpty(maxMistakesInput.text)) return;

        WaitTime = float.Parse(waitTimeInput.text);

        if (int.Parse(maxCorrectsInput.text) > 100 || int.Parse(maxMistakesInput.text) > 100) return;
        MaxCorrects = sbyte.Parse(maxCorrectsInput.text);
        MaxMistakes = sbyte.Parse(maxMistakesInput.text);

        CurrentWaitTime = WaitTime;
        CurrentMaxCorrects = MaxCorrects;
        CurrentMaxMistakes = MaxMistakes;

        PlayerPrefs.SetFloat("WaitTime", WaitTime);
        PlayerPrefs.SetInt("MaxCorrects", MaxCorrects);
        PlayerPrefs.SetInt("MaxMistakes", MaxMistakes);
    }

    public void OpenStartMenu()
    {
        startMenu.SetActive(true);
    }

    public void CloseStartMenu()
    {
        startMenu.SetActive(false);
    }

    public void UpdateAverageText()
    {
        txtAverage.text = "Average: " + AverageMenager.GetAverage().ToString("F2");
    }
}