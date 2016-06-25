using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace HUB
{
    class Data
    {

        public static DataTable getData(string query, string metadataConnectionString)
        {
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, metadataConnectionString))
            {
                dataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static DataTable getData(string query, string parameter, string parameterValue, string metadataConnectionString)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(metadataConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue(parameter, parameterValue);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }
    }
}
