using UnityEngine;

/*
 * DifficultyData.cs
 * 難易度ごとの設定（ScriptableObject）
 */

[CreateAssetMenu(fileName = "DifficultyData", menuName = "Scriptable Objects/DifficultyData")]
public class DifficultyData : ScriptableObject
{
    [Header("難易度設定")]
    public string difficultyName; // 難易度の名前
    public float windowDuration; // 猶予時間（秒）
}
