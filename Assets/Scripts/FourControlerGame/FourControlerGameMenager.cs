using System.Collections;
using UnityEngine;

public class FourControlerGameMenager : MonoBehaviour
{
    public float WaitTime;

    [Header("Controlers")]
    [SerializeField] ControlerMenager upperLeftControler;
    [SerializeField] ControlerMenager upperRightControler;
    [SerializeField] ControlerMenager bottomLeftControler;
    [SerializeField] ControlerMenager bottomRightControler;

    [Header("Counters")]
    [SerializeField] CounterMenager upperLeftCounter;
    [SerializeField] CounterMenager upperRightCounter;
    [SerializeField] CounterMenager bottomLeftCounter;
    [SerializeField] CounterMenager bottomRightCounter;

    private void Awake()
    {
        WaitTime = MenuMenager.CurrentWaitTime;

        upperLeftControler.isActive = false;
        upperRightControler.isActive = false;
        bottomLeftControler.isActive = false;
        bottomRightControler.isActive = false;
        PlayerMenager.instance.isGameOver = false;
    }

    private void Start()
    {
        StartCoroutine(AdjustControlers());
    }

    public IEnumerator AdjustControlers()
    {
        while (!PlayerMenager.instance.isGameOver)
        {
            float startTime = Random.Range(1f, 3f);
            yield return new WaitForSeconds(startTime);
            byte random = (byte)Random.Range(0, 3);

            if (random == 0)
            {
                upperLeftControler.ToggleActive();
                yield return new WaitForSeconds(WaitTime);
                if (upperLeftControler.isActive)
                {
                    upperLeftControler.ToggleActive();
                    PlayerMenager.instance.IncreaseMistakes();
                }
            }
            else if (random == 1)
            {
                upperRightControler.ToggleActive();
                yield return new WaitForSeconds(WaitTime);
                if (upperRightControler.isActive)
                {
                    upperRightControler.ToggleActive();
                    PlayerMenager.instance.IncreaseMistakes();
                }
            }
            else if (random == 2)
            {
                bottomLeftControler.ToggleActive();
                yield return new WaitForSeconds(WaitTime);
                if (bottomLeftControler.isActive)
                {
                    bottomLeftControler.ToggleActive();
                    PlayerMenager.instance.IncreaseMistakes();
                }
            }
            else if (random == 3)
            {
                bottomRightControler.ToggleActive();
                yield return new WaitForSeconds(WaitTime);
                if (bottomRightControler.isActive)
                {
                    bottomRightControler.ToggleActive();
                    PlayerMenager.instance.IncreaseMistakes();
                }
            }
        }
    }
}
