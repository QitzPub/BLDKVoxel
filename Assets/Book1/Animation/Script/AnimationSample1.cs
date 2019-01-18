using UnityEngine;
using UnityEngine.UI;

//DoTweenを利用するために必要なusing文
using DG.Tweening;

//DoTweenのサンプルクラス
public class AnimationSample1 : MonoBehaviour
{
    //ジャンプしたり、振動したりするキャラクター
    [SerializeField] GameObject character;
    [SerializeField] Animator animator;

    //ジャンプアップ、ジャンプアップ落下、振動の３種類のボタン
    [SerializeField] Button idleButton;
    [SerializeField] Button walkButton;
    [SerializeField] Button attackButton;

    //シーンの最初に一度だけ呼ばれる
    //初期化やイベントの登録に使う
    void Start()
    {
        idleButton.onClick.AddListener(() => PlayAnimation("Idle"));
        walkButton.onClick.AddListener(() => PlayAnimation("Walk"));
        attackButton.onClick.AddListener(() => PlayAnimation("Attack"));
    }

    //キャラが待機するアニメーションの再生
    void PlayAnimation(string state)
    {
        animator.Play(state);
    }
}
