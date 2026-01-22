using UnityEngine;

public class WinChk : MonoBehaviour
{
    bool ok = false;

    void Update()
    {
        if (ok) return;

        if (transform.childCount == 0)
        {
            ok = true;
            Debug.Log("FELICIDADES");
        }
    }
}
