using Spacebattle.Interfaces;

namespace Spacebattle.Models;

public class SpaceShipment : IBaseSpaceship
{
    public int? Id { get; set; }
    public string ShipmentName { get; set; }
    public int PlayerId { get; set; }
    public bool isMoving { get; set; }

    public SpaceShipment(string shipmentName)
    {
        ShipmentName = shipmentName;
    }
}