using UnityEngine;

public class BloqLargo : Bloq
{
    public float mx = 1.6f;

    void Awake()
    {
        Vector3 s = transform.localScale;
        s.x *= mx;
        transform.localScale = s;

        if (hp < 2) hp = 2;
    }

    public override void Hit(Ball b)
    {
        hp -= 1;

        Vector3 s = transform.localScale;
        s.x *= 0.85f;
        transform.localScale = s;

        if (hp <= 0) Die();
    }
}
