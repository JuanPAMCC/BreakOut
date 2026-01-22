using UnityEngine;

public class Ball : MonoBehaviour
{
    public GM gm;
    public Pad pad;
    public float spd = 8f;
    public float mul = 1.25f;
    public float minComp = 0.15f;

    Rigidbody rb;
    bool go = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!go && pad != null)
        {
            transform.position = pad.transform.position + new Vector3(0f, 0.6f, 0f);
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                go = true;
                rb.linearVelocity = new Vector3(1f, 0f, 1f).normalized * spd;
                Debug.Log("go");
            }
        }

        if (go)
        {
            float v = rb.linearVelocity.magnitude;
            if (v > 0.01f)
                rb.linearVelocity = rb.linearVelocity.normalized * spd;
        }
    }

    public void Rst()
    {
        go = false;
        if (rb != null) rb.linearVelocity = Vector3.zero;
        Debug.Log("rst bola");
    }

    public void Boost()
    {
        spd *= mul;
        Debug.Log("boost " + spd.ToString("F2"));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject.name == "Dead")
        {
            if (gm != null) gm.Lose();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (!go) return;
        if (col.collider == null) return;

        if (pad != null && col.collider.gameObject.Equals(pad.gameObject))
        {
            float px = pad.transform.position.x;
            float bx = transform.position.x;
            float dx = Mathf.Clamp((bx - px) / 1.2f, -1f, 1f);
            Vector3 dir = new Vector3(dx, 0f, 1f).normalized;
            rb.linearVelocity = dir * spd;
            return;
        }

        if (col.contactCount <= 0) return;

        Vector3 v0 = rb.linearVelocity;
        Vector3 n = col.contacts[0].normal;
        Vector3 v1 = Vector3.Reflect(v0, n);
        v1.y = 0f;

        if (Mathf.Abs(v1.x) < minComp)
            v1.x = Mathf.Sign(v1.x == 0f ? v0.x : v1.x) * minComp;

        if (Mathf.Abs(v1.z) < minComp)
            v1.z = Mathf.Sign(v1.z == 0f ? v0.z : v1.z) * minComp;

        rb.linearVelocity = v1.normalized * spd;
    }
}
