using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ADODotNet_Connected_Arch_Using_SP
{
    internal class EmployeeDA
    {
        internal EmployeeDA()
        {

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
            SqlConnection objSqlCon = new SqlConnection(
                "server=.;database=GEP;integrated security=true");
            SqlCommand objSqlCom = new SqlCommand(
                "InsertEmployee", objSqlCon);
            objSqlCom.CommandType = CommandType.StoredProcedure;
            //
            SqlParameter objSqlParam_Id = new SqlParameter("@Id",id);
            SqlParameter objSqlParam_Name = new SqlParameter("@Name", name);
            SqlParameter objSqlParam_DesignationId = new SqlParameter("@DesignationId", designationId);
            SqlParameter objSqlParam_DepartmentId = new SqlParameter("@DepartmentId", departmentId);
            //
            objSqlParam_Id.Direction = ParameterDirection.Input;
            objSqlParam_Name.Direction = ParameterDirection.Input;
            objSqlParam_DesignationId.Direction = ParameterDirection.Input;
            objSqlParam_DepartmentId.Direction = ParameterDirection.Input;
            //
            objSqlCom.Parameters.Add(objSqlParam_Id);
            objSqlCom.Parameters.Add(objSqlParam_Name);
            objSqlCom.Parameters.Add(objSqlParam_DesignationId);
            objSqlCom.Parameters.Add(objSqlParam_DepartmentId);
            //
            objSqlCon.Open();
            int noOfRowsAffected = objSqlCom.ExecuteNonQuery();
            objSqlCon.Close();
            //
            if (noOfRowsAffected > 0)
            {
                Console.WriteLine("Record added successfully.");
            }
            else
            {
                Console.WriteLine("Record couldn't be added.");
            }
            
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
            SqlConnection objSqlCon = new SqlConnection(
                "server=.;database=GEP;integrated security=true");
            SqlCommand objSqlCom = new SqlCommand(
                "UpdateEmployee"
                , objSqlCon);
            //
            objSqlCom.CommandType = CommandType.StoredProcedure;
            //
            SqlParameter objSqlParam_Id = new SqlParameter("@Id", id);
            SqlParameter objSqlParam_Name = new SqlParameter("@Name", name);
            SqlParameter objSqlParam_DesignationId = new SqlParameter("@DesignationId", designationId);
            SqlParameter objSqlParam_DepartmentId = new SqlParameter("@DepartmentId", departmentId);
            //
            objSqlParam_Id.Direction = ParameterDirection.Input;
            objSqlParam_Name.Direction = ParameterDirection.Input;
            objSqlParam_DesignationId.Direction = ParameterDirection.Input;
            objSqlParam_DepartmentId.Direction = ParameterDirection.Input;
            //
            objSqlCom.Parameters.Add(objSqlParam_Id);
            objSqlCom.Parameters.Add(objSqlParam_Name);
            objSqlCom.Parameters.Add(objSqlParam_DesignationId);
            objSqlCom.Parameters.Add(objSqlParam_DepartmentId);
            //
            objSqlCon.Open();
            int noOfRowsAffected = objSqlCom.ExecuteNonQuery();
            objSqlCon.Close();
            //
            if (noOfRowsAffected > 0)
            {
                Console.WriteLine("Record updated successfully.");
            }
            else
            {
                Console.WriteLine("Record couldn't be updated.");
            }
        }

        internal void DeleteEmployee()
        {
            int id;
            //
            Console.WriteLine("Enter Employee Id to Delete a record.");
            Console.WriteLine("Enter Id");
            id = Convert.ToInt32(Console.ReadLine());
            //
            SqlConnection objSqlCon = new SqlConnection(
                "server=.;database=GEP;integrated security=true");
            SqlCommand objSqlCom = new SqlCommand(
                "DeleteEmployee", objSqlCon);
            //
            objSqlCom.CommandType = CommandType.StoredProcedure;
            //
            SqlParameter objSqlParam_Id = new SqlParameter("@Id", id);
            //
            objSqlParam_Id.Direction = ParameterDirection.Input;
            //
            objSqlCom.Parameters.Add(objSqlParam_Id);
            //
            objSqlCon.Open();
            int noOfRowsAffected = objSqlCom.ExecuteNonQuery();
            objSqlCon.Close();
            
            if (noOfRowsAffected > 0)
            {
                Console.WriteLine("Record deleted successfully.");
            }
            else
            {
                Console.WriteLine("Record couldn't be deleted.");
            }
            
        }

        internal void SearchEmployee()
        {
            int id;
            string name;
            int designationId;
            int departmentId;
            //
            Console.WriteLine("Enter Employee Id to Search the record.");
            Console.WriteLine("Enter Id");
            id = Convert.ToInt32(Console.ReadLine());
            //
            SqlConnection objSqlCon = new SqlConnection(
                "server=.;database=GEP;integrated security=true");
            SqlCommand objSqlCom = new SqlCommand(
                "SearchEmployee", objSqlCon);
            //
            objSqlCom.CommandType = CommandType.StoredProcedure;
            //
            SqlParameter objSqlParam_Id = new SqlParameter("@Id", id);
            SqlParameter objSqlParam_Name = new SqlParameter("@Name",SqlDbType.VarChar, 50);
            SqlParameter objSqlParam_DesignationId = new SqlParameter("@DesignationId",SqlDbType.Int);
            SqlParameter objSqlParam_DepartmentId = new SqlParameter("@DepartmentId", SqlDbType.Int);
            //
            objSqlParam_Id.Direction = ParameterDirection.Input;
            objSqlParam_Name.Direction = ParameterDirection.Output;
            objSqlParam_DesignationId.Direction = ParameterDirection.Output;
            objSqlParam_DepartmentId.Direction = ParameterDirection.Output;
            //
            objSqlCom.Parameters.Add(objSqlParam_Id);
            objSqlCom.Parameters.Add(objSqlParam_Name);
            objSqlCom.Parameters.Add(objSqlParam_DesignationId);
            objSqlCom.Parameters.Add(objSqlParam_DepartmentId);
            //
            objSqlCon.Open();
            objSqlCom.ExecuteNonQuery();
            //
            name = objSqlParam_Name.Value.ToString();
            designationId = Convert.ToInt32(objSqlParam_DesignationId.Value);
            departmentId = Convert.ToInt32(objSqlParam_DepartmentId.Value);
            //
            Console.WriteLine("Id: {0}, Name: {1}, DesignationId: {2}, DepartmentId: {3}"
            , id, name, designationId, departmentId);
            //
            objSqlCon.Close();
        }

        internal void ListEmployees()
        {
            Console.WriteLine("-----List of Employees-----");
            //
            SqlConnection objSqlCon = new SqlConnection(
                "server=.;database=GEP;integrated security=true");
            SqlCommand objSqlCom = new SqlCommand(
                "ListEmployees", objSqlCon);
            objSqlCom.CommandType = CommandType.StoredProcedure;
            objSqlCon.Open();
            SqlDataReader objSqlDataReader = objSqlCom.ExecuteReader();
            DataTable objDT;
            //
            if (objSqlDataReader.HasRows == true)
            {
                objDT = new DataTable();
                objDT.Load(objSqlDataReader);
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
            objSqlCon.Close();
        }
    }
}
