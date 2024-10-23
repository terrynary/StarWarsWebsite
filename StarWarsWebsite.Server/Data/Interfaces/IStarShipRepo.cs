using StarWarsApiCSharp;
using StarWarsWebsite.Server.Models;

namespace StarWarsWebsite.Server.Data.Interfaces
{
    public interface IStarShipRepo
    {
        List<StarShip> GetStarShips();
        StarShip GetStarShip(int starShipId);
        StarShip CreateStarShip(StarShip starShip);
        bool UpdateStarShip(StarShip starShip);
        bool DeleteStarShip(int starShipId);
        StarShip GetLuckyStarShip();
    }
}
