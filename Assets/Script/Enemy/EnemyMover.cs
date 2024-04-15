using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    private Enemy _enemy;

    public List<Tile> l_path = new List<Tile>();
    [SerializeField][Range(1.0f, 5.0f)] private float speed = 2.0f;

    private void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine("FollowPath");
    }

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void FindPath()
    {
        l_path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parent.transform)
        {
            Tile Tile = child.GetComponent<Tile>();
            if (Tile != null )
            {
                l_path.Add(Tile);
            }
        }
    }

    private void ReturnToStart()
    {
        this.transform.position = l_path[0].transform.position;
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
        foreach (var Tile in l_path)
        {
            Vector3 startPos = this.transform.position;
            Vector3 endPos = Tile.transform.position;

            this.transform.LookAt(endPos);

            float travelPercent = 0.0f;

            while (travelPercent < 1.0f)
            {
                travelPercent += Time.deltaTime * speed;
                this.transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }
}
