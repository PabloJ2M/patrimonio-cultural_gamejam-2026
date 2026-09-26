using System;
using UnityEngine;

[Flags] public enum Conditions
{
    AL,
    AQ,
    AS
}

[CreateAssetMenu(fileName = "Character", menuName = "Scriptable Objects/Character")]
public class ScriptableCharacter : ScriptableObject
{
    public string Name;
    public Sprite Image;
    
    public Conditions Condition;
}
