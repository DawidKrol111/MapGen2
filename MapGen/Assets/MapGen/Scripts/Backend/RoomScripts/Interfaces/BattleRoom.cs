using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRoom : IRoom
{
    private int level = 0;
    private int position = 0;
    List<IRoom> connectedRooms = new List<IRoom>();


    public void AddConnection(IRoom room) { connectedRooms.Add(room); }

    public List<IRoom> GetConnectedRooms()
    {
        if (connectedRooms.Count == 0) { return null; }
        return connectedRooms;
    }
    public void SetLevel(int level) { this.level = level; }
    public void SetPosition(int position) { this.position = position; }
    public int GetLevel() { return level; }
    public int GetPosition() { return position; }


    public IRoom Type()
    {
        return this;
    }
    public string Action()
    {
        return "ROZPOCZ?CIE BITKI";
    }

    public string Encounter()
    {
        return "POTWORKI ATAKUJO";
    }

    public string Reward()
    {
        return "WYGRYWASZ SZMAL";
    }

   
}
