using UnityEngine;

/*
 * EnemySpawner.cs
 * EnemyRosterから現在戦の敵データを読み、敵をSpawnする
 */
public class EnemySpawner : MonoBehaviour
{

    [Header("敵の出現位置")]
    [SerializeField] private Transform spawnPoint; // 出現座標

    private GameObject currentEnemy; // 現在出現している敵

    /** 敵を出現させる */
    public void SpawnEnemy()
    {
        // 現在の敵がまだいるなら破棄
        if (currentEnemy != null)
        {
            Destroy(currentEnemy);
        }

        EnemyData enemyData = InGameManager.Instance.GetCurrentEnemy(); // EnemyRoster.assetにて出現させる敵のアセットを決めてる
        currentEnemy = Instantiate(enemyData.prefab, spawnPoint.position, spawnPoint.rotation);

        // TODO: カット演出を呼ぶ
        // TODO: EnemyControllerにenemyDataを渡す
    }

    /** 現在の敵を取得 */
    public GameObject GetCurrentEnemy()
    {
        return currentEnemy;
    }
}
