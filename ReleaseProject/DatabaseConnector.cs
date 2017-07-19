using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReleaseProject {
    public class DatabaseConnector {
       //@"Data Source=IDEA-PC\SQLEXPRESS; Initial Catalog=testDatabase;Integrated Security=False;User ID=user;Password=1234";
        string dataSourse;
        string initialCatalog;
        bool integratedSecurity=true;
        string userID;
        string password;
        SqlConnectionStringBuilder conStr = new SqlConnectionStringBuilder();

        public string DataSourse { get { return dataSourse; } set { dataSourse = value; } }
        public string InitialCatalog { get { return initialCatalog; } set { initialCatalog = value; } }
        public bool IntegratedSecurity { get { return integratedSecurity; } set { integratedSecurity = value; } }
        public string UserID { get { return userID; } set { userID = value; } }
        public string Password { get { return password; } set { password = value; } }
        public SqlConnectionStringBuilder ConnectionString { get { return conStr; } }

        public void InitializeFields(string dataSource_c, bool integratedSecurity_c, string userID_c, string password_c, string initialCatalog_c) {
            DataSourse = dataSource_c;
            InitialCatalog = initialCatalog_c;
            if (integratedSecurity_c) {
                IntegratedSecurity = false;
                UserID = userID_c;
                Password = password_c;
            }
            else {
                IntegratedSecurity = true;
                UserID = "";
                Password = "";
            }   
        }

        public void InitializeSrting() {
            conStr.DataSource = dataSourse;
            conStr.InitialCatalog = initialCatalog;
            conStr.IntegratedSecurity = integratedSecurity;
            if (!integratedSecurity) { conStr.Password = Password; conStr.UserID = UserID; }
        }

        public List<string> GetDbList() {
            try {
                InitializeSrting();
                string query = "SELECT name FROM sys.databases";
                DataTable table = new DataTable();

                using (SqlConnection con = new SqlConnection(conStr.ToString())) {
                    con.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    adapter.Fill(table);

                    con.Close();
                }

                List<string> list = new List<string>();
                for (int i = 0; i < table.Rows.Count; i++) {
                    list.Add(table.Rows[i][0].ToString());
                }
                return list;
            }
            catch  {
                return null;
            }
        }

        public bool CheckConnect() {
            InitializeSrting();
            try {
                SqlConnection con = new SqlConnection(conStr.ToString());
                con.Open();
                con.Close();
                return true;
            }
            catch {
                return false;
            }
        }


    }
}
