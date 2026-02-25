using UnityEngine;

public class WinChk : MonoBehaviour
{
    public GM gm;
    bool ok = false;

    void Update()
    {
        if (ok) return;

        if (transform.childCount == 0)
        {
            ok = true;
            if (gm != null) gm.Win();
        }
    }
}