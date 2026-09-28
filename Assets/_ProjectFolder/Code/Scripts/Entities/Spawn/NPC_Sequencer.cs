using System;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Sequencer : MonoBehaviour
{
    [SerializeField] private ScriptableSoul[] souls;
    [SerializeField] private int currentSoulIndex = 0;
    [SerializeField] private int maxStrikes = 3;

    private ScriptableSoul _currentScriptableSoul;
    private int _totalScore = 0, _strikeCount = 0, _currentDay = 1;
    private bool _gameOver = false;

    public event Action<ScriptableSoul> OnNewSoulLoaded;
    public event Action<int, int> OnScoreChanged;
    public event Action<int> OnStrikesChanged;
    public event Action<bool> OnGameOver;
    
    public ScriptableSoul GetCurrentSoul => _currentScriptableSoul;
    public int GetTotalScore => _totalScore;
    public int GetStrikeCount => _strikeCount;
    public int GetCurrentDay => _currentDay;
    public bool IsGameOver => _gameOver;

    public void LoadNextSoul()
    {
        if (currentSoulIndex >= souls.Length) {
            EndGame();
            return;
        }

        _currentScriptableSoul = souls[currentSoulIndex];
        OnNewSoulLoaded?.Invoke(_currentScriptableSoul);
    }
    public void OnDestinyDecided(bool sentToHananPacha, HashSet<AndineLawType> markedLaws)
    {
        if (_gameOver) return;

        var isCorrect = _currentScriptableSoul.VerifyVerdict(markedLaws, sentToHananPacha);
        var roundScore = _currentScriptableSoul.CalculateScore(markedLaws);

        if (isCorrect)
        {
            
        }
        else
        {
            _strikeCount++;
            OnStrikesChanged?.Invoke(_strikeCount);

            if (_strikeCount >= maxStrikes) {
                EndGame();
                return;
            }
        }

        _totalScore += roundScore;
        OnScoreChanged?.Invoke(roundScore, _totalScore);

        currentSoulIndex++;

        if (currentSoulIndex % 3 == 0 && currentSoulIndex < souls.Length)
        {
            _currentDay++;
        }

        Invoke(nameof(LoadNextSoul), 2f);
    }

    private void EndGame()
    {
        _gameOver = true;
        bool won = _totalScore >= 300;
        OnGameOver?.Invoke(won);
    }
}