using System;
using System.Data;
using MySql.Data.MySqlClient;
public class NewDbPractice
{
    public static void Main(string[] args)
    {
        try
        {
            string constring = "SERVER=localhost;DATABASE=lict;USER=root;PASSWORD='';";
            using(MySqlConnection con = new MySqlConnection(constring))
            {
                con.Open();

                /*create table 
                string create = "CREATE TABLE employee (id INT PRIMARY KEY,name VARCHAR(100),job VARCHAR(100), salary INT)";
                using (MySqlCommand ccmd = new MySqlCommand(create, con))
                {

                    if(ccmd.ExecuteNonQuery()>0) {

                        Console.WriteLine("Table Created Sucesfully");
                    }
                    else
                    {
                        Console.WriteLine("Failed");
                    }

                }
                */
                //insert data 
                int id = 2;
                string name = "basanta";
                string job = "HR";
                int salary = 11000;

                string insert = $"INSERT INTO employee(id,name,job,salary) VALUES ({id},'{name}','{job}',{salary})";

                using (MySqlCommand icmd = new MySqlCommand(insert, con))
                {

                    icmd.Parameters.AddWithValue("@id", id);
                    icmd.Parameters.AddWithValue("@name", name);
                    icmd.Parameters.AddWithValue("@job", job);
                    icmd.Parameters.AddWithValue("@salary", salary);


                    if (icmd.ExecuteNonQuery() > 0)
                    {


                        Console.WriteLine("insertion sucess");

                    }
                    else
                    {
                        Console.WriteLine("Insertion Failed");
                    }

                }

                string display = "SELECT * FROM employee";
                DataTable rtable = new DataTable();
                MySqlCommand dcmd = new MySqlCommand(display, con);
                using (MySqlDataAdapter da = new MySqlDataAdapter(dcmd))
                {
                    da.Fill(rtable);
                }
                foreach (DataRow row in rtable.Rows)
                {
                    Console.WriteLine("The id of Employee is " + row["id"]);
                    Console.WriteLine("The name of Employee is " + row["name"]);
                    Console.WriteLine("The job of Employee is " + row["job"]);
                    Console.WriteLine("The salary of Employee is " + row["salary"]);
                }

            }
        }catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
/*
 *   
 */