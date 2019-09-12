using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AoEEffect : MonoBehaviour
{
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(KillMe());
    }

    private IEnumerator KillMe()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }
}
