using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunction : MonoBehaviour
{
    //public Button btn;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(PanelFunction);
    }

    void PanelFunction()
    {
        panel.SetActive(true);
    }
}
