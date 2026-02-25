using UnityEngine;

public class BloqMad : Bloq
{
    void Start()
    {
        if (hp < 3) hp = 3;
    }

    public override void Hit(Ball b)
    {
        hp -= 1;
        if (hp <= 0) Die(b);
    }
}