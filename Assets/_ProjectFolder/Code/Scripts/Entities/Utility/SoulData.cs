using UnityEngine;

[System.Serializable]
public class DNIData
{
    public string name;
    public int age;
    public string occupation;
    public string identityDeclaration;
    public Texture2D photo;
    public bool isAuthentic;
}

[System.Serializable]
public class CVData
{
    public string name;
    public string profession;
    public int yearsOfExperience;
    public string[] achievements;
    public SoulCrime[] crimes;
}

[System.Serializable]
public class BelongingsData
{
    public string objectName;
    public string visualDescription;
    public string anomaly;
    public AndineLawType revealedLaw;
}