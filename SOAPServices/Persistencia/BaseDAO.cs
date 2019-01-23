using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAPServices.Persistencia
{
    public class BaseDAO<Entidad, Id, IdDes>
    {
        /************************************************/
        public Entidad Crear(Entidad entidad)
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                sesion.Save(entidad);
                sesion.Flush();
            }
            return entidad;
        }
        public void Eliminar(Entidad entidad)
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                sesion.Delete(entidad);
                sesion.Flush();
            }
        }


        //public ICollection<Entidad> ObtenerPregunta(IdDes coddescripcion)
        public Entidad ObtenerPregunta(IdDes coddescripcion)
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                return sesion.Get<Entidad>(coddescripcion);

                //ICriteria obtpre = sesion.CreateCriteria(typeof(Entidad));
                //return obtpre.List<Entidad>();

                //var x = sesion.CreateCriteria<Entidad>().Add(Expression.Like("coddescripcion", "A01")).List<Entidad>();
                //var x = sesion.CreateCriteria<Entidad>().Add(Expression.Like("coddescripcion", "A01")).List<Entidad>();

                //var x = sesion.CreateQuery("select coddescripcion from creditos where coddescripcion='"+ coddescripcion + "'").UniqueResult();   //SetParameter("pid", coddescripcion).UniqueResult();
                //return sesion.Get<Entidad>(x);
                //return x;
            }
        }

        public ICollection<Entidad> ListarTodos()
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                ICriteria busqueda = sesion.CreateCriteria(typeof(Entidad));
                return busqueda.List<Entidad>();
            }
        }
        /************************************************/
    }
}