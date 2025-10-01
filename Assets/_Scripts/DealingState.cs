using UnityEngine;

/// <summary>
/// Estado de reparto de carta inicial.
/// </summary>
public class DealingState : IGameState
{
    private readonly CardControl ctrl;
    public DealingState(CardControl c) => ctrl = c;

    public void Enter()
    {
        ctrl.TurnOffCards();
        int index = Random.Range(0, ctrl.dealingLeftCard.Length);
        ctrl.dealingLeftCard[index].SetActive(true);
        ctrl.dealtCardNumber = index;
        // Habilitar todos los botones de adivinanza
        ctrl.ToggleButtons(hi: true, lo: true, equal: true, deal: false);
    }

    public void Update() { }
    public void Exit() { }
}
