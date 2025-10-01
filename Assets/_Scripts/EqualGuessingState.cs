using UnityEngine;

/// <summary>
/// Estado de adivinanza "igual".
/// </summary>
public class EqualGuessingState : IGameState
{
    private readonly CardControl ctrl;

    public EqualGuessingState(CardControl controller)
    {
        ctrl = controller;
    }

    public void Enter()
    {
        int rightIndex = Random.Range(0, ctrl.turningRightCards.Length);
        ctrl.turningRightCards[rightIndex].SetActive(true);

        bool isCorrect = rightIndex == ctrl.dealtCardNumber;
        ctrl.ShowResult(isCorrect);

        if (isCorrect)
        {
            GlobalScore.Instance.AddScore(500); // 100 * 5
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
