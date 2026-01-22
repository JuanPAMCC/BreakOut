using UnityEngine;

public class BloqPiedra : Bloq
{
    void Start()
    {
        if (hp < 5) hp = 5;
    }

    public override void Hit(Ball b)
    {
        hp -= 1;
        if (hp <= 0) Die();
    }
}
