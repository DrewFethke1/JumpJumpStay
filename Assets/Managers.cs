using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(InventoryManager))]
public class Managers : MonoBehaviour
{
    public static PlayerManager Player { get; private set; }
    public static InventoryManager Inventory { get; private set; }
    private List<IGameManagers> startSequence;
    public static int player1Score = 0;
    public static int player2Score = 0;

    public static int GetPlayer1Score()
    {
        return player1Score;
    }

    public static int GetPlayer2Score()
    {
        return player2Score;
    }
    public static List<string> GetItemList()
    {
        return Inventory.GetItemList();
    }

    void Awake()
    {
        Player = GetComponent<PlayerManager>();
        Inventory = GetComponent<InventoryManager>();
        startSequence = new List<IGameManagers>();
        startSequence.Add(Player);
        startSequence.Add((IGameManagers)Inventory);
        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers()
    {
        foreach (IGameManagers manager in startSequence)
        {
            manager.Startup();
        }
        yield return null;
        int numModules = startSequence.Count;
        int numReady = 0;
        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;
            foreach (IGameManagers manager in startSequence)
            {
                if (manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }
            if (numReady > lastReady)
                Debug.Log($"Progress: {numReady}/{numModules}");
            yield return null;
        }
        Debug.Log("All managers started up");
    }

    public static void IncrementPlayer1Score()
    {
        player1Score++;
        Debug.Log($"PLAYER1: {player1Score}, PLAYER2: {player2Score}");
    }

    public static void IncrementPlayer2Score()
    {
        player2Score++;
        Debug.Log($"PLAYER1: {player1Score}, PLAYER2: {player2Score}");
    }


}
