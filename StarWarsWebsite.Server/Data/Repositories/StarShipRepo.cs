using Microsoft.EntityFrameworkCore;
using StarWarsWebsite.Server.Context;
using StarWarsWebsite.Server.Data.Interfaces;
using StarWarsWebsite.Server.Models;

namespace StarWarsWebsite.Server.Data.Repositories
{
    public class StarShipRepo(StarWarsContext context) : IStarShipRepo
    {
        private readonly StarWarsContext _context = context;

        public List<StarShip> GetStarShips() 
        {
            try
            {
                var result = _context.StarShips.ToList();
                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return new List<StarShip>();
            }
        }

        public StarShip GetStarShip(int starShipId) 
        {
            try
            {
                StarShip result = _context.StarShips.Where(s => s.Id == starShipId).FirstOrDefault() ?? throw new Exception("Couldn't Find Star Ship");
                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return new StarShip();
            }
        }

        public StarShip CreateStarShip(StarShip starShip)
        {
            try
            {
                _context.StarShips.Add(starShip);
                _context.SaveChanges();
                var result = GetStarShip(starShip.Id);
                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return new StarShip();
            }
        }

        public bool UpdateStarShip(StarShip starShip)
        {
            try
            {
                _context.StarShips.Where(s => s.Id == starShip.Id).ExecuteUpdate(setters => setters
                    .SetProperty(b => b.Starship_Class, starShip.Starship_Class)
                    .SetProperty(b => b.MGLT, starShip.MGLT)
                    .SetProperty(b => b.Manufacturer, starShip.Manufacturer)
                    .SetProperty(b => b.Cargo_Capacity, starShip.Cargo_Capacity)
                    .SetProperty(b => b.Hyperdrive_Rating, starShip.Hyperdrive_Rating)
                    .SetProperty(b => b.Length, starShip.Length)
                    .SetProperty(b => b.Cost_In_Credits, starShip.Cost_In_Credits)
                    .SetProperty(b => b.Consumables, starShip.Consumables)
                    .SetProperty(b => b.Max_Atmosphering_Speed, starShip.Max_Atmosphering_Speed)
                    .SetProperty(b => b.Model, starShip.Model)
                    .SetProperty(b => b.Name, starShip.Name)
                    .SetProperty(b => b.Crew, starShip.Crew)
                    .SetProperty(b => b.Passengers, starShip.Passengers)
                    .SetProperty(b => b.Films, starShip.Films)
                    .SetProperty(b => b.Pilots, starShip.Pilots));
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool DeleteStarShip(int starShipId) 
        {
            try
            {
                _context.StarShips.Where(s => s.Id == starShipId).ExecuteDelete();
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public StarShip GetLuckyStarShip()
        {
            try
            {
                var random = new Random();
                var starShipList = GetStarShips();
                return starShipList[random.Next(1, starShipList.Count)];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new StarShip();
            }
        }
    }
}
