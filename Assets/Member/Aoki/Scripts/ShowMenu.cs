using UnityEngine;

public class ShowMenuOnClick : MonoBehaviour
{
    [SerializeField] private GameObject blackBackground;
    [SerializeField] private GameObject button1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���N���b�N
        {
            blackBackground.SetActive(true);
            button1.SetActive(true);
        }
    }
}
