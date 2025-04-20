using UnityEngine;

public class HiButton : MonoBehaviour
{

    private CardControl cardControl;

    private void Start()
    {
        cardControl = GetComponent<CardControl>();
    }

    public void DealHiCard()
    {
        CardControl.GuessHi = true;
        cardControl.currentState = CardControl.GameState.Guessed;
    }
}
