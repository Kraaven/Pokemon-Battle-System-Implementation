interface PokemonMove {
    MoveName: string;
    MoveType: PokemonType;
    IsSpecial: boolean;
    Damage: number;
    Accuracy: number;
    InflictedEffect: StatusEffect;
}

enum PokemonType
{
    Normal,
    Fire,
    Water,
    Leaf,
    Bug
}

enum StatusEffect
{
    None,
    Poison,
    Sleep,
    Paralysis
    
}


class Pokemon {
    Name: string;
    Region: string;
    Type: PokemonType;
    Health: number;
    Attack: number;
    Defense: number;
    SpecialAttack: number;
    SpecialDefense: number;
    Speed: number;
    PokemonMoves: PokemonMove[];
    TextureName: string;
}
