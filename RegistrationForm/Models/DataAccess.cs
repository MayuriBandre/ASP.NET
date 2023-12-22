using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace RegistrationForm.Models
{
    public class DataAccess
    {
        private readonly SqlConnection con;

        public DataAccess(string connectionString)
        {
            con = new SqlConnection(connectionString);
        }

        public bool AddUser(UserModel userModel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("sp_InsertUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", userModel.Name);
            cmd.Parameters.AddWithValue("@Email", userModel.Email);
            cmd.Parameters.AddWithValue("@Phone", userModel.Phone);
            cmd.Parameters.AddWithValue("@Address", userModel.Address);
            cmd.Parameters.AddWithValue("@StateId", userModel.StateId);
            cmd.Parameters.AddWithValue("@CityId", userModel.CityId);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1;
        }

        public List<UserModel> GetUsers()
        {
            connection();
            List<UserModel> userList = new List<UserModel>();

            SqlCommand cmd = new SqlCommand("sp_GetUserDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                userList.Add(new UserModel
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = Convert.ToString(dr["Name"]),
                    Email = Convert.ToString(dr["Email"]),
                    Phone = Convert.ToString(dr["Phone"]),
                    Address = Convert.ToString(dr["Address"]),
                    StateId = Convert.ToInt32(dr["StateId"]),
                    CityId = Convert.ToInt32(dr["CityId"])
                });
            }

            return userList;
        }
        public List<UserModel> GetCities(int stateId)
        {
            connection();
            List<UserModel> cityList = new List<UserModel>();

            SqlCommand cmd = new SqlCommand("sp_GetCity", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StateId", stateId);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                cityList.Add(new UserModel
                {
                    CityId = Convert.ToInt32(dr["CityId"]),
                    CityName = Convert.ToString(dr["CityName"]),
                    StateId = Convert.ToInt32(dr["StateId"])
                });
            }

            return cityList;
        }
        public List<UserModel> GetCitiesName(int cityId)
        {
            connection();
            List<UserModel> cityList = new List<UserModel>();

            SqlCommand cmd = new SqlCommand("sp_Getcityname", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CityId", cityId);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                cityList.Add(new UserModel
                {
                    
                    CityName = Convert.ToString(dr["CityName"]),
                    
                });
            }

            return cityList;
        }


        public List<UserModel> GetStates()
        {
            connection();
            List<UserModel> stateList = new List<UserModel>();

            SqlCommand cmd = new SqlCommand("sp_GetState", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                stateList.Add(new UserModel
                {
                    StateId = Convert.ToInt32(dr["Id"]),
                    StateName = Convert.ToString(dr["StateName"])
                });
            }

            return stateList;
        }

        
        public bool UpdateUser(UserModel userModel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("sp_UpdateUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId", userModel.Id);
            cmd.Parameters.AddWithValue("@Name", userModel.Name);
            cmd.Parameters.AddWithValue("@Email", userModel.Email);
            cmd.Parameters.AddWithValue("@Phone", userModel.Phone);
            cmd.Parameters.AddWithValue("@Address", userModel.Address);
            cmd.Parameters.AddWithValue("@StateId", userModel.StateId);
            cmd.Parameters.AddWithValue("@CityId", userModel.CityId);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1;
        }

        public bool DeleteUser(int userId)
        {
            connection();
            SqlCommand cmd = new SqlCommand("sp_DeleteUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId", userId);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1;
        }

        private void connection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
