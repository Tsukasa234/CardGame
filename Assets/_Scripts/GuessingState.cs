using UnityEngine;

public class GuessingState : IGameState
{
    private readonly CardControl ctrl;
    private readonly bool guessHigh;

    public GuessingState(CardControl c, bool gHi)
    {
        ctrl = c;
        guessHigh = gHi;
    }

    public void Enter()
    {
        int i = Random.Range(0, ctrl.turningRightCards.Length);
        ctrl.turningRightCards[i].SetActive(true);

        bool correct = guessHigh
            ? i >= ctrl.dealtCardNumber
            : i <= ctrl.dealtCardNumber;

        ctrl.ShowResult(correct);

        // Suma o reinicia según acierto o fallo
        if (correct)
            GlobalScore.Instance.AddScore(100);
        else
            GlobalScore.Instance.ResetScore();

        ctrl.stateMachine.ChangeState(new GameOverState(ctrl));


    }

    public void Update() { }
    public void Exit() { }
}
