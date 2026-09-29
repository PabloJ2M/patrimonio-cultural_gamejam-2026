using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UkuPacha/Soul Data")]
public class ScriptableSoul : ScriptableObject
{
    [Header("Identidad")]
    public GameObject prefab;
    public string soulStereotype;
    
    [TextArea(1, 10)]
    public string description;
    
    [Header("Documentos")]
    public DNIData dni;
    public CVData cv;
    
    [Header("Pertenencias")]
    public BelongingsData[] belongings;
    
    [Header("Verdad")]
    public AndineLawType[] actualLawsBroken;
    public bool isGoodSoul;
    
    [Header("Día de aparición")]
    [SerializeField] public int appearDay = 1;
    
    public bool VerifyVerdict(HashSet<AndineLawType> markedLaws, bool sentToHananPacha)
    {
        var marksCorrect = actualLawsBroken.All(markedLaws.Contains);

        if (markedLaws.Any(markedLaw => !System.Array.Exists(actualLawsBroken, x => x == markedLaw)))
            marksCorrect = false;
        
        var destinyCorrect = (sentToHananPacha == isGoodSoul);
        return marksCorrect && destinyCorrect;
    }
    public int CalculateScore(HashSet<AndineLawType> markedLaws, bool sentToHananPacha)
    {
        if (!VerifyVerdict(markedLaws, sentToHananPacha))
            return 0;
        
        var correctLawCount = 0;
        
        foreach (var marked in markedLaws)
        {
            if (System.Array.Exists(actualLawsBroken, x => x == marked))
                correctLawCount++;
        }

        var score = 40 + (correctLawCount * 20);
        return score;
    }
}