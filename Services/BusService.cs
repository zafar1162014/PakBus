using PakBus.Models;
using System.Collections.Generic;

namespace PakBus.Services
{
  public interface IBusService
  {
    IEnumerable<Bus> GetAllBuses();
    Bus GetBusById(int id);
    void AddBus(Bus bus);
    void UpdateBus(Bus bus);
    void DeleteBus(int id);
  }

  public class BusService : IBusService
  {
    // Replace with your actual data access logic (e.g., Entity Framework Core)
    private readonly YourDbContext _context;

    public BusService(YourDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Bus> GetAllBuses()
    {
      return _context.Buses.ToList();
    }

    public Bus GetBusById(int id)
    {
      return _context.Buses.Find(id);
    }

    public void AddBus(Bus bus)
    {
      _context.Buses.Add(bus);
      _context.SaveChanges();
    }

    public void UpdateBus(Bus bus)
    {
      _context.Buses.Update(bus);
      _context.SaveChanges();
    }

    public void DeleteBus(int id)
    {
      var bus = _context.Buses.Find(id);
      if (bus != null)
      {
        _context.Buses.Remove(bus);
        _context.SaveChanges();
      }
    }
  }
}
