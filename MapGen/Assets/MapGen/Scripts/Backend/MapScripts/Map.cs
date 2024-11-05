using System.Collections.Generic;
using System.Diagnostics;

public class Map
{
    public List<IRoom> roomsList = new List<IRoom>();


    //Dom?lna wartoœæ mapki
    private int width = 1;
    private int height = 1;

    public Map(int width, int height)
    {
        this.width = width;
        this.height = height;
    }


    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    public void SetRoom(IRoom room)
    {
        if (room == null)
        {
            return;
        }

        int x = room.GetPosition();
        int y = room.GetLevel();


        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            roomsList.Add(room);
        }
    }
}