using System.Collections.Generic;
using UnityEngine;

public class RandomCardOrder : MonoBehaviour
{
    public List<string> CardText = new List<string>
    {
        "Mary is born in London.",
        "Mary elopes to Europe with Percy Shelley.",
        "The Villa Diodati ghost story contest inspires Frankenstein.",
        "Mary's half-sister Fanny Imlay dies.",
        "Mary and Percy Shelley marry.",
        "Mary finishes writing Frankenstein.",
        "Frankenstein is published anonymously.",
        "Mary's son William dies.",
        "Percy Shelley drowns in Italy.",
        "The revised edition of Frankenstein is published."
    };

    public List<int> numeros = new List<int>
    {
        0, 1, 2, 3, 4, 5, 6, 7, 8, 9
    };

    private void Awake()
    {
        numeros = MezclarLista(numeros);

        Debug.Log("LISTA ALEATORIA: " + string.Join(", ", numeros));
    }

    List<int> MezclarLista(List<int> lista)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            int temp = lista[i];

            int randomIndex = Random.Range(i, lista.Count);

            lista[i] = lista[randomIndex];
            lista[randomIndex] = temp;
        }

        return lista;
    }
}