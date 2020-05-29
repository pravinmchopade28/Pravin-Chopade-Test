using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PravinChopadeTest.Models
{
    public class ProductDAL
    {
        string connectionString = ""; // for Security concern the connection string is Removed (like sql id and password)
        public IEnumerable<ProductModel> getAllProductDetails()
        {
            List<ProductModel> productlist = new List<ProductModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_GetProductDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ProductModel pm = new ProductModel();
                    pm.ProductID = Convert.ToInt32(dr["ProductID"].ToString());
                    pm.ProductName = dr["ProductName"].ToString();
                    pm.Price = Convert.ToDecimal(dr["Price"].ToString());
                    pm.IsGSTApplicable = Convert.ToBoolean(dr["IsGSTApplicable"].ToString());
                    pm.PurchaseDate = Convert.ToDateTime(dr["PurchaseDate"].ToString());
                    pm.ExpireDate = Convert.ToDateTime(dr["ExpireDate"].ToString());
                    pm.Color = dr["Color"].ToString();
                    productlist.Add(pm);
                }
                con.Close();
            }
            return productlist;
        }

        public ProductModel getProductByID(long ProductID)
        {
            ProductModel pm = new ProductModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_GetProductDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    pm.ProductID = Convert.ToInt32(dr["ProductID"].ToString());
                    pm.ProductName = dr["ProductName"].ToString();
                    pm.Price = Convert.ToDecimal(dr["Price"].ToString());
                    pm.IsGSTApplicable = Convert.ToBoolean(dr["IsGSTApplicable"].ToString());
                    pm.PurchaseDate = Convert.ToDateTime(dr["PurchaseDate"].ToString());
                    pm.ExpireDate = Convert.ToDateTime(dr["ExpireDate"].ToString());
                    pm.Color = dr["Color"].ToString();
                }
                con.Close();
            }
            return pm;
        }

        public ProductModel checkProductName(string ProductName)
        {
            ProductModel pm = new ProductModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_CheckProductName", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductName", ProductName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    pm.ProductID = Convert.ToInt32(dr["ProductID"].ToString());
                    pm.ProductName = dr["ProductName"].ToString();
                    pm.Price = Convert.ToDecimal(dr["Price"].ToString());
                    pm.IsGSTApplicable = Convert.ToBoolean(dr["IsGSTApplicable"].ToString());
                    pm.PurchaseDate = Convert.ToDateTime(dr["PurchaseDate"].ToString());
                    pm.ExpireDate = Convert.ToDateTime(dr["ExpireDate"].ToString());
                    pm.Color = dr["Color"].ToString();
                }
                con.Close();
            }
            return pm;
        }


        public void addProduct(ProductModel pm)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_ModifyProduct", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", pm.ProductID);
                cmd.Parameters.AddWithValue("@ProductName", pm.ProductName);
                cmd.Parameters.AddWithValue("@Price", pm.Price);
                cmd.Parameters.AddWithValue("@IsGSTApplicable", pm.IsGSTApplicable);
                cmd.Parameters.AddWithValue("@PurchaseDate", pm.PurchaseDate);
                cmd.Parameters.AddWithValue("@ExpireDate", pm.ExpireDate);
                cmd.Parameters.AddWithValue("@Color", pm.Color);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void deleteProduct(long id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_DeleteProduct", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                con.Close();
            }
        }
    }
}
