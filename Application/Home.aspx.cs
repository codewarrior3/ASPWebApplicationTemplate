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
            /* string connstring = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connstring))
            {
                using (SqlCommand cmdd = new SqlCommand("select * from [myDbTable]", conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmdd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        //Bind the datasource with a repeater control in which you can  place textbox control. It will repeat for every data rows.


                    }
                }

            }*/
        }
    }
}