using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
   public class ActividadEmpresas
    {
        private int _id;
        private string _descripcion;

        public ActividadEmpresas()
        {

        }

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                _descripcion = value;
            }
        }
    }
}
