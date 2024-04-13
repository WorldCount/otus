namespace Spacebattle.Interfaces;

public interface IBaseSpaceship
{
    public int? Id { get; set; }
    public string ShipmentName { get; set; }
    public int PlayerId { get; set; }
    
    public bool isMoving { get; set; }
}