using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{
    [SerializeField] float waitTime = 1f;
    private static SceneManager instance;
    public BestScore bestScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            bestScore.bestScore = 0;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
        {
            #if UNITY_WEBGL
            Application.OpenURL("javascript:window.close();");
            #elif UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #elif UNITY_STANDALONE_WIN
                Application.Quit();
            #endif
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
