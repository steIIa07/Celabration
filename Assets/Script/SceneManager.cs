using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{
    [SerializeField] float waitTime = 1f;
    private static SceneManager instance;

    private void Awake()
{
    if (instance == null)
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    else if (instance != this)
    {
        Destroy(gameObject);
    }
}

    public void LoadScene(int targetSceneIndex)
    {
        StartCoroutine(Load(targetSceneIndex));
    }
    IEnumerator Load(int targetSceneIndex)
    {
        yield return new WaitForSeconds(waitTime);

        UnityEngine.SceneManagement.SceneManager.LoadScene(targetSceneIndex);
    }

}
