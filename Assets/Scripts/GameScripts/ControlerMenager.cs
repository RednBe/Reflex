using UnityEngine;
using UnityEngine.EventSystems;

public class ControlerMenager : MonoBehaviour, IPointerDownHandler
{
    public bool isActive = false;

    private void Update()
    {
        AdjustColor();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ControleClicks();
    }

    void ControleClicks()
    {
        if (isActive)
        {
            PlayerMenager.instance.IncreaseCorrects();
            ToggleActive();
        }
        else
            PlayerMenager.instance.IncreaseMistakes();
    }

    public void ToggleActive()
    {
        isActive = !isActive;

        AdjustColor();
    }

    public void AdjustColor()
    {
        if (isActive)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.darkRed;
        }
    }

}