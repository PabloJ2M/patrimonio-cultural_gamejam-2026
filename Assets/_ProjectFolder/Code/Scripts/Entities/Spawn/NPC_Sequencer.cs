using System;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Sequencer : MonoBehaviour
{
    [SerializeField] private SoulScriptable[] souls;
    [SerializeField] private int currentSoulIndex = 0;
    [SerializeField] private int maxStrikes = 3;

    private SoulScriptable currentSoul;
    private int totalScore = 0, strikeCount = 0, currentDay = 1;
    private bool gameOver = false;

    public Action<SoulScriptable> OnNewSoulLoaded;
    public Action<int, int> OnScoreChanged;
    public Action<int> OnStrikesChanged;
    public Action<bool> OnGameOver;

    public void LoadNextSoul()
    {
        if (currentSoulIndex >= souls.Length) {
            EndGame();
            return;
        }

        currentSoul = souls[currentSoulIndex];
        OnNewSoulLoaded?.Invoke(currentSoul);
    }
    public void OnDestinyDecided(bool sentToHananPacha, HashSet<AndineLawType> markedLaws)
    {
        if (gameOver) return;

        bool isCorrect = currentSoul.VerifyVerdict(markedLaws, sentToHananPacha);
        int roundScore = currentSoul.CalculateScore(markedLaws);

        if (isCorrect)
        {
            
        }
        else
        {
            strikeCount++;
            OnStrikesChanged?.Invoke(strikeCount);

            if (strikeCount >= maxStrikes)
            {
                EndGame();
                return;
            }
        }

        totalScore += roundScore;
        OnScoreChanged?.Invoke(roundScore, totalScore);

        currentSoulIndex++;

        if (currentSoulIndex % 3 == 0 && currentSoulIndex < souls.Length)
        {
            currentDay++;
        }

        Invoke(nameof(LoadNextSoul), 2f);
    }

    private void EndGame()
    {
        gameOver = true;
        bool won = totalScore >= 300;
        OnGameOver?.Invoke(won);
    }
}