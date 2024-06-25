using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Pokemon : MonoBehaviour
{
    private PokeData PokemonData;
    private SpriteRenderer PokeSpriteRenderer;
    
    public void CreatePokemon(PokeData data)
    {
        PokemonData = data;
        PokeSpriteRenderer = GetComponent<SpriteRenderer>();

    
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
        

        PokeSpriteRenderer.sprite = pokeImage;
        transform.localScale = Vector3.one * 10;

    }
    
    
}
