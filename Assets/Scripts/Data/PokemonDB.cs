using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonDB : MonoBehaviour
{
    static Dictionary<string, PokemonBase> pokemons;
    
    public static void Init()
    {
        pokemons = new Dictionary<string, PokemonBase>();

        var pokemonArray = Resources.LoadAll<PokemonBase>("");
       foreach (var pokemon in pokemonArray)
        {
            if (pokemons.ContainsKey(pokemon.Name))
            {
                Debug.LogError($"THERE ARE TWO POKEMONS WITH THE NAME {pokemon.Name}");
                continue;
            }
            pokemons[pokemon.Name] = pokemon;
        }
    }
   public static PokemonBase GetPokemonByName(string name)
    {
        if (!pokemons.ContainsKey(name))
        {
            Debug.LogError($"Pokemon with name {name} not found in the database");
            return null;
        }

        return pokemons[name];
    }
}
