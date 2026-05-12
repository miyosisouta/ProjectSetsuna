using UnityEngine;
/*
 * GameManager.cs
 * ゲームの難易度・現在の戦数・ゲームの状態を保持
 */
public class InGameManager : MonoBehaviour
{
    /** インスタンス : シングルトン用 */
    public static InGameManager Instance { get; private set; }


    [Header("ゲーム設定")]
    //public EnemyRoster enemyRoster;           // エネミーの配列データだけ持つ
    //public DifficultyData currentDifficulty;  // 現在の難易度

    [Header("進行状態")]
    public int currentBattleIndex = 0;     // 現在何戦目か
    public int totalBattles = 5;           // 全部で何戦あるか


    /** 初期化 */
    private void Awake()
    {
        // すでに存在したら自分を消す
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);  // Scene跨ぎで生き続ける
    }


    /** 難易度設定 */
    //public void SetDifficulty(DifficultyData difficulty)
    //{
    //    currentDifficulty = difficulty;
    //}


    /** バトルの開始 */
    //public void StartBattle()
    //{
    //    currentBattleIndex = 0;
    //    SceneLoader.Instance.LoadScene("BattleScene"); // 一番最初の戦闘に入る
    //}


    /** 次のバトルへ進みたい */
    //public void NextBattle()
    //{
    //    currentBattleIndex++;
    //}


    /** すべて勝ったか */
    public bool IsAllWin()
    {
        return currentBattleIndex >= totalBattles;
    }


    /** エネミーを生成 */
    //public EnemyData GetCurrentEnemy()
    //{
    //    return enemyRoster.enemies[currentBattleIndex];
    //}
}
