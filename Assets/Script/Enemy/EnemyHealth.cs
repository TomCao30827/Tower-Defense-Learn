using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [Tooltip("Increase enemy by 1 when it is destroyed")]
    [SerializeField] private int _difficultyRamp = 1;

    [SerializeField] private int _maxHitPoint = 5;
    [SerializeField] private int _currentHitPoint;

    public TextMeshPro textMeshProPrefab; // Reference to the TextMeshPro prefab
    private Enemy _enemy;

    private void OnEnable()
    {
        _currentHitPoint = _maxHitPoint;
    }

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        _currentHitPoint--;

        if (_currentHitPoint < 1)
        {
            _enemy.RewardGold();
            _maxHitPoint += _difficultyRamp;
            // Display +25 text
            StartCoroutine(DisplayText("+25", transform.position));
            gameObject.SetActive(false);
        }
    }

    private IEnumerator DisplayText(string message, Vector3 position)
    {
        // Instantiate the TextMeshPro object
        TextMeshPro textMesh = Instantiate(textMeshProPrefab, position, Quaternion.identity);
        textMesh.text = message;

        // Fade in
        float duration = 0.5f;
        float startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, (Time.time - startTime) / duration);
            textMesh.alpha = alpha;
            yield return null;
        }

        // Wait for a short period
        yield return new WaitForSeconds(1.0f);

        // Fade out
        startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, (Time.time - startTime) / duration);
            textMesh.alpha = alpha;
            yield return null;
        }

        // Destroy the TextMeshPro object
        Destroy(textMesh.gameObject);
    }
}
