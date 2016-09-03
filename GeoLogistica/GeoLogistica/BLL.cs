using System;
using System.Collections.Generic;
using System.Web;
using System.Data;


namespace GeoLogistica
{
    public class BLL
    {


        internal Tecnico loginTech(string user, string password)
        {
            try
            {
                DAO dao = new DAO();
                Tecnico tecnico = new Tecnico();
                DataSet dt = dao.loginTech(user, password);

                if (dt != null && dt.Tables[0].Rows.Count >= 1)
                {
                    foreach (DataRow row in dt.Tables[0].Rows)
                    {
                        tecnico = new Tecnico();
                        tecnico.IdTecnico = int.Parse(row["id_tecnico"].ToString());
                        tecnico.IdArea = int.Parse(row["id_area"].ToString());
                        tecnico.NomeTecnico = row["nome_tecnico"].ToString();
                        break;

                    }
                    return tecnico;
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        internal bool loginClient(string user, string password)
        {
            try
            {
                DAO dao = new DAO();
                DataSet dt = dao.loginClient(user, password);

                if (dt != null && dt.Tables[0].Rows.Count >= 1)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        internal Os[] getOsByTech(string day, int idTech)
        {
            try
            {
                DAO dao = new DAO();
                DataSet dt = dao.getOsByTech(day, idTech);
                Os[] arrayOs;
                Os os;

                if (dt != null && dt.Tables[0].Rows.Count >= 1)
                {
                    arrayOs = new Os[dt.Tables[0].Rows.Count];
                    int i = 0;
                    foreach (DataRow row in dt.Tables[0].Rows)
                    {
                        os = new Os();
                        os.IdOS = int.Parse(row["id_os"].ToString());
                        os.IdTecnico = int.Parse(row["id_tecnico"].ToString());
                        os.IdCliente = int.Parse(row["id_cliente"].ToString());
                        os.Status = row["status"].ToString();
                        os.Endereco = row["desc_endereco"].ToString();
                        os.Num = int.Parse(row["numero_end"].ToString());
                        os.HoraAtendimento = int.Parse(row["hora_atendimento"].ToString());
                        os.DataAtendimento = row["data_atendimento"].ToString();

                        arrayOs[i] = os;
                        i++;
                    }
                    return arrayOs;
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        internal Os[] getOsByDay(string day)
        {
            try
            {
                DAO dao = new DAO();
                DataSet dt = dao.getOsByDay(day);
                Os[] arrayOs;
                Os os;

                if (dt != null && dt.Tables[0].Rows.Count >= 1)
                {
                    arrayOs = new Os[dt.Tables[0].Rows.Count];
                    int i = 0;
                    foreach (DataRow row in dt.Tables[0].Rows)
                    {
                        os = new Os();
                        os.IdOS = int.Parse(row["id_os"].ToString());
                        os.IdTecnico = int.Parse(row["id_tecnico"].ToString());
                        os.IdCliente = int.Parse(row["id_cliente"].ToString());
                        os.Status = row["status"].ToString();
                        os.Endereco = row["desc_endereco"].ToString();
                        os.Num = int.Parse(row["numero_end"].ToString());
                        os.HoraAtendimento = int.Parse(row["hora_atendimento"].ToString());
                        os.DataAtendimento = row["data_atendimento"].ToString();

                        arrayOs[i] = os;
                        i++;

                    }
                    return arrayOs;
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        internal bool route(string day, int area, int tecnico)
        {
            try
            {
                DAO dao = new DAO();
                DataSet dt = dao.getOsHorarioAera(day, area);


                if (dt != null && dt.Tables[0].Rows.Count >= 1)
                {

                    foreach (DataRow row in dt.Tables[0].Rows)
                    {
                        int idOs = int.Parse(row["id_os"].ToString());
                        int idTech = tecnico;
                        dao.routeToTech(idOs, idTech);
                    }
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }


        internal bool fecharOs(int idOs)
        {
            try
            {
                DAO dao = new DAO();
                return dao.fecharOs(idOs);
            }
            catch
            {
                return false;
            }
        }        
    }
}