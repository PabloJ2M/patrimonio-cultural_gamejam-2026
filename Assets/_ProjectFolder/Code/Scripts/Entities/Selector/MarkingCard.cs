using System;
using System.Collections.Generic;
using UnityEngine;

namespace UkuPacha
{
    public class MarkingCard : MonoBehaviour
    {
        [SerializeField] private LawTogglePair[] lawToggles;

        [Serializable] private struct LawTogglePair
        {
            public AndineLawType law;
            public Toggle3D toggle;
        }
        private readonly HashSet<AndineLawType> markedLaws = new();

        public HashSet<AndineLawType> GetMarkedLaws => markedLaws;

        private void Awake()
        {
            foreach (var item in lawToggles)
                item.toggle.onValueChanged.AddListener((bool v) => ToggleLaw(item.law, v));
        }
        private void OnEnable()
        {
            foreach (var item in lawToggles)
                item.toggle.SetValueWithoutNotify(false);

            markedLaws.Clear();
        }

        public void ToggleLaw(AndineLawType law, bool add)
        {
            if (add)
                markedLaws.Add(law);
            else
                markedLaws.Remove(law);
        }
        public int CalculateScore(AndineLawType[] correctLaws)
        {
            int correctCount = 0;
            int falseCount = 0;

            foreach (var marked in markedLaws)
            {
                if (System.Array.Exists(correctLaws, x => x == marked))
                    correctCount++;
                else
                    falseCount++;
            }

            int score = (correctCount * 50) - (falseCount * 25);
            return Mathf.Max(0, score);
        }
    }
}