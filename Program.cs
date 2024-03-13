using System;
using System.Data;
using MySql.Data.MySqlClient;
public class Mydb
{
    public static void Main(string[] args)
    {
        string Constring = "SERVER=localhost;DATABASE=lict;USER=root;PASSWORD=''";
        DataTable dataTable = new DataTable();

        using(MySqlConnection con = new MySqlConnection(Constring))
        {
            try
            {

                con.Open();
                Console.WriteLine("Connection is Established");


                Console.WriteLine("1.Insert\n2.Update\n3.Display \n4.Delete");
                int choice = Convert.ToInt32(Console.ReadLine());



                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the Student Name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the Student Rollno");
                        int rollno = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Student Faculty");
                        string faculty = Console.ReadLine();
                        Console.WriteLine("Enter the Student Address");
                        string address = Console.ReadLine();

                        string insertqry = $"INSERT INTO students(name,address,faculty,rollno) VALUES('{name}','{address}','{faculty}',{rollno})";
                        using(MySqlCommand insercommand = new MySqlCommand(insertqry, con))
                        {

                            insercommand.Parameters.AddWithValue("@name", name);
                            insercommand.Parameters.AddWithValue("@address", address);
                            insercommand.Parameters.AddWithValue("@faculty", faculty);
                            insercommand.Parameters.AddWithValue("@rollno", rollno);

                            if (insercommand.ExecuteNonQuery() > 0)
                            {
                                Console.WriteLine("Insertion Sucess");
                            }
                            else
                            {
                                Console.WriteLine("Insertion Failed");
                            }

                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter the Student Name");
                        string uname = Console.ReadLine();
                        Console.WriteLine("Enter the Student Rollno");
                        int urollno = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Student Faculty");
                        string ufaculty = Console.ReadLine();
                        Console.WriteLine("Enter the Student Address");
                        string uaddress = Console.ReadLine();

                        Console.WriteLine("Enter the Student Rollno to update");
                        int uid = Convert.ToInt32(Console.ReadLine());

                        string updatequery = $"UPDATE students SET name='{uname}', address='{uaddress}', faculty='{ufaculty}', rollno={urollno} WHERE rollno = {uid}";


                        using (MySqlCommand ucmd = new MySqlCommand(updatequery, con))
                        {

                            ucmd.Parameters.AddWithValue("@uname", uname);
                            ucmd.Parameters.AddWithValue("@address", uaddress);
                            ucmd.Parameters.AddWithValue("@ufaculty", ufaculty);
                            ucmd.Parameters.AddWithValue("@urollno", urollno);

                            if (ucmd.ExecuteNonQuery() > 0)
                            {

                                Console.WriteLine("Update Sucess");
                            }
                            else
                            {
                                Console.WriteLine("Update Failed");
                            }

                        }
                        break; 
                    case 3:
                        string readquery = "SELECT * FROM students";

                        MySqlCommand cmd = new MySqlCommand(readquery, con);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }

                        foreach (DataRow row in dataTable.Rows)
                        {
                            Console.WriteLine("The student name is :" + row["name"]);
                            Console.WriteLine("The student Roll NO is :" + row["rollno"]);
                            Console.WriteLine("The student Faculty is :" + row["faculty"]);
                            Console.WriteLine("The student Address is :" + row["address"]);
                            Console.WriteLine();
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter the Student Rollno to delete");
                        int did = Convert.ToInt32(Console.ReadLine());

                        string delquery = $"DELETE FROM students WHERE rollno = {did}";

                        using(MySqlCommand delcmd = new MySqlCommand(delquery, con))
                        {

                            if (delcmd.ExecuteNonQuery() > 0)
                            {

                                Console.WriteLine("Delete Sucess");
                            }
                            else
                            {
                                Console.WriteLine("Delete Failed");
                            }
                        }



                        break;
                    default:
                        Console.WriteLine("Enter valid Choice");
                        break;
                }
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
        }

    }
}