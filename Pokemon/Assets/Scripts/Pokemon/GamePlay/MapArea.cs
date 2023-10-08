using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapArea : MonoBehaviour
{
    [SerializeField] List<Pokemon> wildpokemons;

    public Pokemon GetRandomWildPokemon()
    {
        var wildPokemon = wildpokemons[Random.Range(0, wildpokemons.Count)];
        wildPokemon.Init();
        return wildPokemon;
    }
}
