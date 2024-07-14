using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADODotNet_Disconnected_Arch
{
    internal class EmployeeDA
    {
        
        SqlConnection objSqlCon;
        SqlCommand objSqlCom;
        SqlDataAdapter objSqlDA;
        DataSet objDS;
        SqlCommandBuilder objSqlComBuilder;

        internal EmployeeDA()
        {
            GetDataFromDB();
        }

        internal void GetDataFromDB()
        {
            objSqlCon = new SqlConnection("server=.;database=GEP;integrated security=true");
            objSqlCom = new SqlCommand("select * from employee",objSqlCon);
            objDS = new DataSet();
            objSqlDA = new SqlDataAdapter(objSqlCom);
            objSqlComBuilder = new SqlCommandBuilder(objSqlDA);
            objSqlDA.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            objSqlDA.Fill(objDS);
        }

        internal void InsertEmployee()
        {
            int id;
            string name;
            int designationId;
            int departmentId;
            //
            Console.WriteLine("Enter Employee records");
            Console.WriteLine("Enter Id");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name");
            name = Console.ReadLine();
            Console.WriteLine("Enter DesignationId");
            designationId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter DepartmentId");
            departmentId = Convert.ToInt32(Console.ReadLine());
            //
            DataRow objDRNew = objDS.Tables[0].NewRow();
            objDRNew[0] = id;
            objDRNew[1] = name;
            objDRNew[2] = designationId;
            objDRNew[3] = departmentId;
            objDS.Tables[0].Rows.Add(objDRNew);
        }

        internal void UpdateEmployee()
        {
            int id;
            string name;
            int designationId;
            int departmentId;
            //
            Console.WriteLine("Enter Employee records to Edit");
            Console.WriteLine("Enter Id");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name");
            name = Console.ReadLine();
            Console.WriteLine("Enter DesignationId");
            designationId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter DepartmentId");
            departmentId = Convert.ToInt32(Console.ReadLine());
            //
            DataRow objDRFind = objDS.Tables[0].Rows.Find(id);
            objDRFind[1] = name;
            objDRFind[2] = designationId;
            objDRFind[3] = departmentId;
        }

        internal void DeleteEmployee()
        {
            int id;
            //
            Console.WriteLine("Enter Employee Id to Delete a record.");
            Console.WriteLine("Enter Id");
            id = Convert.ToInt32(Console.ReadLine());
            //
            //DataRow objDRFind =  objDS.Tables[0].Rows.Find(id);
            objDS.Tables[0].Rows.Find(id).Delete();
        }

        internal void SearchEmployee()
        {
            int id;
            //
            Console.WriteLine("Enter Employee Id to Search the record.");
            Console.WriteLine("Enter Id");
            id = Convert.ToInt32(Console.ReadLine());
            //
            DataRow objDRFind = objDS.Tables[0].Rows.Find(id);
            Console.WriteLine("Id: {0}, Name: {1}, DesignationId: {2} and DepartmentId: {3}"
                , objDRFind[0], objDRFind[1], objDRFind[2], objDRFind[3]);
        }

        internal void ListEmployees()
        {
            Console.WriteLine("-----List of Employees-----");
            //
            DataTable objDT = objDS.Tables[0];
            if (objDT.Rows.Count > 0)
            {
                for (int i = 0; i < objDT.Rows.Count; i++)
                {
                    Console.WriteLine("Id: {0}, Name: {1}, DesignationId: {2}, DepartmentId: {3}"
                        , objDT.Rows[i][0], objDT.Rows[i][1]
                        , objDT.Rows[i][2], objDT.Rows[i][3]);
                }
            }
            else
            {
                Console.WriteLine("Records not found.");
            }
        }

        internal void UpdateDB()
        {
            objSqlDA.Update(objDS);
        }
    }
}
