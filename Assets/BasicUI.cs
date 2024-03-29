using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BasicUI : MonoBehaviour
{
    void OnGUI()
    {
        int posX = 10;
        int posY = 10;
        int width = 100;
        int height = 30;
        int buffer = 10;

        // Display Player 1 Score
        int player1Score = Managers.GetPlayer1Score();
        GUI.Box(new Rect(posX, posY, width, height), $"Player 1 Score: {player1Score}");
        posY += height + buffer;

        // Display Player 2 Score
        int player2Score = Managers.GetPlayer2Score();
        GUI.Box(new Rect(posX, posY, width, height), $"Player 2 Score: {player2Score}");
        posY += height + buffer;

        // Display Inventory Items
        List<string> itemList = Managers.Inventory.GetItemList();
        if (itemList.Count == 0)
        {
            GUI.Box(new Rect(posX, posY, width, height), "No Items");
        }
        else
        {
            foreach (string item in itemList)
            {
                int count = Managers.Inventory.GetItemCount(item);
                Texture2D image = Resources.Load<Texture2D>($"Icons/{item}");
                GUI.Box(new Rect(posX, posY, width, height),
                    new GUIContent($"({count})", image));
                posX += width + buffer;
            }
        }
    }
}
