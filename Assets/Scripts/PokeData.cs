using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeData
{

    public string Name;
    public PokemonType Type;

    public int Health;
    public int Attack;
    public int Defense;
    public int SpecialAttack;
    public int SpecialDefense;
    public int Speed;

    public List<PokemonMove> PokemonMoves;
    public string TextureName;

    public PokeData()
    {
        PokemonMoves = new List<PokemonMove>();

        for (int i = 0; i < 4; i++)
        {
            PokemonMoves.Add(new PokemonMove());    
        }
        
    }
}
