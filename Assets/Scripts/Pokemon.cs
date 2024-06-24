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

        var pokeImage = Manager.LoadTexture(data.TextureName);

        if (pokeImage == null)
        {
            Debug.Log("Image does not exist, Aborting Pokemon Creation");
            Destroy(gameObject);
            return;
        }

        PokeSpriteRenderer.sprite = pokeImage;
        transform.localScale = Vector3.one * 10;

    }
    
    
}
