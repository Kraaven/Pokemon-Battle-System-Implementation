using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class UI_ValueAllocator : MonoBehaviour
{
    private PokeData SampleData;
    private VisualElement root;
    // Start is called before the first frame update
    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        
        Invoke("ViewPokemon",2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ViewPokemon()
    {
        SampleData = FindObjectOfType<Manager>().Pokedex[0].PokemonData;
        root.Q<Label>("pokemon-name").text = SampleData.Name;
        root.Q<Label>("pokemon-number").text = SampleData.Region;

        root.Q<Label>("type1").text = SampleData.Type.ToString();
        root.Q<Label>("type1").style.backgroundColor = SampleData.Type.GetColor();
        root.Q<Label>("hp").text = SampleData.Health.ToString();
        root.Q<Label>("defense").text = SampleData.Defense.ToString();
        root.Q<Label>("attack").text = SampleData.Attack.ToString();
        root.Q<Label>("sp-atk").text = SampleData.SpecialAttack.ToString();
        root.Q<Label>("sp-def").text = SampleData.SpecialDefense.ToString();
        root.Q<Label>("speed").text = SampleData.Speed.ToString();

        for (int i = 0; i < SampleData.PokemonMoves.Count; i++)
        {
            root.Q<Label>($"move{i+1}").text = SampleData.PokemonMoves[i].MoveName;
            root.Q<Label>($"move{i + 1}").style.backgroundColor = SampleData.PokemonMoves[i].MoveType.GetColor();
            AdjustFontSize(root.Q<Label>($"move{i + 1}"));
        }

        root.Q<Image>("pokemon-image").sprite = FindObjectOfType<Manager>().Pokedex[0].transform.GetChild(0).gameObject
            .GetComponent<UnityEngine.UI.Image>().sprite;
        root.Q<Image>("pokemon-image").scaleMode = ScaleMode.ScaleToFit;
    }
    
    private void AdjustFontSize(Label label)
    {
        float fontSize = 14;
        label.style.fontSize = fontSize;

        while (fontSize > 1)
        {
            var textSize = label.MeasureTextSize(
                label.text, 
                label.contentContainer.layout.width, 
                VisualElement.MeasureMode.AtMost, 
                label.contentContainer.layout.height, 
                VisualElement.MeasureMode.Undefined);

            if (textSize.x < label.layout.width)
                break;

            fontSize--;
            label.style.fontSize = fontSize;
        }
        
    }

}

[Serializable]
public struct data
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
