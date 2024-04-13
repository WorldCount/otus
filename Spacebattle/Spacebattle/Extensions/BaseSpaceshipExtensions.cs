using Spacebattle.Interfaces;

namespace Spacebattle.Extensions;

public static class BaseSpaceshipExtensions
{
    public static IEnumerable<IBaseSpaceship> GetByPlayerId(this IEnumerable<IBaseSpaceship> spaceships, int playerId)
    {
        return spaceships.Where(s => s.PlayerId == playerId);
    }
    
    public static IBaseSpaceship? GetById(this IEnumerable<IBaseSpaceship> spaceships, int spaceshipId)
    {
        return spaceships.FirstOrDefault(s => s.Id == spaceshipId);
    }

    public static IEnumerable<IBaseSpaceship> GetMoving(this IEnumerable<IBaseSpaceship> spaceships)
    {
        return spaceships.Where(s => s.isMoving);
    }
}