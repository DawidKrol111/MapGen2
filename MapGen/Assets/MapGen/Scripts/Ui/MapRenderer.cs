using System.Collections.Generic;
using UnityEngine;

public class MapRenderer : MonoBehaviour
{
    public GameObject roomPrefab;
    public Material lineMaterial;


    private List<GameObject> connectionLines = new List<GameObject>();

    public Map GenerateNewMap(int width, int height)
    {
        var generateMap = new GenerateMap();
        Map map = generateMap.GenerateNewMap(width, height);
        return map;
    }

    private void Start()
    {
        RenderMap(GenerateNewMap(3, 4));
    }

    private void RenderMap(Map map)
    {

        List<IRoom> roomsToRender = map.roomsList;

        for (int i = 0; i < roomsToRender.Count; i++)
        {
            IRoom room = roomsToRender[i];
            GameObject roomObject = Instantiate(roomPrefab,
                new Vector3(room.GetPosition() * 1.3f, 0, room.GetLevel() * 1.4f), Quaternion.identity,
                this.transform);
            var roomHandler = roomObject.GetComponent<RoomHandler>();
            roomHandler.SetRoom(room);
            roomObject.name = room.GetType().Name;

            if (room.GetConnectedRooms().Count > 0 || room.GetConnectedRooms() == null)
            {
                DrawRoomConnections(room, room.GetConnectedRooms()[0]);
            }
        }
    }

    public void ClearMap()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Usuń wszystkie linie
        foreach (GameObject line in connectionLines)
        {
            Destroy(line);
        }

        connectionLines.Clear(); // Wyczyść listę po usunięciu
    }

    public void RegenerateMap()
    {
        ClearMap();
        RenderMap(GenerateNewMap(3, 4));
    }

    private void DrawRoomConnections(IRoom room1, IRoom room2)
    {
        DrawConnectionLine(room1, room2);
    }


    private void DrawConnectionLine(IRoom room1, IRoom room2)
    {
        if (room1 == null || room2 == null)
        {
            return;
        }

        GameObject lineObject = new GameObject("ConnectionLine");
        LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material = lineMaterial;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector3(room1.GetPosition() * 1.3f, 0, room1.GetLevel() * 1.4f));
        lineRenderer.SetPosition(1, new Vector3(room2.GetPosition() * 1.3f, 0, room2.GetLevel() * 1.4f));
        connectionLines.Add(lineObject);
    }
}