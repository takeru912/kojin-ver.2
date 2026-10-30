using UnityEngine;
using System.Collections.Generic;

public class MiniGameManager : MonoBehaviour
{
    private int[] roomMiniGames = new int[16];


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetMiniGames();
    }

    //16種類のミニゲームをランダムに配置
    private void SetMiniGames()
    {
        List<int> miniGames = new List<int>();

        // ミニゲームIDを1～16まで登録
        for (int i = 1;i<=16;i++)
        {
            miniGames.Add(i);
        }

        // シャッフル
        for (int i=miniGames.Count - 1;i>0;i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            int temp = miniGames[i];
            miniGames[i] = miniGames[randomIndex];
            miniGames[randomIndex] = temp;
        }

        // 各部屋に割り当て
        for (int i=0; i<16; i++)
        {
            roomMiniGames[i] = miniGames[i];

            Debug.Log(
                "部屋" + (i + 1) +
                "→　ミニゲーム" + roomMiniGames[i]
                );
        }
    }

    // 指定した部屋のミニゲームIDを取得
    public int GetMiniGameID(int roomNumber)
    {
        if (roomNumber < 1 || roomNumber > 16)
        {
            Debug.LogError("存在しない部屋番号です");
            return -1;
        }

        return roomMiniGames[roomNumber - 1];
    }
}