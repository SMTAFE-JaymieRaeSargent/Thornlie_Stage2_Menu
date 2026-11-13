using UnityEngine;
using System.IO;
public class OptionsSaveAndLoad : MonoBehaviour
{
    #region Variables
    //Path to save to
#if UNITY_EDITOR
    string filePath = $"{Application.dataPath}/OptionsData.json"; // Developer Path
#else
    string filePath = $"{Application.persistentDataPath}/OptionsData.json"; // Player Path
#endif

    [SerializeField] OptionsData data = new OptionsData(); // What we are saving and loading (storing)

    //REFERENCE TO ANY OBJECT YOU NEED TO ACCESS FOR SAVING AND LOADING
    [SerializeField] AudioAsset audioData; // (the object we need to get and send info between)
    [SerializeField] FullScreenModeManager screenModeData;
    #endregion
    #region Save
    // Get the Data we need to save from game
    void GetDataToSaveFromGame()
    {
        data.audioVolume = new float[audioData.audioSliderOptions.Length];
        for (int currentAudioIndex = 0; currentAudioIndex < data.audioVolume.Length; currentAudioIndex++)
        {
            data.audioVolume[currentAudioIndex] = audioData.audioSliderOptions[currentAudioIndex].volume;
        }
        data.screenMode = screenModeData.fullScreenMode;
    }
    // Put the Data into Json File 
    void SaveOptionsDataToJson(OptionsData dataToSave, string path)
    {
        string dataFormattedForJsonSave = JsonUtility.ToJson(data);
        File.WriteAllText(path, dataFormattedForJsonSave);
    }
    // Button Friendly Save Fuction that does the above 2 actions
    public void SaveOptions()
    {
        GetDataToSaveFromGame();
        SaveOptionsDataToJson(data, filePath);
    }
    #endregion
    #region Load
    // Get the Data out of Json File 
    OptionsData LoadOptionsDataFromJson()
    {
        string dataFormattedFromJsonLoad = File.ReadAllText(filePath);
        return JsonUtility.FromJson<OptionsData>(dataFormattedFromJsonLoad);
    }
    // Put the Data onto game object
    void SendDataToGameFromLoad()
    {
        for (int currentAudioIndex = 0; currentAudioIndex < data.audioVolume.Length; currentAudioIndex++)
        {
            audioData.audioSliderOptions[currentAudioIndex].volume = data.audioVolume[currentAudioIndex];
        }
        screenModeData.fullScreenMode = data.screenMode;
    }
    // Button Friendly Load Fuction that does the above 2 actions
    public void LoadOptionsData()
    {
        data = LoadOptionsDataFromJson();
        SendDataToGameFromLoad();
    }
    #endregion

    private void Awake()
    {
        if (File.Exists(filePath))
        {
            LoadOptionsData();
        }
    }
}
