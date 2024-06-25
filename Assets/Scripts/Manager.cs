using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using Newtonsoft.Json;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static string Path;

    //public string loadPokemon;

    public Pokemon PokemonPrefab;

    public List<Pokemon> Pokedex;

    public int upperbound;

    public int lowerbound;
    // Start is called before the first frame update
    void Start()
    {
        Path = Application.streamingAssetsPath + "/Textures/";
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
                var P = Instantiate(PokemonPrefab,transform.position,transform.rotation,transform);
                P.CreatePokemon(JsonConvert.DeserializeObject<PokeData>(File.ReadAllText(loadedFile)));
                Pokedex.Add(P);
            }
            catch (Exception e)
            {
                Logger.LogEvent($"Failed to load Pokemon data from File: {System.IO.Path.GetFileName(loadedFile)}\n\tMaybe some of your values are invalid?");
            } 
        }
        
        Logger.CloseLogger();
        
        PlaceObjectsInGrid(Pokedex);
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
        Vector3 scrollDelta = Input.mouseScrollDelta;
        Vector3 newPosition = transform.position + scrollDelta;
        
        // Ensure the new position is within the bounds
        if (newPosition.y > upperbound)
        {
            newPosition.y = upperbound;
        }
        else if (newPosition.y < lowerbound)
        {
            newPosition.y = lowerbound;
        }

        transform.position = newPosition;
    }
    
    void PlaceObjectsInGrid(List<Pokemon> objects)
    {
        int numberOfColumns = 10; // Columns from -9 to +9 with a spacing of 2 units
        float columnSpacing = 2.0f;
        float rowSpacing = -2.0f;
        float startY = 3.5f; // Starting row at 3.5

        for (int i = 0; i < objects.Count; i++)
        {
            int row = i / numberOfColumns;
            int column = i % numberOfColumns;

            float x = -9 + (column * columnSpacing);
            float y = startY + (row * rowSpacing);

            Vector3 position = new Vector3(x, y, 0);
            objects[i].transform.position = position;
        }
        
        int numberOfRows = Mathf.CeilToInt(objects.Count / 10.0f);
        // upperbound = (int)startY;
        // lowerbound = (int)(startY + (numberOfRows - 1) * rowSpacing);

        upperbound = numberOfRows - 1;
        lowerbound = -numberOfRows + 1;
    }
}
