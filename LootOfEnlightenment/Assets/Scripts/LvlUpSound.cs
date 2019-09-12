using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LvlUpSound : MonoBehaviour
{
    private AudioSource _source;
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
        Player.OnLvlUp += LvlUp;
    }

    void OnDisable()
    {
        Player.OnLvlUp -= LvlUp;
    }

    void LvlUp()
    {
        _source.Play();
    }
}
