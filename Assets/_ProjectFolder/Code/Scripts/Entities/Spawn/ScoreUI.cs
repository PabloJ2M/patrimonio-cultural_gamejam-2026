using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private NPC_Sequencer sequencer;
    [SerializeField] private TextMeshProUGUI scoreText, strikesText, dayText;
    
    [SerializeField] private TweenCanvasGroup victoryScreen, loseScreen;
    [SerializeField] private UnityEvent onComplete;

    private void Start()
    {
        ScoreUpdated(0, 0);
        Strikes(0, 0);
    }
    private void OnEnable()
    {
        sequencer.OnScoreChanged += ScoreUpdated;
        sequencer.OnStrikesChanged += Strikes;
        sequencer.OnGameOver += GameOverScreen;
    }
    private void OnDisable()
    {
        sequencer.OnScoreChanged -= ScoreUpdated;
        sequencer.OnStrikesChanged -= Strikes;
        sequencer.OnGameOver -= GameOverScreen;
    }

    private void ScoreUpdated(int score, int total)
    {
        scoreText.SetText($"Score: {total}");
        dayText.SetText($"Day: {sequencer.GetCurrentDay}");
    }
    private void Strikes(int value, int max)
    {
        strikesText.SetText($"Strikes: {value}/{max}");
    }
    private async void GameOverScreen(bool value)
    {
        if (!value)
            loseScreen?.FadeIn();
        else
            victoryScreen?.FadeIn();

        await Awaitable.WaitForSecondsAsync(0.1f);
        onComplete.Invoke();
    }
}
