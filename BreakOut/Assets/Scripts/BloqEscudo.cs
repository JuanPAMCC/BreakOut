using UnityEngine;

public class BloqEscudo : Bloq
{
    public bool inv = true;

    public override void Hit(Ball b)
    {
        if (inv)
        {
            inv = false;
            return;
        }

        base.Hit(b);
    }
}
