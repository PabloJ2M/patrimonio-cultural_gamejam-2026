using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UkuPacha/Soul Data")]
public class ScriptableSoul : ScriptableObject
{
    [Header("Identidad")]
    public string soulStereotype;
    public string description;
    public GameObject prefab;
    
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
    
    public int CalculateScore(HashSet<AndineLawType> markedLaws)
    {
        var correctMarks = 0;
        var falsePositives = 0;
        
        foreach (var marked in markedLaws)
        {
            if (System.Array.Exists(actualLawsBroken, x => x == marked))
                correctMarks++;
            else
                falsePositives++;
        }

        return (correctMarks * 50) - (falsePositives * 25);
    }
}