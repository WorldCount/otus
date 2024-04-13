using Spacebattle.Extensions;
using Spacebattle.Models;

namespace SpacebattleTests;

public class ShipmentTests
{
    [Fact]
    public void GetByPlayerId()
    {
        var player1 = new Player("Boris Zharkov") { Id = 1 };
        var player2 = new Player("Any Player") { Id = 2 };

        var shipments = new SpaceShipment[]
        {
            new SpaceShipment("Ship Under Repair") { Id = 1, PlayerId = player1.Id.Value, isMoving = false },
            new SpaceShipment("Ship Started") { Id = 2, PlayerId = player2.Id.Value, isMoving = true },
            new SpaceShipment("Ship Movie") { Id = 3, PlayerId = player1.Id.Value, isMoving = true },
        };
        
        Assert.True(shipments.GetByPlayerId(player1.Id.Value).Count() == 2);
        Assert.True(shipments.GetByPlayerId(player2.Id.Value).Count() == 1);
    }

    [Fact]
    public void GetById()
    {
        var player1 = new Player("Boris Zharkov") { Id = 1 };
        var player2 = new Player("Any Player") { Id = 2 };
        
        var shipments = new SpaceShipment[]
        {
            new SpaceShipment("Ship Under Repair") { Id = 1, PlayerId = player1.Id.Value, isMoving = false },
            new SpaceShipment("Ship Started") { Id = 2, PlayerId = player2.Id.Value, isMoving = true },
            new SpaceShipment("Ship Movie") { Id = 3, PlayerId = player1.Id.Value, isMoving = true },
        };
        
        Assert.True(shipments.GetById(2)?.ShipmentName == "Ship Started");
        Assert.Null(shipments.GetById(4));
    }

    [Fact]
    public void GetMoving()
    {
        var player1 = new Player("Boris Zharkov") { Id = 1 };
        var player2 = new Player("Any Player") { Id = 2 };
        
        var shipments = new SpaceShipment[]
        {
            new SpaceShipment("Ship Under Repair") { Id = 1, PlayerId = player1.Id.Value, isMoving = false },
            new SpaceShipment("Ship Started") { Id = 2, PlayerId = player2.Id.Value, isMoving = true },
            new SpaceShipment("Ship Movie") { Id = 3, PlayerId = player1.Id.Value, isMoving = true },
        };
        
        Assert.True(shipments.GetMoving().Count() == 2);
    }
}