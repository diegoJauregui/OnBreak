using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class Cliente
    {
        private string _rut;
        private string _razonSocial;
        private string _nombre;
        private string _correo;
        private string _direccion;
        private string _telefono;
        private ActividadEmpresa _actividadEmpresa;
        private TipoEmpresa _tipoEmpresa;

        private int _tipoEmpresaId;
        private int _actividadEmpresaId;
        private ActividadEmpresas _actividadEmpresas;
        private TipoEmpresas _tipoEmpresas;

        public Cliente()
        {

        }

        public Cliente(string rut, string razonSocial, string nombre, string correo, string direccion, string telefono, ActividadEmpresa actividadEmpresa, TipoEmpresa tipoEmpresa,
            ActividadEmpresas actividadEmpresas, TipoEmpresas tipoEmpresas)
        {
            this.Rut = rut;
            this.RazonSocial = razonSocial;
            this.Nombre = nombre;
            this.Correo = correo;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.ActividadEmpresa = actividadEmpresa;
            this.TipoEmpresa = tipoEmpresa;
            this.ActividadEmpresas = actividadEmpresas;
            this.TipoEmpresas = tipoEmpresas;
        }

        public string Rut
        {
            get
            {
                return _rut;
            }

            set
            {
                _rut = value;
            }
        }

        public string RazonSocial
        {
            get
            {
                return _razonSocial;
            }

            set
            {
                _razonSocial = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public string Correo
        {
            get
            {
                return _correo;
            }

            set
            {
                _correo = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }

            set
            {
                _direccion = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _telefono;
            }

            set
            {
                _telefono = value;
            }
        }

        public ActividadEmpresa ActividadEmpresa
        {
            get
            {
                return _actividadEmpresa;
            }

            set
            {
                _actividadEmpresa = value;
            }
        }

        public TipoEmpresa TipoEmpresa
        {
            get
            {
                return _tipoEmpresa;
            }

            set
            {
                _tipoEmpresa = value;
            }
        }

        public int TipoEmpresaId
        {
            get
            {
                return _tipoEmpresaId;
            }

            set
            {
                _tipoEmpresaId = value;
            }
        }

        public int ActividadEmpresaId
        {
            get
            {
                return _actividadEmpresaId;
            }

            set
            {
                _actividadEmpresaId = value;
            }
        }

        public ActividadEmpresas ActividadEmpresas
        {
            get
            {
                return _actividadEmpresas;
            }

            set
            {
                _actividadEmpresas = value;
            }
        }

        public TipoEmpresas TipoEmpresas
        {
            get
            {
                return _tipoEmpresas;
            }

            set
            {
                _tipoEmpresas = value;
            }
        }
    }
}
