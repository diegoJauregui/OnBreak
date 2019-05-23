using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.DALC;

namespace OnBreakLibrary
{
    public class TipoEventoCollection
    {
        private OnBreakEntities db = new OnBreakEntities();

        public List<TipoEventos> ReadAll()
        {
            return (from e in db.TipoEvento
                    select new TipoEventos()
                    {
                        Id = e.IdTipoEvento,
                        Descripcion = e.Descripcion

                    }).ToList();
        }

    }
}
