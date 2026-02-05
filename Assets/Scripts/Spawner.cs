using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    public Vector2 MinMaxInterval;
    float Interval;

    float Count = 0;

    public GameObject[] BaseObjects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start: " + this);
        Interval = Random.Range(MinMaxInterval.x, MinMaxInterval.y);
    }

    // Update is called once per frame
    void Update()
    {
        Count += Time.deltaTime;
        if (Count > Interval)
        {
            Debug.Log("Spawn " + this);
            Count = 0;
            Interval = Random.Range(MinMaxInterval.x, MinMaxInterval.y);

            var index = Random.Range(0, BaseObjects.Length);
            var go = Instantiate(BaseObjects[index]);
            go.transform.position =
                (Random.onUnitSphere * 5) + transform.position;

        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Fire");
        }
    }

}
