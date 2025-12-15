using UnityEngine;
using UnityEngine.SceneManagement;
public class Replay : MonoBehaviour
{
    public void ReplayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
