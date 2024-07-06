using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pokemon : MonoBehaviour
{
    public PokeData PokemonData;
    
    public void CreatePokemon(PokeData data)
    {
        PokemonData = data;
        


        #region LoadData
        
        if (data.Name == null)
        {
            Logger.LogEvent("Pokemon Name does not exist, Abort Creation");
            Logger.LogEvent("Creation of Pokemon Aborted");
            Destroy(gameObject);
            return;
        }
        else
        {
            Logger.LogEvent($"Creating Pokemon {data.Name}");
        }

        if (data.Health == 0)
        {
            Logger.LogEvent($"Pokemon {data.Name} registered abnormal value '0'");
        }
        if (data.Attack == 0)
        {
            Logger.LogEvent($"Pokemon {data.Name} registered abnormal value '0'");
        }
        if (data.Defense == 0)
        {
            Logger.LogEvent($"Pokemon {data.Name} registered abnormal value '0'");
        }
        if (data.SpecialAttack == 0)
        {
            Logger.LogEvent($"Pokemon {data.Name} registered abnormal value '0'");
        }
        if (data.SpecialDefense == 0)
        {
            Logger.LogEvent($"Pokemon {data.Name} registered abnormal value '0'");
        }
        
        if (data.Speed == 0)
        {
            Logger.LogEvent($"Pokemon {data.Name} registered abnormal value '0'");
        }

        Logger.LogEvent($"Loaded Pokemon {data.Name} Values");
        if (data.PokemonMoves.Count > 4)
        {
            Logger.LogEvent($"Pokemon {data.Name} has more than 4 moves. Trimming from last");
            data.PokemonMoves = data.PokemonMoves.GetRange(0, Math.Min(4, data.PokemonMoves.Count));
        }
        else
        {
            Logger.LogEvent($"Loaded Pokemon {data.Name} Moves : {data.PokemonMoves.Count}");
        }
        
        var pokeImage = Manager.LoadTexture(data.TextureName);
        if (pokeImage == null)
        {
            Logger.LogEvent($"Texture for Pokemon {data.Name} does not exist, Aborting Creation");
            Logger.LogEvent("Creation of Pokemon Aborted");
            Destroy(gameObject);
            return;
        }

        var display = transform.GetChild(0).gameObject;
        display.GetComponent<RectTransform>().localScale *= 0.8f;
        display.GetComponent<Image>().sprite = pokeImage;
        // transform.localScale = Vector3.one * 4;

        #endregion
        
        FindObjectOfType<Manager>().Pokedex.Add(this);



    }

    public void OnHover()
    {
        Manager.SetLabel(GetComponent<RectTransform>().position,PokemonData.Name);
        Debug.Log($"Show {PokemonData.Name}");
    }

    public void OnExit()
    {
        Manager.CloseLabel();
    }

    public void DisplayPokemon()
    {
        Manager.FocusPokemon(this);
    }

}
