using FBQ.Salud_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBQ.Salud_Domain.Commands
{
    public interface IInsumosRepository
    {
        List<Insumos> GetAll();
        Insumos GetInsumoById(int id);
        void Update(Insumos insumo);
        void Delete(Insumos insumo);
        void Add(Insumos insumo);
    }
}
