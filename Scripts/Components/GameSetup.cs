using UnityEngine;
using Entitas.CodeGeneration.Attributes;


[CreateAssetMenu]
[Game, Unique]
public class GameSetup : ScriptableObject
{
    public uint gameFieldSize;
    public GameObject gameCellPrefab;
    public GameObject circlePrefab;
    public GameObject crossPrefab;
}
