using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Team", menuName = "ScriptableObjects/Teams", order = 1)]
public class Team : ScriptableObject
{
    [SerializeField] public TeamNamesEnum TeamName;
    [SerializeField] public int Seed;
    [SerializeField] public NationalityEnum Nationality;
    [SerializeField] public Sprite Logo;
    [SerializeField] public TeamStats TeamStats;
 

}


[System.Serializable]
public class TeamStats
{
    public int Attacking;
    public int Stamina;
    public int Defence;
    public int PlayMaking;
}




public enum NationalityEnum
{
    Germany,
    France,
    Italy,
    Spain,
    England,
    Sweden,
    Turkey,
    Ukrain,
    Belgium,
    Netherland,
    Portugal,
    Austria,
    Moldova,
    Switzerland,
    Russia
}