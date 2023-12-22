using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private static BGMManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void StopBGM()
    {
        GetComponent<AudioSource>().Stop();
    }
}
