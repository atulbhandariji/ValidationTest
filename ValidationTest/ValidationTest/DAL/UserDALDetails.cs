using System.Data;
using System.Data.SqlClient;
using ValidationTest.Models;

namespace ValidationTest.DAL
{
    public class UserDALDetails : IUserDALDetails
    {
        public SqlConnection sqlConnection;
        string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB; Initial Catalog = USERMANAGEMENT; Integrated Security = True";
        UserDetails userDetails = new UserDetails();
        CountryDetails countryDetails = new CountryDetails();
        List<UserDetails> userList = new List<UserDetails>();
        List<CountryDetails> countryList = new List<CountryDetails>();
        public List<CountryDetails> GetCountryDetails()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select * from CountryMaster", sqlConnection);
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                countryDetails.CountryId = Convert.ToInt32(dataTable.Rows[i]["CountryId"].ToString());
                countryDetails.CountryName = dataTable.Rows[i]["CountryName"].ToString();
                countryList.Add(countryDetails);
            }
            sqlConnection.Close();
            return countryList;
        }

        public List<UserDetails> GetUserList()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("USP_GETUSERDETAILS", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                userDetails.UserId = Convert.ToInt32(dataTable.Rows[i]["UserId"].ToString());
                userDetails.Name = dataTable.Rows[i]["Name"].ToString();
                userDetails.Email = dataTable.Rows[i]["Email"].ToString();
                userDetails.Address = dataTable.Rows[i]["Address"].ToString();
                userDetails.MobileNo = dataTable.Rows[i]["Mobile"].ToString();
                userDetails.Country = dataTable.Rows[i]["CountryName"].ToString();
                userDetails.State = dataTable.Rows[i]["StateName"].ToString();
                userDetails.City = dataTable.Rows[i]["CityName"].ToString();
                userDetails.Course = dataTable.Rows[i]["CourseName"].ToString();
                userDetails.EnterBy = dataTable.Rows[i]["EnterBy"].ToString();
                userList.Add(userDetails);
            }
            sqlConnection.Close();
            return userList;
        }
    }
}
