using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 1f;

    public GameObject bombPrefab;
    public GameObject bulletPrefab;

    public Transform bombSpawnPoint;

    public Transform[] gunSpawnPoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        float vMove = 
            Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float hMove =
            Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        Vector3 pos = new Vector3(hMove, 0, vMove);
        transform.position += pos;

        if(Input.GetButtonDown("Fire1"))
        {
            Shoot(bombPrefab, bombSpawnPoint);
        }
        if(Input.GetButtonDown("Fire2"))
        {
            foreach(Transform t in gunSpawnPoints)
            {
                Shoot(bulletPrefab, t);

            }
        }
    }

    void Shoot(GameObject prefab, Transform spawnTransform)
    {
        var go = Instantiate(prefab);
        go.transform.position = spawnTransform.position;
        go.transform.rotation = spawnTransform.rotation;
    }
}
