using UnityEngine;

public class ShowMenuOnClick : MonoBehaviour
{
    [SerializeField] public GameObject blackBackground;
    [SerializeField] public GameObject button1;
    [SerializeField] public GameObject button2;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ç∂ÉNÉäÉbÉN
        {
            blackBackground.SetActive(true);
            button1.SetActive(true);
            button2.SetActive(true);
        }
    }
}
