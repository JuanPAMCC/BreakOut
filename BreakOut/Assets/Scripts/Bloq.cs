using UnityEngine;

public class Bloq : MonoBehaviour
{
    public int hp = 1;

    void OnCollisionEnter(Collision col)
    {
        if (col.collider == null) return;
        Ball b = col.collider.GetComponent<Ball>();
        if (b == null) return;
        Hit(b);
    }

    public virtual void Hit(Ball b)
    {
        hp -= 1;
        if (hp <= 0) Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
