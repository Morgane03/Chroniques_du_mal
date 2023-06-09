using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private InkManager _inkManager;
    //private CharacterManager _characterManager;

    [Serializable]
    public class SaveData
    {
        public string InkStoryState;
    }

    private void Start()
    {
        _inkManager = FindObjectOfType<InkManager>();
        //_characterManager = FindObjectOfType<CharacterManager>();
    }

    public void StartGame()
    {
    }

    public void SaveGame()
    {
        SaveData save = CreateSaveGameObject();
        var bf = new BinaryFormatter();

        var savePath = Application.persistentDataPath + "/savedata.save";

        FileStream file = File.Create(savePath); // creates a file at the specified location

        bf.Serialize(file, save); // writes the content of SaveData object into the file

        file.Close();

        Debug.Log("Game saved");

    }

    private SaveData CreateSaveGameObject()
    {
        return new SaveData
        {
            InkStoryState = _inkManager.GetStoryState(),
        };
    }

    public void LoadGame()
    {
        // Here we will load data from a file and make it available to other managers
    }

    public void ExitGame()
    {
    }

}
