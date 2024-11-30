using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugActions : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            AddScore();
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            ReloadScene();
        }
        else if (Input.GetKeyUp(KeyCode.H))
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                AddHealth();
            }
            else {
                AddHealth(-1);
            }
        }
    }

    /// <summary>
    ///     Reload the current scene. Useful for testing new maze generation
    /// </summary>
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    ///     Add an arbitrary amount of points to the game
    /// </summary>
    /// <param name="amount">(integer) number of points to add. Defaults to 10.</param>
    public void AddScore(int amount = 10)
    {
        GameManager.Instance.AddScore(amount);
    }

    /// <summary>
    ///     Increase/decrease the health of the player.
    /// </summary>
    /// <param name="amount">The amount of health to add. Supports negative values.</param>
    public void AddHealth(int amount = 3)
    {
        GameManager.Instance.DecreaseHealth(-amount);
    }
}
