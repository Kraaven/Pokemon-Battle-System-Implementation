public enum PokemonType
{
    Fire,
    Water,
    Leaf
}

public enum StatusEffect
{
    None,
    Poison,
    Sleep,
    Paralysis
    
}

public class PokemonMove
{
    public string MoveName;
    public PokemonType MoveType;
    public bool IsSpecial;
    
    public int Damage;
    public int Accuracy;

    public StatusEffect InflictedEffect;
    
}