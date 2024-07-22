using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform player; // プレイヤーのTransformを格納するための変数
    public float smoothSpeed = 0.125f; // カメラの追従速度
    public Vector3 offset; // プレイヤーとカメラの距離を保持するオフセット

    void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
