using UnityEngine;
using UnityEngine.Rendering;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] AudioSource _dieSource;
    [SerializeField] AudioSource _pointSource;
    public static AudioSource dieSource;
    public static AudioSource pointSource;

    private void Start()
    {
        dieSource = _dieSource;
        pointSource = _pointSource;
    }
    public void ChangeVolume(bool isActive)
    {
        if (isActive)
            AudioListener.volume = 1f;
        else
            AudioListener.volume = 0f;
    }
}
