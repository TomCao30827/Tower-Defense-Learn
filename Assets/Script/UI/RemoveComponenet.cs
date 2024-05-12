using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class RemoveComponenet : MonoBehaviour
{
    private void Awake()
    {
        RemoveComponentFromChildren<Tile>(this.transform);
        //RemoveGameObjectFromChildren("Text (TMP)", this.transform);
        RemoveComponentFromChildren<TextMeshPro>(this.transform);
    }

    public void RemoveComponentFromChildren<T>(Transform parentTransform) where T : Component
    {
        // Iterate through each child of the parent transform
        foreach (Transform child in parentTransform)
        {
            // Check if the child has the component attached
            T component = child.GetComponent<T>();

            // If the component exists, remove it
            if (component != null)
            {
                Destroy(component);
                Debug.Log("Component removed from the child object: " + child.name);
            }
            else
            {
                Debug.LogWarning("The child object " + child.name + " does not have the specified component.");
            }

            // Recursively call this function to check the children of the current child
            RemoveComponentFromChildren<T>(child);
        }
    }

    public void RemoveGameObjectFromChildren(string gameObjectName, Transform parentTransform)
    {
        // Find the child GameObject with the specified name
        Transform child = parentTransform.Find(gameObjectName);

        // If the child exists, destroy it
        if (child != null)
        {
            Destroy(child.gameObject);
            Debug.Log("GameObject removed from the children of the parent object: " + gameObjectName);
        }
        else
        {
            Debug.LogWarning("The child object with the name " + gameObjectName + " does not exist.");
        }
    }
}
