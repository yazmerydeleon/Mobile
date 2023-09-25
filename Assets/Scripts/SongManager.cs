using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SongData
{
    public string songName;
    public float[] tempoChangeTimes;
    public float[] spawnRatesForTempos;
}

[System.Serializable]
public class LevelData
{
    public SongData easyModeSong;
    public SongData hardModeSong;
}

[System.Serializable]
public class LevelsCollection
{
    public List<LevelData> levels;
}

public class SongManager : MonoBehaviour
{
    private LevelsCollection loadedLevels;

    // Public read-only property to access loadedLevels from outside
    public LevelsCollection LoadedLevels
    {
        get { return loadedLevels; }
    }

    private void Start()
    {
        loadedLevels = LoadLevelsFromJSON();

        // Just an example of accessing the data
        string firstEasySongName = loadedLevels.levels[0].easyModeSong.songName;
        Debug.Log("First Level Easy Mode Song Name: " + firstEasySongName);

        string firstHardSongName = loadedLevels.levels[0].hardModeSong.songName;
        Debug.Log("First Level Hard Mode Song Name: " + firstHardSongName);
    }

    public LevelsCollection LoadLevelsFromJSON()
    {
        TextAsset jsonTextFile = Resources.Load<TextAsset>("LevelSongsData"); // filename
        LevelsCollection levelsCollection = JsonUtility.FromJson<LevelsCollection>(jsonTextFile.text);
        return levelsCollection;
    }

    public SongData GetCurrentSongData(bool isEasyMode, int levelIndex)
    {
        // Fetching the song data based on the mode and level
        if (isEasyMode)
            return loadedLevels.levels[levelIndex].easyModeSong;
        else
            return loadedLevels.levels[levelIndex].hardModeSong;
    }
}
