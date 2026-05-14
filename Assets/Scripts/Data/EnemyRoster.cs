using UnityEngine;
/*
 * EnemyRoster.cs
 * 5連戦分の敵データをまとめて保持
 */

[CreateAssetMenu(fileName = "EnemyRoster", menuName = "ProjectSetsuna/EnemyRoster")]
public class EnemyRoster : ScriptableObject
{
    [Header("5連戦の敵リスト")]
    public EnemyData[] enemies;
}
