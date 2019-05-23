using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.DALC;

namespace OnBreakLibrary
{
    public class ClienteCollection
    {
        private onbreakEntities db = new onbreakEntities();

        private List<Cliente> _clientes = new List<Cliente>();

        public List<Cliente> Clientes
        {
            get
            {
                return _clientes;
            }

            set
            {
                _clientes = value;
            }
        }

        public bool AgregarCliente(Cliente cliente)
        {
            if (BuscarClientePorRut(cliente.Rut) != null)
            {
                return false;
            }

            this.Clientes.Add(cliente);
            return true;
        }

        public Cliente BuscarClientePorRut(string rut)
        {
            try
            {
                return (from c in this.db.Cliente
                        where c.Rut == rut
                        select new Cliente()
                        {
                            Rut = c.Rut,
                            Nombre = c.Nombre,
                            RazonSocial = c.RazonSocial,
                            Correo = c.Correo,
                            Direccion = c.Direccion,
                            Telefono = c.Telefono,
                            ActividadEmpresaId = (int)c.ActividadEmpresaId,
                            TipoEmpresaId = (int)c.TipoEmpresaId
                        }).First();
            }
            catch (Exception)
            {
                return null;
            }
       }

        public bool EliminarCliente(string rut)
        {
            Cliente cliente = BuscarClientePorRut(rut);
            if (cliente == null)
            {
                return false;
            }

            this.Clientes.Remove(cliente);
            return true;
        }

        public int CantidadRegistro()
        {
            int cantidad = (from c in this.Clientes select c).Count();
            return cantidad;
        }

        public int cantidadTipoEmpresa(TipoEmpresa tipoEmpresa)
        {
            int cantidad = (from c in this.Clientes
                            where c.TipoEmpresa == tipoEmpresa
                            select c).Count();

            return cantidad;
        }

        public int cantidadActividadEmpresa(ActividadEmpresa actividadEmpresa)
        {
            int cantidad = (from c in this.Clientes
                            where c.ActividadEmpresa == actividadEmpresa
                            select c).Count();

            return cantidad;
        }

        public List<Cliente> clientePorRut(string rut)
        {
            return (from c in this.Clientes
                    where c.Rut == rut
                    select c).ToList();
        }

        public List<Cliente> clientesPorActividadE(ActividadEmpresa actividad )
        {
            return (from c in this.Clientes
                    where c.ActividadEmpresa == actividad
                    select c).ToList();
        }

        public List<Cliente> clientesPorTipoE(TipoEmpresa tipoE)
        {
            return (from c in this.Clientes
                    where c.TipoEmpresa == tipoE
                    select c).ToList();
        }

        public List<Cliente> ReadAll()
        {
            return (from c in db.Cliente
                    select new Cliente()
                    {
                        Rut = c.Rut,
                        Nombre = c.Nombre,
                        RazonSocial = c.RazonSocial,
                        Correo = c.Correo,
                        Direccion = c.Direccion,
                        Telefono = c.Telefono,
                        ActividadEmpresas = new ActividadEmpresas()
                        {
                            Id = c.ActividadEmpresa.Id,
                            Descripcion = c.ActividadEmpresa.Descripcion
                        }
,
                        ActividadEmpresaId = (int)c.ActividadEmpresaId,
                        TipoEmpresas = new TipoEmpresas()
                        {
                            Id = c.TipoEmpresa.Id,
                            Descripcion = c.TipoEmpresa.Descripcion
                        },
                        TipoEmpresaId = (int)c.TipoEmpresaId
                    }).ToList();
        }

        public bool InsertarCliente(Cliente cliente)
        {
            try
            {
                OnBreak.DALC.Cliente c = new OnBreak.DALC.Cliente();
                c.Rut = cliente.Rut;
                c.Nombre = cliente.Nombre;
                c.RazonSocial = cliente.RazonSocial;
                c.Correo = cliente.Correo;
                c.Direccion = cliente.Direccion;
                c.Telefono = cliente.Telefono;

                c.ActividadEmpresaId = cliente.ActividadEmpresaId;
                c.TipoEmpresaId = cliente.TipoEmpresaId;

                this.db.Cliente.Add(c); 
                this.db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;

            }
        }

        public bool ModificarClientes( Cliente cliente)
        {
            try
            {
                OnBreak.DALC.Cliente c = this.db.Cliente.Find(cliente.Rut);
                c.Nombre = cliente.Nombre;
                c.RazonSocial = cliente.RazonSocial;
                c.Correo = cliente.Correo;
                c.Direccion = cliente.Direccion;
                c.Telefono = cliente.Telefono;
                c.ActividadEmpresaId = cliente.ActividadEmpresaId;
                c.TipoEmpresaId = cliente.TipoEmpresaId;

                this.db.Entry(c).State = System.Data.EntityState.Modified;
                this.db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EliminarClientes(string rut)
        {
            try
            {
                OnBreak.DALC.Cliente c = db.Cliente.Find(rut);

                db.Cliente.Remove(c);
                db.SaveChanges();
                return true; 
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<TipoEmpresas> ListarTipoEmpresa()
        {
            return (from e in db.TipoEmpresa
                    select new TipoEmpresas()
                    {
                        Id = e.Id,
                        Descripcion = e.Descripcion
                    }).ToList();
        }

        public List<ActividadEmpresas> ListarActividadEmpresa()
        {
            return (from e in db.ActividadEmpresa
                    select new ActividadEmpresas()
                    {
                        Id = e.Id,

                        Descripcion = e.Descripcion
                    }).ToList();
        }


    }
}

