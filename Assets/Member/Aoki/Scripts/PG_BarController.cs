using UnityEngine;
using UnityEngine.UI;

public class PG_BarController : MonoBehaviour
{
    public Slider progressBar; // 進行度バー
    public RectTransform playerIndicator; // プレイヤーの位置インジケーター
    public Transform player; // プレイヤーのTransform
    public Transform startPoint; // スタート位置のTransform
    public Transform bossPoint; // ボス位置のTransform

    void Start()
    {
        // ゲーム開始時にプレイヤーの初期位置を設定
        UpdateProgressBar();
        UpdatePlayerIndicator();
    }

    void Update()
    {
        UpdateProgressBar();
        UpdatePlayerIndicator();
    }

    void UpdateProgressBar()
    {
        // スタート位置とボス位置の距離
        float totalDistance = Vector2.Distance(startPoint.position, bossPoint.position);
        // スタート位置とプレイヤー位置の距離
        float playerDistance = Vector2.Distance(startPoint.position, player.position);

        // 進行度を0から1の範囲で計算
        float progress = playerDistance / totalDistance;
        progressBar.value = progress;
    }

    void UpdatePlayerIndicator()
    {
        // 進行度バーの範囲に基づいてプレイヤーインジケーターの位置を更新
        Vector2 indicatorPosition = new Vector2(progressBar.fillRect.rect.width * progressBar.value, playerIndicator.anchoredPosition.y);
        playerIndicator.anchoredPosition = indicatorPosition;
    }
}
