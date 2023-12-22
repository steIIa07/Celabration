using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject howToPanel;
    [SerializeField] private GameObject initialPanel;
    [SerializeField] private GameObject page1;
    [SerializeField] private GameObject page2;
    [SerializeField] private Button rightArrow;
    [SerializeField] private Button leftArrow;
    [SerializeField] private Button closeButton;

    // initial UI
    private void Start() {
        howToPanel.SetActive(false);
        initialPanel.SetActive(true);
        page1.SetActive(true);
        page2.SetActive(false);
        rightArrow.interactable = true;
        leftArrow.interactable = false;
    }

    // Close initail UI, open how to play UI
    public void ClickHowTo()
    {
        initialPanel.SetActive(false);
        howToPanel.SetActive(true);
    }

    // switch between page 1 and page 2
    public void ClickPage1()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        rightArrow.interactable = true;
        leftArrow.interactable = false;
    }

    public void ClickPage2()
    {
        page1.SetActive(false);
        page2.SetActive(true);
        rightArrow.interactable = false;
        leftArrow.interactable = true;
    }

    // close how to play UI, open initial UI
    public void ClickClose()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        rightArrow.interactable = true;
        leftArrow.interactable = false;
        initialPanel.SetActive(true);
        howToPanel.SetActive(false);
    }

    public void OnClickPlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
