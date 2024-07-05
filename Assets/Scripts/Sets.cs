using System;
using UnityEngine;

public enum PokemonType
{
    Normal,
    Fire,
    Water,
    Grass,
    Electric,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon
}

public static class PokemonTypeExtensions
{
    public static Color GetColor(this PokemonType type)
    {
        return type switch
        {
            PokemonType.Normal => new Color(0.658f, 0.658f, 0.458f),
            PokemonType.Fire => new Color(0.953f, 0.510f, 0.192f),
            PokemonType.Water => new Color(0.386f, 0.576f, 0.925f),
            PokemonType.Grass => new Color(0.478f, 0.804f, 0.318f),
            PokemonType.Electric => new Color(0.969f, 0.816f, 0.188f),
            PokemonType.Ice => new Color(0.591f, 0.855f, 0.840f),
            PokemonType.Fighting => new Color(0.753f, 0.180f, 0.157f),
            PokemonType.Poison => new Color(0.639f, 0.247f, 0.639f),
            PokemonType.Ground => new Color(0.871f, 0.745f, 0.408f),
            PokemonType.Flying => new Color(0.671f, 0.557f, 0.957f),
            PokemonType.Psychic => new Color(0.976f, 0.329f, 0.529f),
            PokemonType.Bug => new Color(0.651f, 0.725f, 0.102f),
            PokemonType.Rock => new Color(0.714f, 0.627f, 0.220f),
            PokemonType.Ghost => new Color(0.451f, 0.329f, 0.584f),
            PokemonType.Dragon => new Color(0.439f, 0.212f, 0.957f),
            _ => Color.white
        };
    }
}
public enum StatusEffect
{
    None,
    Poison,
    Sleep,
    Paralysis
    
}

[Serializable]
public class PokemonMove
{
    public string MoveName;
    public PokemonType MoveType;
    public bool IsSpecial;
    
    public int Damage;
    public int Accuracy;

    public StatusEffect InflictedEffect;
    
}