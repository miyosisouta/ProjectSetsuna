using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * BattleManager.cs
 * 戦闘の流れを管理する
 * 1戦ごとの進行・5連戦のループを制御
 */
public class BattleManager : MonoBehaviour
{
    [Header("設定")]
    [SerializeField] private float waitTimeMin = 1.5f;  // ランダム待機の最小値
    [SerializeField] private float waitTimeMax = 5.0f;  // ランダム待機の最大値

    [SerializeField] private EnemySpawner enemySpawner; // エネミースポナー
    [SerializeField] private DodgeJudge dodgeJudge; // 時間と状態の取得

    /** 早押し受付中かどうか */
    public bool isWaitingInput { get; private set; } = false; // get; private set(読むのは誰でも可、変更はこのクラスのみ)

    private void Start()
    {
        StartCoroutine(BattleFlow());
    }

    private void Update()
    {
        if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            StartCoroutine(NextEnemy());
        }
    }


    /** 1戦分の流れ */
    private IEnumerator BattleFlow()
    {
        // 1. 敵を出す
        enemySpawner.SpawnEnemy();

        // 22. カット演出
        // TODO: 演出が終わるまで待つ

        // の計測開始
        dodgeJudge.StartJudge();


        // 5. リザルト待ち（DodgeJudgeからEventBusで通知が来るまで待つ）
        // TODO: OnBattleWin / OnBattleLoseを購読して結果を受け取る

        yield return null; // エラー防止
    }


    /** 次の敵へ進む */
    private IEnumerator NextEnemy()
    {
        // TODO: 勝ちの演出を待つ
        // TODO: ブラックアウト演出を待つ

        yield return null;

        InGameManager.Instance.NextBattle();

        if (InGameManager.Instance.IsAllWin())
        {
            // TODO: 全勝処理
            Debug.Log("全勝！");
        }
        else
        {
            // 2に戻る
            StartCoroutine(BattleFlow());
        }
    }


    /** 受付時間が過ぎたかどうか */
    public bool isAfterInput { get; private set; } = false;
}