using UnityEngine;
using System;
/*
 * EventBus.cs
 * コンポーネント間の通知を仲介するstaticクラス
 * イベントが必要になったタイミングで順次追加していく
 */
public static class EventBus
{
    // 見切り成功 : 伝える相手→attleManager, UIManager
    public static Action OnDodgeSuccess;

    // 見切り失敗 : 伝える相手→attleManager, UIManager
    public static Action OnDodgeFail;

    // TODO: 1戦勝利（BattleManager → UIManager）
    // TODO: 1戦敗北（BattleManager → UIManager）
    // TODO: 5連勝（BattleManager → ResultUI）
}
