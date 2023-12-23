using UnityEngine;

public class BGMController : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image image;
    private void Start()
    {
        BGMManager bgmManager = FindObjectOfType<BGMManager>();

        if (bgmManager != null)
        {
            bgmManager.StopBGM();
            Destroy(bgmManager.gameObject);
        }
    }

    public void OnClickReturn()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
