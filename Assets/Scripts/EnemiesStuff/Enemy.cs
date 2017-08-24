using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float speed = 7f;

    int currentWaypointIndex = 0;

    void Update()
    {
        if (Vector2.Distance(transform.position, Waypoints.waypoints[currentWaypointIndex].position) < 0.1f)
        {
            currentWaypointIndex++;
        }
        else
        {
            Vector2 direction = (Waypoints.waypoints[currentWaypointIndex].position - transform.position).normalized;
            Move(direction);
        }

        if (currentWaypointIndex == Waypoints.waypoints.Length)
        {
            Destroy(gameObject);
        }
    }


    void Move(Vector2 _direction)
    {
        transform.Translate(_direction * speed * Time.deltaTime, Space.World);
    }


}
