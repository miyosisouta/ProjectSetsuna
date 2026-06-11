using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class SceneLoder : MonoBehaviour
{
    // 移動先シーン名
    [SerializeField]
    private string nextSceneName = "TitleScene";

    //// 待機時間
    //[SerializeField]
    //private float waitTime = 2.0f;

    /// <summary>
    ///  シーン開始時
    /// </summary>
    private async void Start()
    {
        // 秒待機
        //await UniTask.Delay((int)(waitTime * 1000));

        // シーン遷移
        await LoadScene(nextSceneName);
    }

    /// <summary>
    /// シーン読み込み
    /// </summary>
    public async UniTask LoadScene(string sceneName)
    {
        Debug.Log("シーンロードを開始");

        // シーンを非同期でロード
        //await SceneManager.LoadSceneAsync(sceneName).ToUniTask();

        // Kキーが押されたらシーン遷移
        await UniTask.WaitUntil(() => Keyboard.current.kKey.wasPressedThisFrame);
        await SceneManager.LoadSceneAsync(sceneName).ToUniTask();

        Debug.Log("シーンロードが完了"); ;
    }
}
