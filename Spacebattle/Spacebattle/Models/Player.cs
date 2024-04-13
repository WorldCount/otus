using Spacebattle.Interfaces;

namespace Spacebattle.Models;

public class Player : IPlayer
{
    public int? Id { get; set; }
    
    public string Name { get; set; }
    
    public Player(string name)
    {
        Name = name;
    }
}