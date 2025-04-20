using UnityEngine;

public class DealCard : MonoBehaviour
{
    private CardControl cardControl;

    private void Start()
    {
        cardControl = GetComponent<CardControl>();
    }

    public void DealMyNewCard()
    {
        cardControl.currentState = CardControl.GameState.Dealing;
    }
}
