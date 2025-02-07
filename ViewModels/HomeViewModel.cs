using PakBus.Models;
using System.Collections.Generic;

namespace PakBus.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Bus> Buses { get; set; }
    }
}