using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> l_path = new List<Waypoint>();
    [SerializeField][Range(1.0f, 5.0f)] private float speed = 2.0f;

    private void Start()
    {
        StartCoroutine("FollowPath");
    }


    /// <summary>
    /// The enemy follow the path List using Lerp and corountine
    /// </summary>
    /// <returns></returns>
    private IEnumerator FollowPath()
    {
        foreach (var waypoint in l_path)
        {
            Vector3 startPos = this.transform.position;
            Vector3 endPos = waypoint.transform.position;

            this.transform.LookAt(endPos);

            float travelPercent = 0;

            while (travelPercent < 1.0f)
            {
                travelPercent += Time.deltaTime * speed;
                this.transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
