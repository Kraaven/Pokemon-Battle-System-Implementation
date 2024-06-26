using System;

public enum PokemonType
{
    Normal,
    Fire,
    Water,
    Leaf,
    Bug
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