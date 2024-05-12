using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;

    private void Update()
    {
        // Kiểm tra nếu phím Escape được nhấn
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Kiểm tra xem targetObject có tồn tại không
            if (targetObject != null)
            {
                // Bật/tắt trạng thái active của targetObject
                targetObject.SetActive(!targetObject.activeSelf);
            }
            else
            {
                Debug.LogWarning("Không có GameObject nào được gán cho targetObject.");
            }
        }
    }
}
