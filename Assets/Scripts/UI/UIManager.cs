using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject instructionsPanel;

    /// <summary>
    /// 結束遊戲
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// 切換場景
    /// </summary>
    private void LoadTargetScene(string targetSceneName)
    {
        SceneManager.LoadSceneAsync(targetSceneName);
    }

    public void LoadMainMenu()
    {
        LoadTargetScene("MainMenu");
    }

    public void LoadLevel1()
    {
        LoadTargetScene("Level1");
    }

    public void LoadLevel2()
    {
        LoadTargetScene("Level2");
    }

    public void LoadLevel3()
    {
        LoadTargetScene("Level3");
    }

    public void LoadLevel4()
    {
        LoadTargetScene("Level4");
    }

    public void ShowInstructionsPanel()
    {
        instructionsPanel.SetActive(true);
        print("test");
    }

    void Update()
    {
        if (instructionsPanel.activeSelf && Input.GetKey(KeyCode.Escape))
        {
            instructionsPanel.SetActive(false);
        }
    }
}


