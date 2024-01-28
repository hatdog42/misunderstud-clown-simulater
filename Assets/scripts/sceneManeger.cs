using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManeger : MonoBehaviour
{
    
        public void LoadSceneByName(string name)
        {
            SceneManager.LoadScene(name);
            return;
        }
    
    
    public void Exit()
    {
        Application.Quit();
    }
}
