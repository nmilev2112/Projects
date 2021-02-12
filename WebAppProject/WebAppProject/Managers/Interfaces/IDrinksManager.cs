using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppProject.Data.DTO;

namespace WebAppProject.Managers.Interfaces
{
    public interface IDrinksManager
    {
        Drink GetByName(string name);
        List<Drink> GetAll();
    }
}
