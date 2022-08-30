using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField]
    int speed = 2;

    [SerializeField]
    Vector3 direction;

    [SerializeField]
    float timer;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            ChangeDirection();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(Random.Range(-1f,1f),0, Random.Range(-1f, 1f));
        StartCoroutine("ChangeDirecrionCorutine");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(speed * Time.deltaTime * direction, Space.Self);
    }

    void ChangeDirection()
    {
        float newX = direction.x > 0 ? Random.Range(-1f, 0f) : Random.Range(0f, 1f);
        float newZ = direction.z > 0 ? Random.Range(-1f, 0f) : Random.Range(0f, 1f);
        direction = new Vector3(newX, 0, newZ);
    }
    
    IEnumerator ChangeDirecrionCorutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            ChangeDirection();
        }
    }

    public Vector3 Direction()
    {
        return direction;
    }
}
