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
                using (SqlCommand cmdd = new SqlCommand("select * from [PersonAndTheirHobby]", conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmdd))
                    {
                        adapter.Fill(dt);

                        //Bind the datasource with a repeater control in which you can  place textbox control. It will repeat for every data rows.
                    }
                }
            }
        }
    }
}