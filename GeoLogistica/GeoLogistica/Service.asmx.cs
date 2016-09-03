using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace GeoLogistica
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Service : System.Web.Services.WebService
    {
        [WebMethod]
        public Tecnico loginTech(string user, string password)
        {
            try
            {
                BLL bll = new BLL();
                return bll.loginTech(user, password);;
            }
            catch
            {
                return null;
            }
        }

        [WebMethod]
        public bool loginClient(string user, string password)
        {
            try
            {
                BLL bll = new BLL();
                return bll.loginClient(user, password); ;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod]
        public Os[] getOsByDay(string day)
        {
            try
            {
                BLL bll = new BLL();
                Os[] listOs = bll.getOsByDay(day);
                return listOs;
            }
            catch
            {
                return null;
            }
        }

        [WebMethod]
        public Os[] getOsByTech(string day, int idTech)
        {
            try
            {
                BLL bll = new BLL();
                Os[] listOs = bll.getOsByTech(day, idTech);
                return listOs;
            }
            catch
            {
                return null;
            }
        }

        [WebMethod]
        public bool route(string day, int area, int tecnico)
        {
            try
            {
                BLL bll = new BLL();
                return bll.route(day, area, tecnico);
             
            }
            catch
            {
                return false;
            }
        }

        [WebMethod]
        public bool fecharOs(int idOs)
        {
            try
            {
                BLL bll = new BLL();
                return bll.fecharOs(idOs);

            }
            catch
            {
                return false;
            }
        }

        //[WebMethod]
        //public bool setStatusOs(string status)
        //{
        //    try
        //    {
        //        BLL bll = new BLL();
        //        return bll.setStatusOs(status); ;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}


        //[WebMethod]
        //public Os[] getOsByTech(int idTech)
        //{
        //    try
        //    {
        //        BLL bll = new BLL();
        //        Os[] listOs = bll.getOsByTech(idTech);
        //        return listOs;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //[WebMethod]
        //public bool sendMessage(int idOs, string menssage)
        //{
        //    try
        //    {
        //        BLL bll = new BLL();
        //        return bll.sendMessage(idOs, menssage);
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

    }
}