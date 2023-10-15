using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using UnityEngine;
using System.Data;

public class Achievements : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        connectToDatabase();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void connectToDatabase()
    {
        string connectionString = "Data Source=172.16.202.209;Initial Catalog=ProyectoToDoList;User ID=JuegosUnity;Password=JuegosUnityProyecto2023";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                // open connection
                connection.Open();

                Debug.Log("Connection Opened Successfully");
                // get tables from database
                DataTable tables = connection.GetSchema("Tables");

                // print tables data
                foreach (DataRow row in tables.Rows)
                {
                    foreach (DataColumn col in tables.Columns)
                    {
                        Debug.Log(col.ColumnName + " = " + row[col]);
                    }
                }

                // close connection
                connection.Close();

                Debug.Log("Connection Closed Successfully");

            }
            catch (Exception ex)
            {
                Debug.Log("Error: " + ex.Message);
            }
        }
    }
}
