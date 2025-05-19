public class StartState : IGameState
{
    private readonly CardControl ctrl;
    public StartState(CardControl c) => ctrl = c;

    public void Enter()
    {
        // 1) Apaga textos de resultado
        ctrl.correctText.SetActive(false);
        ctrl.incorrectText.SetActive(false);

        // 2) Apaga todas las cartas
        ctrl.TurnOffCards();

        // 3) Muestra sólo el botón Deal
        ctrl.ToggleButtons(hi: false, lo: false, /*equal: false,*/ deal: true);
    }

    public void Update() { }
    public void Exit() { }
}