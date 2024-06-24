using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using Newtonsoft.Json;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static string Path;

    public string loadPokemon;

    public Pokemon PokemonPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Path = Application.streamingAssetsPath + "/Textures/";
        
        File.WriteAllText(Application.streamingAssetsPath+"/Pokemon/Template.json", JsonConvert.SerializeObject(new PokeData(),Formatting.Indented));
        
        Instantiate(PokemonPrefab,transform.position,transform.rotation).CreatePokemon(JsonConvert.DeserializeObject<PokeData>(File.ReadAllText(Application.streamingAssetsPath+$"/Pokemon/{loadPokemon}.json")));
        
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
}
