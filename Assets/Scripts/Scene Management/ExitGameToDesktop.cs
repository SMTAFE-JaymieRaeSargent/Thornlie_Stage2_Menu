using UnityEngine;

public class ExitGameToDesktop : MonoBehaviour
{
    public void Exit()
    {
        Invoke("Quit",0.25f);
    }
    private void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif 
    }
}