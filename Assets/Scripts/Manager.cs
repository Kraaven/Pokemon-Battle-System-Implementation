using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Manager : MonoBehaviour
{
    public static string Path;
    public static bool ContextMenu;
    public static GameObject PokeDetails;
    public static GameObject Focus;

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
        PokeDetails = GameObject.Find("Stats");
        Focus = GameObject.Find("Focus");
        
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
            PokeData data = new PokeData();
            try
            {
                Logger.LogEvent($"Trying to load data from File: {System.IO.Path.GetFileName(loadedFile)}");

                data = JsonConvert.DeserializeObject<PokeData>(File.ReadAllText(loadedFile));
            }
            catch (Exception e)
            {
                Logger.LogEvent($"Failed to load Pokemon data from File: {System.IO.Path.GetFileName(loadedFile)}\n\tMaybe some of your values are invalid?");
            }

            if (data != null)
            {
                try
                {
                    var P = Instantiate(PokemonPrefab, transform.position, transform.rotation, Grid);
                    P.CreatePokemon(data);
                }
                catch (Exception e)
                {
                    Logger.LogEvent($"Failed to Validate Pokemon Data");
                    throw;
                } 
            }
            
        }
        
        Logger.CloseLogger();

        var randomPoke = Random.Range(0, Pokedex.Count);
        Debug.Log($"Displaying pokemon {randomPoke} of name: {Pokedex[randomPoke].PokemonData.Name}");
        FocusPokemon(Pokedex[randomPoke]);
        
        
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
        if (Input.GetKeyDown(KeyCode.P))
        {
            var randomPoke = Random.Range(0, Pokedex.Count);
            Debug.Log($"Displaying pokemon {randomPoke} of name: {Pokedex[randomPoke].PokemonData.Name}");
            FocusPokemon(Pokedex[randomPoke]);
        }
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

    public static void LoseFocus()
    {
        Focus.SetActive(false);
    }

    public static void FocusPokemon(Pokemon pokemon)
    {
        Focus.SetActive(true);
        PokeDetails.GetComponent<UI_ValueAllocator>().ViewPokemon(pokemon);
        
        
    }



}
