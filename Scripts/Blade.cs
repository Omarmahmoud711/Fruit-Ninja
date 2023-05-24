using UnityEngine;

public class Blade : MonoBehaviour
{

    private bool slicing;
    private Camera cam;
    private Collider bladeColider;
    private TrailRenderer SliceTrail;
    public float sliceForce = 5f;
    public float minVelocity = 0.001f;
    public Vector3 direction { get; private set; }

    private void Awake()
    {
        bladeColider = GetComponent<Collider>();
        SliceTrail = GetComponentInChildren<TrailRenderer>();
        cam = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            StartSlicing();
        }

        else if (Input.GetMouseButtonUp(0))
        {
            StopSlicing();
        }

        else if (slicing) {
            contSlicing();
        }

       
    }

    private void StartSlicing()
    {
        Vector3 newpos = cam.ScreenToWorldPoint(Input.mousePosition);
        newpos.z = 0f;
        transform.position = newpos;
        slicing = true;
        bladeColider.enabled = true;
        SliceTrail.enabled = true;
        SliceTrail.Clear();
    }

    private void StopSlicing() {
        slicing = false;
        bladeColider.enabled = false;
        SliceTrail.enabled = false;
    }
    private void OnDisable()
    {
        StopSlicing();
    }

    private void OnEnable()
    {
        StopSlicing();
    }
    private void contSlicing() {
        Vector3 newpos = cam.ScreenToWorldPoint(Input.mousePosition);
        newpos.z = 0f;
        direction = newpos - transform.position;
        float velocity = direction.magnitude / Time.deltaTime;
        bladeColider.enabled = velocity > minVelocity;
        transform.position = newpos;
    }

}
