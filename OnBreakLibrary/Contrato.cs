using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnBreakLibrary
{
    public class Contrato
    {
        private Cliente _cliente;
        private int _numeroContrato;
        private DateTime _creacion;
        private DateTime _termino;
        private DateTime _fechaHoraInicio;
        private DateTime _fechaHoraTermino;
        private string _direccion;
        private Boolean _estaVigente;
        private TipoEvento _tipo;
        private string _observaciones;

        private int _tipoEventoId;
        private TipoEventos _tipoEventos;

        public Contrato(Cliente cliente, int numeroContrato, DateTime creacion, DateTime termino, DateTime fechaHoraInicio, DateTime fechaHoraTermino, string direccion, Boolean estaVigente, TipoEvento tipo, string observaciones)
        {
            this.Cliente = cliente;
            this.NumeroContrato = numeroContrato;
            this.Creacion = creacion;
            this.Termino = termino;
            this.FechaHoraInicio = fechaHoraInicio;
            this.FechaHoraTermino = fechaHoraTermino;
            this.Direccion = direccion;
            this.EstaVigente = estaVigente;
            this.Tipo = tipo;
            this.Observaciones = observaciones;
        }

        public Cliente Cliente
        {
            get
            {
                return _cliente;
            }

            set
            {
                _cliente = value;
            }
        }

        public int NumeroContrato
        {
            get
            {
                return _numeroContrato;
            }

            set
            {
                _numeroContrato = value;
            }
        }

        public DateTime Creacion
        {
            get
            {
                return _creacion;
            }

            set
            {
                _creacion = value;
            }
        }

        public DateTime Termino
        {
            get
            {
                return _termino;
            }

            set
            {
                _termino = value;
            }
        }

        public DateTime FechaHoraInicio
        {
            get
            {
                return _fechaHoraInicio;
            }

            set
            {
                _fechaHoraInicio = value;
            }
        }

        public DateTime FechaHoraTermino
        {
            get
            {
                return _fechaHoraTermino;
            }

            set
            {
                _fechaHoraTermino = value;
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

        public bool EstaVigente
        {
            get
            {
                return _estaVigente;
            }

            set
            {
                _estaVigente = value;
            }
        }

        public TipoEvento Tipo
        {
            get
            {
                return _tipo;
            }

            set
            {
                _tipo = value;
            }
        }

        public string Observaciones
        {
            get
            {
                return _observaciones;
            }

            set
            {
                _observaciones = value;
            }
        }

        public int TipoEventoId
        {
            get
            {
                return _tipoEventoId;
            }

            set
            {
                _tipoEventoId = value;
            }
        }

        public TipoEventos TipoEventos
        {
            get
            {
                return _tipoEventos;
            }

            set
            {
                _tipoEventos = value;
            }
        }

        public Contrato()
        {

        } 
      
    }
}
