public class StartState : IGameState
{
    private readonly CardControl ctrl;
    public StartState(CardControl c) => ctrl = c;

    public void Enter()
    {
        ctrl.correctText.SetActive(false);
        ctrl.incorrectText.SetActive(false);

        ctrl.TurnOffCards();

        ctrl.ToggleButtons(hi: false, lo: false, /*equal: false,*/ deal: true);
    }

    public void Update() { }
    public void Exit() { }
}