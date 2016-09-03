using System;
using System.Collections.Generic;
using System.Web;
using System.Data;

namespace GeoLogistica
{
    public class DAO
    {


        #region getOsByDay
        private string getSQL_getOsByDay(string day)
        {
            //string strSql = "SELECT * FROM OS WHERE data_atendimento = '"+ day +"'";
            string strSql = "select os.id_os, os.id_cliente, os.id_tecnico, os.data_atendimento, os.hora_atendimento, os.status, endereco.desc_endereco, cliente.numero_end from os inner join cliente ";
            strSql += "on os.id_cliente = cliente.id_cliente ";
            strSql += "join endereco ";
            strSql += "on cliente.cep = endereco.cep ";
            strSql += "where os.data_atendimento ='" + day + "'";


            return strSql;
        }


        public DataSet getOsByDay(string day)
        {
            DataSet dt;
            Db banco = new Db();
            try
            {
                banco.openConn();
                dt = banco.GETSql(this.getSQL_getOsByDay(day));
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region loginTech
        private string getSQL_loginTech(string user, string password)
        {
            string strSql = "SELECT * FROM dbo.tecnico ";
            strSql += " WHERE usuario = '" + user + "' ";
            strSql += " AND senha = '" + password + "' ";
            return strSql;
        }


        internal DataSet loginTech(string user, string password)
        {
            DataSet dt;
            Db banco = new Db();
            try
            {
                banco.openConn();
                dt = banco.GETSql(this.getSQL_loginTech(user, password));
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion


        #region loginClient

        private string getSQL_loginClient(string user, string password)
        {
            string strSql = "SELECT * FROM dbo.client ";
            strSql += " WHERE usuario = '" + user + "' ";
            strSql += " AND senha = '" + password + "' ";
            return strSql;
        }


        internal DataSet loginClient(string user, string password)
        {
            DataSet dt;
            Db banco = new Db();
            try
            {
                banco.openConn();
                dt = banco.GETSql(this.getSQL_loginClient(user, password));
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion



        #region route
        private string getSQL_getOsHorarioAera(string day, int area)
        {
            string strSql = " SELECT MAX(os.id_os) as id_os, os.hora_atendimento ";
            strSql += " from os inner join cliente ";
            strSql += " on os.id_cliente = cliente.id_cliente ";
            strSql += " inner join endereco ";
            strSql += " on cliente.cep = endereco.cep ";
            strSql += " inner join node ";
            strSql += " on endereco.id_node = node.node ";
            strSql += " where node.id_area = " + area.ToString();
            strSql += " and os.data_atendimento = '" + day + "' ";
            strSql += " GROUP BY os.hora_atendimento ";
            strSql += " order by os.hora_atendimento asc ";
            return strSql;
        }


        internal DataSet getOsHorarioAera(string day, int area)
        {
            DataSet dt;
            Db banco = new Db();
            try
            {
                banco.openConn();
                dt = banco.GETSql(this.getSQL_getOsHorarioAera(day, area));
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }




        private string getSQL_routeToTech(int idOs, int idTech)
        {
            string strSql = " update os ";
            strSql += " set id_tecnico = " + idTech.ToString();
            strSql += " where id_os = " + idOs.ToString();
            return strSql;
        }


        internal bool routeToTech(int idOs, int idTech)
        {
            Db banco = new Db();
            try
            {
                banco.openConn();
                return banco.SETSql(this.getSQL_routeToTech(idOs, idTech)); ;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion



        #region fecharOs

        private string getSQL_fecharOs(int idOs)
        {


            string strSql = "update os ";
            strSql += " set status = 'FEC' ";
            strSql += " where id_os = " + idOs.ToString();

            return strSql;
        }


        internal bool fecharOs(int idOs)
        {
            Db banco = new Db();
            try
            {
                banco.openConn();
                return banco.SETSql(this.getSQL_fecharOs(idOs)); ;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region getOsByTech

        private string getSQL_getOsByTech(string day, int idTech)
        {
            //string strSql = "SELECT * FROM OS WHERE data_atendimento = '"+ day +"'";
            string strSql = "select os.id_os, os.id_cliente, os.id_tecnico, os.data_atendimento, os.hora_atendimento, os.status, endereco.desc_endereco, cliente.numero_end from os inner join cliente ";
            strSql += "on os.id_cliente = cliente.id_cliente ";
            strSql += "join endereco ";
            strSql += "on cliente.cep = endereco.cep ";
            strSql += "where os.data_atendimento ='" + day + "' and os.id_tecnico = " + idTech.ToString();


            return strSql;
        }


        internal DataSet getOsByTech(string day, int idTech)
        {
            DataSet dt;
            Db banco = new Db();
            try
            {
                banco.openConn();
                dt = banco.GETSql(this.getSQL_getOsByTech(day, idTech));
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}