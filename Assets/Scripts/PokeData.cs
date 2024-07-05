using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class PokeData
{

    public string Name;
    public PokemonType Type;
    public string Region;

    public int Health;
    public int Attack;
    public int Defense;
    public int SpecialAttack;
    public int SpecialDefense;
    public int Speed;

    public List<PokemonMove> PokemonMoves;
    public string TextureName;
    
}
