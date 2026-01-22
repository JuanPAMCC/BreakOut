using UnityEngine;

public class Pad : MonoBehaviour
{
    public float minX = -4f;
    public float maxX = 4f;
    public float z = -3.61f;
    public float spd = 12f;

    Vector3 p0;

    void Awake()
    {
        p0 = transform.position;
    }

    void Update()
    {
        float x = transform.position.x;

        if (Input.mousePresent)
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane pl = new Plane(Vector3.up, new Vector3(0f, transform.position.y, 0f));
            float t;
            if (pl.Raycast(r, out t))
            {
                Vector3 w = r.GetPoint(t);
                x = w.x;
            }
        }
        else
        {
            x += Input.GetAxis("Horizontal") * spd * Time.deltaTime;
        }

        x = Mathf.Clamp(x, minX, maxX);
        transform.position = new Vector3(x, p0.y, z);
    }

    public void Rst()
    {
        transform.position = new Vector3(p0.x, p0.y, z);
    }
}
