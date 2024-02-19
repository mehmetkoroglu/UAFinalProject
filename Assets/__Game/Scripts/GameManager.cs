using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject missle1, missle2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Cursor.lockState = CursorLockMode.None;
            Cam.Instance.SetTargetUCAV();
            UI.Instance.SetTaskText("Sað týk ile üzerinde hedef yazan binalarý vur!");

            missle1.SetActive(true);
            missle2.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            missle1.SetActive(false);
            missle2.SetActive(false);
            Cam.Instance.SetTargetPlayer();
        }
    }
}
