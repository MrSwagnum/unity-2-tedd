using System.Collections;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    private bool _alive = true;

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    

    void Update()
    {
        if (_alive)
        {
            Move();

            if (CheckObstacle())
            {
                ChangeDirection();
            }

            CheckForPlayer();
        }
    }

    void Move()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    bool CheckObstacle()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            return hit.distance < obstacleRange;
        }

        return false;
    }

    void ChangeDirection()
    {
        float angle = Random.Range(-110, 110);
        transform.Rotate(0, angle, 0);
    }

    void CheckForPlayer()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            
            if (hitObject.GetComponent<PlayerCharacter>() && _fireball == null)
            {
                ShootFireball();
            }
            else if (hit.distance < obstacleRange)
            {
                ChangeDirection();
            }
        }
    }

    void ShootFireball()
    {
        _fireball = Instantiate(fireballPrefab, transform.position + transform.forward * 1.5f, transform.rotation);
    }
}
