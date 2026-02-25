using System.Collections;
using UnityEngine;

public class Bloq : MonoBehaviour
{
    public OptionsSO options;

    public int hp = 1;
    public int pts = 10;

    void Start()
    {
        StartCoroutine(ApplyDifficultyDeferred());
    }

    IEnumerator ApplyDifficultyDeferred()
    {
        yield return null;

        int bonus = 0;
        if (options != null) bonus = DifficultyScaler.BlockBonus(options.difficulty);

        hp = Mathf.Max(1, hp + bonus);
    }

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
        if (hp <= 0) Die(b);
    }

    protected virtual void Die(Ball b)
    {
        if (b != null && b.gm != null) b.gm.AddScore(pts);
        Destroy(gameObject);
    }
}