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

    TextAsset settingsJsonField;

    public float WaitTime;
    public sbyte MaxCorrects;
    public sbyte MaxMistakes;

    private void Awake()
    {
        instance = this;
        CurrentWaitTime = WaitTime;
        CurrentMaxCorrects = MaxCorrects;
        CurrentMaxMistakes = MaxMistakes;
    }

    private void Start()
    {
        settingsJsonField = Resources.Load<TextAsset>("Settings");

        LoadSettingsJsonField();
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

        AdjustSettingsJsonField();
    }

    public void OpenStartMenu()
    {
        startMenu.SetActive(true);
    }

    public void CloseStartMenu()
    {
        startMenu.SetActive(false);
    }

    private void LoadSettingsJsonField()
    {
        if (settingsJsonField == null) return;

        WaitTime = JsonUtility.FromJson<SettingsDataWrapper>(settingsJsonField.text).waitTime;
        MaxCorrects = JsonUtility.FromJson<SettingsDataWrapper>(settingsJsonField.text).maxCorrects;
        MaxMistakes = JsonUtility.FromJson<SettingsDataWrapper>(settingsJsonField.text).maxMistakes;
    }

    private void AdjustSettingsJsonField()
    {
        if (settingsJsonField == null) return;

        JsonUtility.FromJson<SettingsDataWrapper>(settingsJsonField.text).waitTime = WaitTime;
        JsonUtility.FromJson<SettingsDataWrapper>(settingsJsonField.text).maxCorrects = MaxCorrects;
        JsonUtility.FromJson<SettingsDataWrapper>(settingsJsonField.text).maxMistakes = MaxMistakes;
    }
}

internal class SettingsDataWrapper
{
    public float waitTime;
    public sbyte maxCorrects;
    public sbyte maxMistakes;
}