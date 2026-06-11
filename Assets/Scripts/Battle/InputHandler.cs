using UnityEngine;
using UnityEngine.InputSystem;

/*
 * InputHandler.cs
 * プレイヤーの入力を受け取りBattleManagerに通知する
 * キーボード・ゲームパッド両対応
 */
public class InputHandler : MonoBehaviour
{
    [SerializeField] private DodgeJudge dodgeJudge;

    private void Update()
    {
        if (IsDodgeButtonPressed())
        {
            dodgeJudge.OnButtonPressed(); 
        }
    }


    /** 見切りボタンが押されたか */
    private bool IsDodgeButtonPressed()
    {
        // キーボード：スペースキー
        bool keyboard = Keyboard.current != null &&
                        Keyboard.current.spaceKey.wasPressedThisFrame;

        // ゲームパッド：Aボタン
        bool gamepad = Gamepad.current != null &&
                       Gamepad.current.buttonSouth.wasPressedThisFrame;

        return keyboard || gamepad;
    }
}