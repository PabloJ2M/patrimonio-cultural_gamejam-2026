using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class NPC_Sequencer : MonoBehaviour
{
    [SerializeField] private int currentSoulIndex = 0;
    [SerializeField] private int maxStrikes = 3;

    [SerializeField] private SplineAnimate animate;
    [SerializeField] private ScriptableSoul[] souls;

    private ScriptableSoul _currentScriptableSoul;
    private int _totalScore = 0, _strikeCount = 0, _currentDay = 1;
    private bool _gameOver = false;

    public event Action<ScriptableSoul> OnNewSoulLoaded;
    public event Action OnSoulReachTable;
    public event Action<int, int> OnScoreChanged, OnStrikesChanged;
    public event Action<bool> OnGameOver, OnDesitionTaken;
    
    public ScriptableSoul GetCurrentSoul => _currentScriptableSoul;
    public int GetTotalScore => _totalScore;
    public int GetStrikeCount => _strikeCount;
    public int GetCurrentDay => _currentDay;
    public bool IsGameOver => _gameOver;

    //private void Start() => LoadNextSoul();
    public void LoadNextSoul()
    {
        if (currentSoulIndex >= souls.Length) {
            EndGame();
            return;
        }

        _currentScriptableSoul = souls[currentSoulIndex];
        OnNewSoulLoaded?.Invoke(_currentScriptableSoul);
        StartCoroutine(DropDelay());
    }
    private IEnumerator DropDelay()
    {
        yield return new WaitUntil(() => animate.IsPlaying);
        yield return new WaitUntil(() => 0.1f + animate.ElapsedTime >= animate.Duration);
        OnSoulReachTable?.Invoke();
    }
    
    public void OnDestinyDecided(bool sentToHananPacha, HashSet<AndineLawType> markedLaws)
    {
        if (_gameOver) return;

        var isCorrect = _currentScriptableSoul.VerifyVerdict(markedLaws, sentToHananPacha);
        var roundScore = _currentScriptableSoul.CalculateScore(markedLaws);
        OnDesitionTaken?.Invoke(sentToHananPacha);

        if (!isCorrect)
        {
            _strikeCount++;
            OnStrikesChanged?.Invoke(_strikeCount, maxStrikes);

            if (_strikeCount >= maxStrikes) {
                EndGame();
                return;
            }
        }
        
        currentSoulIndex++;
        if (currentSoulIndex % 3 == 0 && currentSoulIndex < souls.Length)
            _currentDay++;

        _totalScore += roundScore;
        OnScoreChanged?.Invoke(roundScore, _totalScore);
        
        Invoke(nameof(LoadNextSoul), 2f);
    }

    private void EndGame()
    {
        _gameOver = true;
        OnGameOver?.Invoke(_totalScore >= 300);
    }
}