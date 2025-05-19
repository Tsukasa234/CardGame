using UnityEngine;

public class DealingState : IGameState
{
    private readonly CardControl ctrl;
    public DealingState(CardControl c) => ctrl = c;

    public void Enter()
    {
        ctrl.TurnOffCards();
        int i = Random.Range(0, ctrl.dealingLeftCard.Length);
        ctrl.dealingLeftCard[i].SetActive(true);
        ctrl.dealtCardNumber = i;
        ctrl.ToggleButtons(hi: true, lo: true, /*equal: true,*/ deal: false);
    }

    public void Update() { }
    public void Exit() { }
}
