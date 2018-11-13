using _23___WEBAPI_Assignment___1_DOTNET.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace _23___WEBAPI_Assignment___1_DOTNET.Data_Access_Layer
{
    public class DataAccessLayer
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["mySQLConnection"].ToString();
            con = new SqlConnection(constr);
        }

        #region "Suppliers"
        public IEnumerable<Suppliers> GetAllSuppliers()
        {
            Suppliers Supplier = null;
            List<Suppliers> listSuppli = new List<Suppliers>();
            try
            {
                connection();
                SqlDataReader reader = null;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "SELECT * from Supplier";
                sqlCmd.Connection = con;
                con.Open();
                reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    Supplier = new Suppliers();
                    Supplier.SUPLNO = Convert.ToInt32(reader.GetValue(0));
                    Supplier.SUPLNAME = reader.GetValue(1).ToString();
                    Supplier.SUPLADDR = reader.GetValue(2).ToString();
                    listSuppli.Add(Supplier);
                }

            }
            catch (Exception ex)
            {
                con.Close();
            }
            return listSuppli;
        }
        public Suppliers GetAllSuppliers(int SUPLNO)
        {
            Suppliers Supplier = null;
            try
            {
                SqlDataReader reader = null;
                connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "SELECT * from Supplier where SUPLNO=" + SUPLNO + "";
                sqlCmd.Connection = con;
                con.Open();
                reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    Supplier = new Suppliers();
                    Supplier.SUPLNO = Convert.ToInt32(reader.GetValue(0));
                    Supplier.SUPLNAME = reader.GetValue(1).ToString();
                    Supplier.SUPLADDR = reader.GetValue(2).ToString();
                }
            }
            catch (Exception ex)
            {
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return Supplier;
        }
        public int InsertSuppliers(Suppliers Supplier)
        {
            int rowInserted = 0;
            connection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "Insert into Supplier(SUPLNO,SUPLNAME,SUPLADDR)VALUES(@SUPLNO,@SUPLNAME,@SUPLADDR)";
                sqlCmd.Connection = con;
                sqlCmd.Parameters.AddWithValue("@SUPLNO", Supplier.SUPLNO);
                sqlCmd.Parameters.AddWithValue("@SUPLNAME", Supplier.SUPLNAME);
                sqlCmd.Parameters.AddWithValue("@SUPLADDR", Supplier.SUPLADDR);
                con.Open();
                rowInserted = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return rowInserted;


        }
        public int DeleteSupplierByID(int SUPLNO)
        {
            int rowDeleted = 0;
            try
            {
                connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "delete from Supplier where SUPLNO=" + SUPLNO + "";
                sqlCmd.Connection = con;
                con.Open();
                rowDeleted = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            finally
            {
                con.Close();
            }

            return rowDeleted;
        }
        public int UpdateSuppliers(Suppliers Supplier)
        {
            int rowInserted = 0;
            connection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "update Supplier set SUPLNAME=@SUPLNAME,SUPLADDR=@SUPLADDR where SUPLNO=@SUPLNO";
                sqlCmd.Connection = con;
                sqlCmd.Parameters.AddWithValue("@SUPLNO", Supplier.SUPLNO);
                sqlCmd.Parameters.AddWithValue("@SUPLNAME", Supplier.SUPLNAME);
                sqlCmd.Parameters.AddWithValue("@SUPLADDR", Supplier.SUPLADDR);
                con.Open();
                rowInserted = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return rowInserted;


        }
        #endregion

        #region "Items"

        public IEnumerable<Items> GetAllItems()
        {
            Items Item = null;
            List<Items> listSuppli = new List<Items>();
            try
            {
                connection();
                SqlDataReader reader = null;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "SELECT * from ITEM";
                sqlCmd.Connection = con;
                con.Open();
                reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    Item = new Items();
                    Item.ITCODE = reader.GetValue(0).ToString();
                    Item.ITDESC = reader.GetValue(1).ToString();
                    Item.ITRATE = Convert.ToDouble(reader.GetValue(2).ToString());
                    listSuppli.Add(Item);
                }

            }
            catch (Exception ex)
            {
                con.Close();
            }
            return listSuppli;
        }
        public Items GetAllItems(string ITCODE)
        {
            Items Item = null;
            try
            {
                SqlDataReader reader = null;
                connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "SELECT * from ITEM where ITCODE='" + ITCODE + "'";
                sqlCmd.Connection = con;
                con.Open();
                reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    Item = new Items();
                    Item.ITCODE = reader.GetValue(0).ToString();
                    Item.ITDESC = reader.GetValue(1).ToString();
                    Item.ITRATE = Convert.ToDouble(reader.GetValue(2).ToString());
                }
            }
            catch (Exception ex)
            {
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return Item;
        }
        public int InsertItems(Items Item)
        {
            int rowInserted = 0;
            connection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "Insert into ITEM(ITCODE,ITDESC,ITRATE)VALUES(@ITCODE,@ITDESC,@ITRATE)";
                sqlCmd.Connection = con;
                sqlCmd.Parameters.AddWithValue("@ITCODE", Item.ITCODE);
                sqlCmd.Parameters.AddWithValue("@ITDESC", Item.ITDESC);
                sqlCmd.Parameters.AddWithValue("@ITRATE", Item.ITRATE);
                con.Open();
                rowInserted = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return rowInserted;


        }
        public int DeleteItemByID(string ITCODE)
        {
            int rowDeleted = 0;
            try
            {
                connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "DELETE from ITEM where ITCODE='" + ITCODE + "'";
                sqlCmd.Connection = con;
                con.Open();
                rowDeleted = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            finally
            {
                con.Close();
            }

            return rowDeleted;
        }
        public int UpdateItems(Items Item)
        {
            int rowInserted = 0;
            connection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "update ITEM set ITDESC=@ITDESC,ITRATE=@ITRATE where ITCODE=@ITCODE";
                sqlCmd.Connection = con;
                sqlCmd.Parameters.AddWithValue("@ITCODE", Item.ITCODE);
                sqlCmd.Parameters.AddWithValue("@ITDESC", Item.ITDESC);
                sqlCmd.Parameters.AddWithValue("@ITRATE", Item.ITRATE);
                con.Open();
                rowInserted = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return rowInserted;


        }
        #endregion

        #region "Purchage Orders"
        public IEnumerable<PODetails> GetAllPurchageOrders()
        {
            PODetails PODetails = null;
            List<PODetails> listPODetails = new List<PODetails>();
            try
            {
                connection();
                SqlDataReader reader = null;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "select RTRIM([POMASTER].PONO),PODATE,SUPLNO,ITCODE,QTY from [POMASTER] inner join PODETAIL on PODETAIL.PONO=[POMASTER].PONO";
                sqlCmd.Connection = con;
                con.Open();
                reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    PODetails = new PODetails();
                    PODetails.PONO = reader.GetValue(0).ToString();
                    PODetails.PODATE = Convert.ToDateTime(reader.GetValue(1).ToString());
                    PODetails.SUPLNO = Convert.ToInt32(reader.GetValue(2).ToString());
                    PODetails.ITCODE = reader.GetValue(3).ToString();
                    PODetails.QTY = Convert.ToInt32(reader.GetValue(4));
                    listPODetails.Add(PODetails);
                }

            }
            catch (Exception ex)
            {
                con.Close();
            }
            return listPODetails;
        }
        public PODetails GetAllPurchageOrders(string PONO)
        {
            PODetails PODetails = null;
            try
            {
                SqlDataReader reader = null;
                connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "select RTRIM([POMASTER].PONO),PODATE,SUPLNO,ITCODE,QTY from [POMASTER] inner join PODETAIL on PODETAIL.PONO=[POMASTER].PONO and [POMASTER].PONO='" + PONO + "'";
                sqlCmd.Connection = con;
                con.Open();
                reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    PODetails = new PODetails();
                    PODetails.PONO = reader.GetValue(0).ToString();
                    PODetails.PODATE = Convert.ToDateTime(reader.GetValue(1).ToString());
                    PODetails.SUPLNO = Convert.ToInt32(reader.GetValue(2).ToString());
                    PODetails.ITCODE = reader.GetValue(3).ToString();
                    PODetails.QTY = Convert.ToInt32(reader.GetValue(4));
                }
            }
            catch (Exception ex)
            {
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return PODetails;
        }
        public int InsertPODetails(PODetails PODetails)
        {
            int rowInserted = 0;
            connection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "Insert into POMASTER(PONO,PODATE,SUPLNO)VALUES(@PONO,@PODATE,@SUPLNO)";
                sqlCmd.Connection = con;
                sqlCmd.Parameters.AddWithValue("@PONO", PODetails.PONO);
                sqlCmd.Parameters.AddWithValue("@PODATE", PODetails.PODATE);
                sqlCmd.Parameters.AddWithValue("@SUPLNO", PODetails.SUPLNO);
                con.Open();
                rowInserted = sqlCmd.ExecuteNonQuery();
                sqlCmd.CommandText = "Insert into PODETAIL(PONO,ITCODE,QTY)VALUES(@PONO,@ITCODE,@QTY)";
                sqlCmd.Parameters.AddWithValue("@PONO", PODetails.PONO);
                sqlCmd.Parameters.AddWithValue("@ITCODE", PODetails.ITCODE);
                sqlCmd.Parameters.AddWithValue("@QTY", PODetails.QTY);
                rowInserted = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return rowInserted;


        }
        public int DeletePurchageOrdersByID(string PONO)
        {
            int rowDeleted = 0;
            try
            {
                connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "DELETE FROM PODETAIL WHERE PONO='" + PONO + "'";
                sqlCmd.Connection = con;
                con.Open();
                rowDeleted = sqlCmd.ExecuteNonQuery();
                sqlCmd.CommandText = "DELETE FROM POMASTER WHERE PONO='" + PONO + "'";
                rowDeleted = sqlCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                con.Close();
            }
            finally
            {
                con.Close();
            }

            return rowDeleted;
        }
        public int UpdatePurchageOrders(PODetails PODetails)
        {
            int rowInserted = 0;
            connection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "update POMASTER set SUPLNO=@SUPLNO,PODATE=@PODATE where PONO=@PONO";
                sqlCmd.Connection = con;
                sqlCmd.Parameters.AddWithValue("@PONO", PODetails.PONO);
                sqlCmd.Parameters.AddWithValue("@PODATE", PODetails.PODATE);
                sqlCmd.Parameters.AddWithValue("@SUPLNO", PODetails.SUPLNO);
                con.Open();
                rowInserted = sqlCmd.ExecuteNonQuery();

                sqlCmd.CommandText = "update PODETAIL set ITCODE=@ITCODE,QTY=@QTY where PONO=@PONO";
                sqlCmd.Parameters.AddWithValue("@QTY", PODetails.QTY);
                sqlCmd.Parameters.AddWithValue("@ITCODE", PODetails.ITCODE);
                rowInserted = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return rowInserted;
        }
        #endregion
    }
}