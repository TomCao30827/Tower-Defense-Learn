using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private Enemy _enemy;

    public List<Waypoint> l_path = new List<Waypoint>();
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

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        foreach (GameObject waypoint in waypoints)
        {
            l_path.Add(waypoint.GetComponent<Waypoint>());
        }
    }

    private void ReturnToStart()
    {
        this.transform.position = l_path[0].transform.position;
    }


    /// <summary>
    /// The enemy follow the List path using Lerp and corountine
    /// </summary>
    /// <returns></returns>
    private IEnumerator FollowPath()
    {
        foreach (var waypoint in l_path)
        {
            Vector3 startPos = this.transform.position;
            Vector3 endPos = waypoint.transform.position;

            this.transform.LookAt(endPos);

            float travelPercent = 0.0f;

            while (travelPercent < 1.0f)
            {
                travelPercent += Time.deltaTime * speed;
                this.transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        _enemy.StealGold();
        gameObject.SetActive(false);
    }
}
