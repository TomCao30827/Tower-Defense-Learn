using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public List<Button> buttonList;
    public List<GameObject> panelList;

    private void Start()
    {
        foreach(var panel in panelList)
            panel.SetActive(false);

    }

}
