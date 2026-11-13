using UnityEngine;
using UnityEngine.UI;

public class FullScreenModeManager : MonoBehaviour
{
    public int fullScreenMode = 0;
    [SerializeField] Toggle _fullScreen, _borderless, _windowed;

    public void SetScreenMode(int selectedToggleMode)
    {
        fullScreenMode = selectedToggleMode;
        switch (selectedToggleMode)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            case 2:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
            default:
                fullScreenMode = 0;
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;
        }
    }
    private void Start()
    {
        switch (fullScreenMode)
        {
            case 0:
                _fullScreen.isOn = true;
                break;
            case 1:
                _windowed.isOn = true;
                break;
            case 2:
                _borderless.isOn = true;

                break;
            default:
                _fullScreen.isOn = true;
                break;
        }
        SetScreenMode(fullScreenMode);
    }

}
