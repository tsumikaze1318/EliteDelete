using UnityEngine;
using UnityEngine.UI;

public class PG_BarController : MonoBehaviour
{
    public Slider progressSlider;  // スライダーの参照
    public Transform player;       // プレイヤーの参照
    public Transform goal;         // ゴールの参照

    private float startX;
    private float goalX;

    void Start()
    {
        // プレイヤーとゴールの初期位置を取得
        startX = player.position.x;
        goalX = goal.position.x;

        // スライダーの最大値を設定
        progressSlider.maxValue = goalX - startX;
    }

    void Update()
    {
        // プレイヤーの進行度を計算してスライダーに反映
        float playerProgress = player.position.x - startX;
        progressSlider.value = playerProgress;
    }
}

//    public Slider progressBar; // 進行度バー
//    public RectTransform playerIndicator; // プレイヤーの位置インジケーター
//    public Transform player; // プレイヤーのTransform
//    public Transform startPoint; // スタート位置のTransform
//    public Transform bossPoint; // ボス位置のTransform

//    void Start()
//    {
//        // ゲーム開始時にプレイヤーの初期位置を設定
//        UpdateProgressBar();
//        UpdatePlayerIndicator();
//    }

//    //void Update()
//    //{
//    //    UpdateProgressBar();
//    //    UpdatePlayerIndicator();
//    //}

//    void Update()
//    {
//        UpdateProgressBar();
//        UpdatePlayerIndicator();

//        Debug.Log($"Slider Value: {progressBar.value}");
//        Debug.Log($"Indicator Position: {playerIndicator.anchoredPosition}");
//    }

//    void UpdateProgressBar()
//    {
//        // スタート位置とボス位置の距離
//        float totalDistance = Vector2.Distance(startPoint.position, bossPoint.position);
//        // スタート位置とプレイヤー位置の距離
//        float playerDistance = Vector2.Distance(startPoint.position, player.position);

//        // 進行度を0から1の範囲で計算
//        float progress = Mathf.Clamp(playerDistance / totalDistance, 0, 1);  // 0から1に制限
//        progressBar.value = progress;
//    }

//    //void UpdateProgressBar()
//    //{
//    //    // スタート位置とボス位置の距離
//    //    float totalDistance = Vector2.Distance(startPoint.position, bossPoint.position);
//    //    // スタート位置とプレイヤー位置の距離
//    //    float playerDistance = Vector2.Distance(startPoint.position, player.position);

//    //    // 進行度を0から1の範囲で計算
//    //    float progress = playerDistance / totalDistance;
//    //    progressBar.value = progress;
//    //}

//    void UpdatePlayerIndicator()
//    {
//        // Sliderの幅を取得
//        float progressBarWidth = progressBar.GetComponent<RectTransform>().rect.width;

//        // Sliderのvalueに基づいてインジケーターの位置を計算
//        float indicatorPositionX = Mathf.Clamp(progressBarWidth * progressBar.normalizedValue, 0, progressBarWidth);

//        // プレイヤーインジケーターの位置を更新
//        playerIndicator.anchoredPosition = new Vector2(indicatorPositionX, playerIndicator.anchoredPosition.y);
//    }

//}
