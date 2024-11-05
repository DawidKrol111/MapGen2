using System.Collections.Generic;
using UnityEngine;

public class GenerateMap
{

    
    public Map GenerateNewMap(int width, int height)
    {
        var maxLvl = height;
        var map = new Map(width, height);
        int startRoomX = Random.Range(0, width);
        IRoom startRoom = new StartRoom();
        startRoom.SetPosition(startRoomX);
        startRoom.SetLevel(0);
        map.SetRoom(startRoom);


        for (int y = 1; y < height; y++)
        {
            int roomX = Random.Range(0, width);

            IRoom room = RandomRoomPicker.GetRandomRoom();

            room.SetPosition(roomX);
            room.SetLevel(y);
            map.SetRoom(room);

            for (int x = 0; x < width; x++)
            {
                if (x == roomX) continue;

                if (Random.value < 0.75f)
                {
                    map.SetRoom( null);
                }
                else
                {
                    IRoom randomRoom = RandomRoomPicker.GetRandomRoom();
                    randomRoom.SetPosition(x);
                    randomRoom.SetLevel(y);
                    map.SetRoom(randomRoom);
                }
            }
        }
        
        
        for (int x = 0; x < map.roomsList.Count; x++)
        {       
            
            IRoom room = map.roomsList[x];
            if(room.GetLevel() == maxLvl) continue;
            
            room.AddConnection(PickRandomRoomByLevel(map.roomsList,room.GetLevel()+1));
        }
        return map;
    }

   private IRoom PickRandomRoomByLevel(List<IRoom> rooms ,int level)
    {
        List<IRoom> roomsAtLevel = rooms.FindAll(room => room.GetLevel() == level);

        if (roomsAtLevel.Count == 0)
        {
            return null;
        }
        
        int randomIndex = Random.Range(0, roomsAtLevel.Count);
        return roomsAtLevel[randomIndex];
    }
   
}
