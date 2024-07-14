using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemos_ConApp
{
    class LINQToDataSet
    {
        static void Main(string[] args)
        {
            Using_LINQToDataset_WithRelationship();
            Console.WriteLine();
            //Using_LINQToDataSet_WithoutRelation();
            //
            Console.ReadLine();
        }

        private static void Using_LINQToDataset_WithRelationship()
        {
            string connectString = 
                System.Configuration.ConfigurationManager.ConnectionStrings["SqlConStr"].ToString();

            string sqlSelect = "SELECT * FROM Department;" + "SELECT * FROM Employee;";

            // Create the data adapter to retrieve data from the database
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, connectString);

            // Create table mappings
            da.TableMappings.Add("Table", "Department");
            da.TableMappings.Add("Table1", "Employee");

            // Create and fill the DataSet
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataRelation dr = ds.Relations.Add("FK_Employee_Department",
                              ds.Tables["Department"].Columns["Id"],
                              ds.Tables["Employee"].Columns["DepartmentId"]);

            DataTable department = ds.Tables["Department"];
            DataTable employee = ds.Tables["Employee"];

            var query = from d in department.AsEnumerable()
                        join e in employee.AsEnumerable()
                        on d.Field<int>("Id") equals
                        e.Field<int>("DepartmentId")
                        select new
                        {
                            EmployeeId = e.Field<int>("Id"),
                            Name = e.Field<string>("Name"),
                            DepartmentId = d.Field<int>("Id"),
                            DepartmentName = d.Field<string>("Name")
                        };
            Console.WriteLine("---- Data From Employee and Department DataTable -----");

            foreach (var q in query)
            {
                Console.WriteLine("Employee Id = {0} , Name = {1} , Department Name = {2}",
                   q.EmployeeId, q.Name, q.DepartmentName);
            }

        }

        private static void Using_LINQToDataSet_WithoutRelation()
        {
            string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConStr"].ToString();

            string sqlSelect = "SELECT * FROM Employee;";

            // Create the data adapter to retrieve data from the database
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, connectString);

            // Create table mappings
            da.TableMappings.Add("Table", "Employee");

            // Create and fill the DataSet
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable emp = ds.Tables["Employee"];

            var query = from e in emp.AsEnumerable()
                        where e.Field<int>("Id") == 101
                        select new
                        {
                            Id = e.Field<int>("Id"),
                            Name = e.Field<string>("Name")
                        };
            Console.WriteLine("---- Data From Employee DataTable -----");

            foreach (var q in query)
            {
                Console.WriteLine("Employee Id = {0} , Name = {1}",
                   q.Id, q.Name);
            }

        }
    }
    
}
