
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [Header("現在の部屋")]
    [SerializeField] private int currentRoom;

    [Header("ミニゲーム管理")]
    [SerializeField] private MiniGameManager miniGameManager;

    public int CurrentRoom => currentRoom;

    private bool isGameClear = false;

    void Start()
    {
        // 中央4部屋からランダムに開始
        int[] startRooms = { 6, 7, 10, 11 };

        currentRoom = startRooms[
            Random.Range(0, startRooms.Length)
        ];

        Debug.Log("開始部屋：" + currentRoom);
        EnterRoom();
    }

    // 上に移動
    public void MoveUp()
    {
        if (!CanMove()) return;
        Move(0, -1);
    }

    // 下に移動
    public void MoveDown()
    {
        if (!CanMove()) return;
        Move(0, 1);
    }

    // 左に移動
    public void MoveLeft()
    {
        if (!CanMove()) return;
        Move(-1, 0);
    }

    // 右に移動
    public void MoveRight()
    {
        if (!CanMove()) return;

        if (currentRoom == 13)
        {
            Debug.Log("脱出成功！");
            return;
        }

        Move(1, 0);
    }

    // 部屋移動処理
    private void Move(int dx, int dy)
    {
        int x = (currentRoom - 1) / 4;
        int y = (currentRoom - 1) % 4;

        // 外枠は反対側にループ
        x = (x + dx + 4) % 4;
        y = (y + dy + 4) % 4;

        currentRoom = x * 4 + y + 1;

        isGameClear = false;
        EnterRoom();


        Debug.Log("現在の部屋：" + currentRoom);
    }

    private bool CanMove()
    {
        if(!isGameClear)
        {
            Debug.Log("ミニゲームをクリアしてください");
            return false;
        }

        return true;
    }

    public void DebugGameClear()
    {
        isGameClear = true;
        Debug.Log("ミニゲームクリア！移動可能");
    }

    private void EnterRoom()
    {
        if (miniGameManager == null)
        {
            Debug.LogError("MiniGameManagerが設定されていません");
            return;
        }

        int miniGameID = miniGameManager.GetMiniGameID(currentRoom);

        Debug.Log("部屋" + currentRoom + "に入室");
        Debug.Log("ミニゲームID：" + miniGameID);
    }
}
