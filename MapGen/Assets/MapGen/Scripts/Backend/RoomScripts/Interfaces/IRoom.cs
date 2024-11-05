using System.Collections.Generic;

public interface IRoom
{
    int GetLevel();

    
    void SetLevel(int level);
    void SetPosition(int position);
    int GetPosition();

    void AddConnection(IRoom room);
    List<IRoom> GetConnectedRooms();

    IRoom Type();      
    string Reward();   
    string Action();   
    string Encounter(); 
}