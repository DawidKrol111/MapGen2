using System.Collections.Generic;
using UnityEngine;

public static class RandomRoomPicker
{
    private static List<IRoom> roomList; 

    static RandomRoomPicker()
    {
        roomList = new List<IRoom>
        {
            new BattleRoom(),
            new EmptyRoom()
        };
    }

    public static IRoom GetRandomRoom()
    {
        if (roomList.Count == 0)
        {
            return null;
        }

        int randomIndex = Random.Range(0, roomList.Count);

        IRoom newRoom = null;
        if (roomList[randomIndex] is BattleRoom)
        {
            newRoom = new BattleRoom();
        }
        else if (roomList[randomIndex] is EmptyRoom)
        {
            newRoom = new EmptyRoom();
        }

        return newRoom;
    }
}
