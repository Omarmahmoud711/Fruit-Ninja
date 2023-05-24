using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider SpawnArea;
    public GameObject[] fruits;
    public GameObject bomb;
    [Range(0f,1f)]
    public float bombchance = 0.05f;
    public float minDelay = 0.25f;
    public float maxDelay = 1f;
    public float minAngle = -15f;
    public float maxAngle = 15f;
    public float minForce = 18f;
    public float maxForce = 22f;
    public float maxLifeTime = 5f;
    private void Awake()
    {
        SpawnArea = GetComponent<Collider>();
    }
    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    
    private IEnumerator Spawn() {
        yield return new WaitForSeconds(2f);
        while (enabled) {

            GameObject prefab = fruits[Random.Range(0, fruits.Length)];

            if (Random.value < bombchance) {
                prefab = bomb;
            }
            Vector3 pos = new Vector3();

            pos.x = Random.Range(SpawnArea.bounds.min.x, SpawnArea.bounds.max.x);
            pos.y = Random.Range(SpawnArea.bounds.min.y, SpawnArea.bounds.max.y);
            pos.z = Random.Range(SpawnArea.bounds.min.z, SpawnArea.bounds.max.z);

            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));

            GameObject fruit = Instantiate(prefab, pos, rotation);
            float force = Random.Range(minForce, maxForce);

            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);

            Destroy(fruit, maxLifeTime);


            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));       }

    }
}
