using UnityEngine;
/*
 * EnemyData.cs
 * エネミー1体分のパラメータをまとめる
 */

[CreateAssetMenu(fileName = "EnemyData", menuName = "ProjectSetsuna/EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("基本情報")]
    public string enemyName;    // 敵の名前
    public GameObject prefab;   // 参照するプレハブ

    [Header("難易度別反応時間（秒）")]
    public float reactionTimeEasy;      // 難易度優しいの場合の反応時間
    public float reactionTimeNormal;    // 難易度普通の場合の反応時間
    public float reactionTimeHard;      // 難易度難しいの場合の反応時間
}
