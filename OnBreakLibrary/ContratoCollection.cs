using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class ContratoCollection
    {
        private List<Contrato> contrato =
            new List<Contrato>();

        public List<Contrato> Contrato
        {
            get
            {
                return contrato;
            }

            set
            {
                contrato = value;
            }
        }

        public bool AgregarContrato(Contrato contrato)
        {
            Contrato con = BuscarPorContrato(contrato.NumeroContrato);

            if (con == null)
            {

                this.Contrato.Add(contrato);
                return true;
            }

            return false;
        }

        public Contrato BuscarPorContrato(int numeroContrato)
        {
            foreach (var item in Contrato)
            {

                if (item.NumeroContrato == numeroContrato)
                {
                    return item;
                }
            }

            return null;
        }

        public List<Contrato> contratoPorNumero(int numeroContrato)
        {
            return (from a in this.Contrato
                    where a.NumeroContrato == numeroContrato
                    select a).ToList();
        }

        public List<Contrato> TipoContrato(TipoEvento tipoEvento)
        {
            return (from c in this.Contrato
                    where c.Tipo == tipoEvento
                    select c).ToList();
        }

       
        }

    
    }

