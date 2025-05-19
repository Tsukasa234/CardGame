using UnityEngine;

public class EqualGuessingState : IGameState
{
    private readonly CardControl ctrl;

    public EqualGuessingState(CardControl controller)
    {
        ctrl = controller;
    }

    public void Enter()
    {
        int newIndex = Random.Range(0, ctrl.turningRightCards.Length);
        ctrl.turningRightCards[newIndex].SetActive(true);

        bool correct = newIndex == ctrl.dealtCardNumber;
        ctrl.ShowResult(correct);

        if (correct)
        {
            GlobalScore.Instance.AddScore(100 * 5);
        }
        else
        {
            GlobalScore.Instance.ResetScore();
        }

        ctrl.StartCoroutine(ctrl.RestartAfterDelay(3f));
    }

    public void Update() { }

    public void Exit() { }
}
