using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Rigel.Web
{
    public class NHibernateHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            try
            {
                context.BeginRequest += ApplicationBeginRequest;
                context.EndRequest += ApplicationEndRequest;
            }
            catch (Exception ex)
            {
                //Log.For<NHibernateHttpModule>().Error("Exception in Init", ex);
            }
        }

        public void ApplicationBeginRequest(object sender, EventArgs e)
        {
            //try
            //{
            //    var sessionFactory = IoC.GetInstance<ISessionFactory>();
            //    var session = sessionFactory.OpenSession();

            //    CurrentSessionContext.Bind(session);
            //}
            //catch (Exception ex)
            //{
            //    Log.For<NHibernateHttpModule>().Error("Exception in ApplicationBeginRequest", ex);
            //}
        }

        public void ApplicationEndRequest(object sender, EventArgs e)
        {
            //try
            //{
            //    var sessionFactory = IoC.GetInstance<ISessionFactory>();
            //    ISession currentSession = CurrentSessionContext.Unbind(sessionFactory);

            //    if (currentSession != null)
            //    {
            //        if (currentSession.IsOpen)
            //        {
            //            currentSession.Flush();
            //            currentSession.Close();
            //        }

            //        currentSession.Dispose();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Log.For<NHibernateHttpModule>().Error("Exception in ApplicationEndRequest", ex);
            //}
        }

        public void Dispose()
        {
            // do nothing
        }
    }
}