using UnityEngine;

[CreateAssetMenu(fileName = "New Coin Data", menuName = "Coin Data")]
public class CoinData : ScriptableObject
{
    public int MinValue = 1;
    public int MaxValue = 10;
}