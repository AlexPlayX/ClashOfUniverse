using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Ranking gameRank;
    public static string playerName;
    public Sprite selectedShip;
    public int shipType;
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get { return instance; }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameRank = new Ranking();
        instance = this;
    }
    public void SelectShip(int ship)
    {
        shipType = ship;
        switch (ship)
        {
            case 1:
                {
                    Debug.Log("Cruiser");
                    selectedShip = Resources.Load<Sprite>("Ships and Stations/Cruiser 3");
                }; break;
            case 2:
                {
                    Debug.Log("Destroyer");
                    selectedShip = Resources.Load<Sprite>("Ships and Stations/Destroyer 2");
                }; break;
          
        }
    }
    public void SetPlayerName(string name)
    {
        playerName = name;
    }
}
