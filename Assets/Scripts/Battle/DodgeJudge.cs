using System.Collections;
using UnityEngine;
using TMPro;

/*
 * DodgeJudge.cs
 * 待ち時間・受付時間の計測と現在の状態を管理する
 */
public class DodgeJudge : MonoBehaviour
{
    /** 現在の状態 */
    public enum DodgePhase
    {
        Idle,       // 待機中
        Waiting,    // 待ち時間中
        Accepting,  // 受付中
        After       // 受付時間過ぎ
    }

    // 現在の状態
    public DodgePhase CurrentPhase { get; private set; } = DodgePhase.Idle;

    [Header("待ち時間")]
    [SerializeField] private float waitTimeMin = 1.5f; // 待ち時間の最低ライン
    [SerializeField] private float waitTimeMax = 5.0f; // 待ち時間の最大ライン

    [Header("受付時間")]
    [SerializeField] private float windowDuration = 1.0f; // DifficultyDataから取得予定

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI phaseText;


    /** 計測開始 */
    public void StartJudge()
    {
        StartCoroutine(JudgeFlow());
    }

    private IEnumerator JudgeFlow()
    {
        // 待ち時間
        CurrentPhase = DodgePhase.Waiting;
        phaseText.text = "WAIT";
        float waitTime = Random.Range(waitTimeMin, waitTimeMax);
        yield return new WaitForSeconds(waitTime);

        // 受付時間
        CurrentPhase = DodgePhase.Accepting;
        phaseText.text = "NOW";
        yield return new WaitForSeconds(windowDuration);

        // 受付時間過ぎ
        CurrentPhase = DodgePhase.After;
        phaseText.text = "Failure";
        EventBus.OnDodgeFail?.Invoke();
    }

    public void OnButtonPressed()
    {
        switch (CurrentPhase)
        {
            case DodgePhase.Waiting:
                // お手付き → 仕切り直し
                Debug.Log("お手付き！仕切り直し！");
                ShowRetryText();
                StopAllCoroutines();
                StartCoroutine(JudgeFlow());
                break;

            case DodgePhase.Accepting:
                // 受付時間内 → 勝ち
                Debug.Log("WIN！");
                StopAllCoroutines(); // JudgeFlowを止める
                CurrentPhase = DodgePhase.Idle;
                phaseText.text = "WIN!";
                EventBus.OnDodgeSuccess?.Invoke();
                break;

            case DodgePhase.After: 
                // 受付時間過ぎ → 無視
                Debug.Log("時間切れ：入力を無視");
                break;

            case DodgePhase.Idle:
                // まだ開始していない → 無視
                break;
        }
    }

    /** お手付きテキストを表示 */
    public void ShowRetryText()
    {
        phaseText.text = "Replay";
    }
}