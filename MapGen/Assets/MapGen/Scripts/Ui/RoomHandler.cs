using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    private IRoom room;

    public void SetRoom(IRoom room)
    {
        this.room = room;
    }

    public IRoom GetRoom()
    {
        return room;
    }

    private void OnMouseDown()
    {
        if (room != null)
        {
            Debug.Log(room.Encounter());
            Debug.Log(room.Action());
        }
    }
}
