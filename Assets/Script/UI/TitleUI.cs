using UnityEngine;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    [SerializeField] private GameObject howToPanel;
    [SerializeField] private GameObject initialPanel;
    [Header("Pages")] [SerializeField] private GameObject[] pages;
    [SerializeField] private Button rightArrow;
    [SerializeField] private Button leftArrow;
    [SerializeField] private Button closeButton;

    // initial UI
    private void Start() {
        howToPanel.SetActive(false);
        initialPanel.SetActive(true);
        for (var i = 0; i < pages.Length; i++) pages[i].SetActive(false);
    }

    // Close initail UI, open how to play UI
    public void ClickHowTo()
    {
        initialPanel.SetActive(false);
        howToPanel.SetActive(true);
        pages[0].SetActive(true);
        rightArrow.interactable = true;
        leftArrow.interactable = false;
    }

    // Open next page
    public void ClickRightArrow()
    {
        for (var i = 0; i < pages.Length; i++)
        {
            if (pages[i].activeSelf)
            {
                pages[i].SetActive(false);
                pages[i + 1].SetActive(true);
                leftArrow.interactable = true;
                if (i + 1 == pages.Length - 1) rightArrow.interactable = false;
                break;
            }
        }
    }

    // Open previous page
    public void ClickLeftArrow()
    {
        for (var i = 0; i < pages.Length; i++)
        {
            if (pages[i].activeSelf)
            {
                pages[i].SetActive(false);
                pages[i - 1].SetActive(true);
                rightArrow.interactable = true;
                if (i - 1 == 0) leftArrow.interactable = false;
                break;
            }
        }
    }

    // close how to play UI, open initial UI
    public void ClickClose()
    {
        rightArrow.interactable = true;
        leftArrow.interactable = false;
        initialPanel.SetActive(true);
        howToPanel.SetActive(false);
    }

    public void OnClickPlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void OnClickExit()
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