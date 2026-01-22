using UnityEngine;

public class BloqGom : Bloq
{
    public override void Hit(Ball b)
    {
        base.Hit(b);
        if (b != null) b.Boost();
    }
}
