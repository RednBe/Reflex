using System.Threading;
using UnityEngine;

public class PlayerMenager : MonoBehaviour
{
    static public PlayerMenager instance;

    public sbyte maxCorrects = 15;
    public sbyte maxMistakes = 3;
    public sbyte mistakes = 0;
    public sbyte corrects = 0;
    public bool isGameOver = false;

    [Header("Panels")]
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject pausePanel;

    [Header("References")]
    [SerializeField] VariableMenager correctsVariableMenager;
    [SerializeField] VariableMenager mistakesVariableMenager;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        maxCorrects = MenuMenager.CurrentMaxCorrects;
        maxMistakes = MenuMenager.CurrentMaxMistakes;
        
        if (correctsVariableMenager != null)
            correctsVariableMenager.Max = maxCorrects;
        if (mistakesVariableMenager != null)
            mistakesVariableMenager.Max = maxMistakes;
    }

    private void Update()
    {
        ControleCorrectsAndMistakes();
    }

    public void Reset()
    {
        mistakes = 0;
        corrects = 0;
        isGameOver = false;
    }
    public void ControleCorrectsAndMistakes()
    {
        if (mistakes >= maxMistakes && !isGameOver)
        {
            isGameOver = true;
            Thread.Sleep(1000);
            losePanel.SetActive(true);
        }
        else if (corrects >= maxCorrects && !isGameOver)
        {
            isGameOver = true;
            Thread.Sleep(1000);
            winPanel.SetActive(true);
        }
    }
    public void IncreaseCorrects()
    {
        corrects++;
        correctsVariableMenager.Increase();
    }
    public void IncreaseMistakes()
    {
        mistakes++;
        mistakesVariableMenager.Increase();
    }
}
