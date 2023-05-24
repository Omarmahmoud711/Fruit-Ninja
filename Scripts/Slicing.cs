using UnityEngine;

public class Slicing : MonoBehaviour
{
    public GameObject whole;
    public GameObject sliced;
    private Rigidbody rb;
    private Collider fruitcollider;
    private ParticleSystem juice;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        fruitcollider = GetComponent<Collider>();
        juice = GetComponentInChildren<ParticleSystem>();
    }
    private void slice(Vector3 direction, Vector3 position,float force) {

        whole.SetActive(false);
        sliced.SetActive(true);
        
        fruitcollider.enabled = false;
        juice.Play();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();
        foreach ( Rigidbody slice in slices) {
            slice.velocity = rb.velocity;
            slice.AddForceAtPosition(direction * force, position,ForceMode.Impulse);
        
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            Blade blade = other.GetComponent<Blade>();
            slice(blade.direction,blade.transform.position,blade.sliceForce);
        }
    }
}
