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
    [SerializeField] private float waitTimeMin = 2.0f;  // ランダム待機の最小値
    [SerializeField] private float waitTimeMax = 5.0f;  // ランダム待機の最大値

    [SerializeField] private EnemySpawner enemySpawner; // エネミースポナー

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
        // 2. 敵を出す
        enemySpawner.SpawnEnemy();

        // 3. カット演出
        // TODO: 演出が終わるまで待つ

        // ランダム待機 → やり直しループ
        yield return StartCoroutine(WaitPhase());

        // 5. 押していいよ！のカットを出す
        // TODO: UIManager.ShowGoSign()を呼ぶ
        Debug.Log("今だ！");

        // 入力を受け付ける
        isWaitingInput = true;

        // 6. リザルト待ち（DodgeJudgeからEventBusで通知が来るまで待つ）
        // TODO: OnBattleWin / OnBattleLoseを購読して結果を受け取る
    }

    /** ランダム待機フェーズ（早押しミスでやり直し） */
    private IEnumerator WaitPhase()
    {
        while (true)
        {
            isWaitingInput = false;

            // ランダムな時間を決める
            float waitTime = Random.Range(waitTimeMin, waitTimeMax);
            float elapsed = 0f;

            bool missed = false;

            // 待機中に押されたかチェック
            while (elapsed < waitTime)
            {
                elapsed += Time.deltaTime;

                // 早押しミス（InputHandlerから通知が来たら）
                // TODO: InputHandlerと繋ぐ
                if (Keyboard.current.spaceKey.wasPressedThisFrame) // 仮入力
                {
                    Debug.Log("早押しミス！やり直し");
                    missed = true;
                    break;
                }

                yield return null; // 1フレーム待つ
            }

            // ミスがなければ待機フェーズ終了
            if (!missed) break;

            // 3に戻る
            // TODO: カット演出のやり直し処理
        }
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
}