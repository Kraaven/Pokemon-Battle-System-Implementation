using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static string Path;
    public static bool ContextMenu;

    //public string loadPokemon;

    public Pokemon PokemonPrefab;
    public Transform Grid;
    public static GameObject Label;

    public List<Pokemon> Pokedex;

    public int upperbound;

    public int lowerbound;
    // Start is called before the first frame update
    void Start()
    {
        ContextMenu = false;
        Path = Application.streamingAssetsPath + "/Textures/";
        Label = GameObject.Find("Label Name");
        Label.SetActive(false);
        string[] LoadedFiles;
        try
        {
            LoadedFiles = Directory.GetFiles(Application.streamingAssetsPath + "/Pokemon/", "*.json");
            Pokedex = new List<Pokemon>();
        }
        catch (Exception e)
        {
            Logger.LogEvent("No Files Found");
            return;
        }

        foreach (var loadedFile in LoadedFiles)
        {
            try
            {
                Logger.LogEvent($"Trying to load data from File: {System.IO.Path.GetFileName(loadedFile)}");

                for (int i = 0; i < 60; i++)
                {

                    var P = Instantiate(PokemonPrefab, transform.position, transform.rotation, Grid);
                    P.CreatePokemon(JsonConvert.DeserializeObject<PokeData>(File.ReadAllText(loadedFile)));
                    if (P != null)
                    {
                        Pokedex.Add(P);
                    }
                }

            }
            catch (Exception e)
            {
                Logger.LogEvent($"Failed to load Pokemon data from File: {System.IO.Path.GetFileName(loadedFile)}\n\tMaybe some of your values are invalid?");
            } 
        }
        
        Logger.CloseLogger();
        
    }

    public static Sprite LoadTexture(string name)
    {
        if (!File.Exists(Path + name))
        {
            return null;
        }
        else
        {
            byte[] fileData = File.ReadAllBytes(Path+name);
            //These numbers are placeholder values,overridden later
            Texture2D texture = new Texture2D(64,64);
            texture.LoadImage(fileData);
            texture.filterMode = FilterMode.Point;

            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void SetLabel(Vector2 position, string name)
    {
        if (!ContextMenu)
        {
            Label.GetComponent<RectTransform>().position = position + new Vector2(0,0.96f);
            Label.transform.GetChild(0).GetComponent<TMP_Text>().text = name;
            Label.SetActive(true);    
        }
        
    }

    public static void CloseLabel()
    {
        Label.SetActive(false);
    }
    
}
