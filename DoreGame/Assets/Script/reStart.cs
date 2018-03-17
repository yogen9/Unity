using UnityEngine;
using UnityEngine.SceneManagement;



public class reStart : MonoBehaviour {
    public Score getScore;
    public void Update()
    {
        if (getScore.score < (-10))
            Invoke("Restart", 3f);
    }
    public void Restart()
    {      
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
