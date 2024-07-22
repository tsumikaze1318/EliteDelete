using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform player; // �v���C���[��Transform���i�[���邽�߂̕ϐ�
    public float smoothSpeed = 0.125f; // �J�����̒Ǐ]���x
    public Vector3 offset; // �v���C���[�ƃJ�����̋�����ێ�����I�t�Z�b�g

    void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
