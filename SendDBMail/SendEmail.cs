//Send Email from SQL Server
using (SqlConnection conMail = new SqlConnection(ConfigurationManager.ConnectionStrings["sendMail"].ConnectionString))
{
    using(SqlCommand cmdMail = new SqlCommand("sp_send_dbmail", conMail))
    {
        cmdMail.CommandType = CommandType.StoredProcedure;

        cmdMail.Parameters.AddWithValue("@profile_name", SqlDbType.VarChar).Value = "ussc";
        //cmdMail.Parameters.AddWithValue("@from_address", SqlDbType.VarChar).Value = "mec@uh.edu";
        cmdMail.Parameters.AddWithValue("@recipients", SqlDbType.VarChar).Value = emailString;
        cmdMail.Parameters.AddWithValue("@body", SqlDbType.VarChar).Value = body;
        cmdMail.Parameters.AddWithValue("@body_format", SqlDbType.VarChar).Value = "HTML";
        cmdMail.Parameters.AddWithValue("@Subject",
            SqlDbType.VarChar).Value = getAppConfigValue("subjectOfEmail");

        conMail.Open();
        cmdMail.ExecuteNonQuery();

    }
}
