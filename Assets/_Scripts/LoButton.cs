using UnityEngine;

public class LoButton : MonoBehaviour
{
    private CardControl cardControl;

    private void Start()
    {
        cardControl = GetComponent<CardControl>();
    }

    public void DealLoCard()
    {
        CardControl.GuessLo = true;
        cardControl.currentState = CardControl.GameState.Guessed;
    }
}
