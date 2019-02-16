using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Application
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmdd = new SqlCommand("select * from [Hobbies]", conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmdd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            ddlHobbies.DataSource = dt;
            ddlHobbies.DataBind();
        }
    }
}