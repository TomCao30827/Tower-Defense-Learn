using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField][Range(0.0f, 5.0f)] private float _speed = 1.0f;

    private List<Node> l_path = new List<Node>();
    private GridManager _gridManager;
    private Pathfinder _finder;
    private Enemy _enemy;

    private void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine("FollowPath");
    }

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _gridManager = FindObjectOfType<GridManager>();
        _finder = FindObjectOfType<Pathfinder>();
    }

    private void FindPath()
    {
        l_path.Clear();
        l_path = _finder.GetNewPath();
    }

    private void ReturnToStart()
    {
        this.transform.position = _gridManager.GetPositionFromCoordinates(_finder.StartCoordinate);
    }

    private void FinishPath()
    {
        _enemy.StealGold();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// The enemy follow the List path using Lerp and corountine
    /// </summary>
    /// <returns></returns>
    private IEnumerator FollowPath()
    {
        for (int i = 0; i < l_path.Count; i++)
        {
            Vector3 startPos = this.transform.position;
            Vector3 endPos = _gridManager.GetPositionFromCoordinates(l_path[i].coordinate);

            this.transform.LookAt(endPos);

            float travelPercent = 0.0f;

            while (travelPercent < 1.0f)
            {
                travelPercent += Time.deltaTime * _speed;
                this.transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }
}
