using UnityEngine;

[CreateAssetMenu(order = 1, fileName = "GameSettings", menuName = "Scriptable Objects/New Game Settings")]
public class GameSettings : ScriptableObject
{
    public float PlayerMoveSpeed = 10f;
    public float PlayerTurnSpeed = 10f;
    public float HandwarmerBoostRatio = .1f;
    public float WarmerHoverHeight = 1f;
    public int WarmersLostOnHit = 3;
    public float FuelConsumptionSpeed = 5f;
    public int RequiredLaps = 3;
    public int MaxWarmersForMult = 14;
}