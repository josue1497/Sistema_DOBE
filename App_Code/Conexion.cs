using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Clase para conectar a la base de datos
/// </summary>
public class Conexion
{
    protected SqlDataReader reader;
    protected SqlDataAdapter adapter;
    protected DataSet data;
    protected SqlConnection conexion = new SqlConnection();
    protected SqlCommand comando;
    public Conexion()
    {
        conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BD-UNIVConnectionString"].ConnectionString;
        conexion.Open();
        Console.Write("Conexion iniciada");
    }

    public Conexion(bool bdinterna)
    {
        conexion.ConnectionString = bdinterna ? ConfigurationManager.ConnectionStrings["BD-UNIVConnectionString"].ConnectionString 
            : ConfigurationManager.ConnectionStrings["SISTEMA_DOBEConnectionString"].ConnectionString;
        conexion.Open();
        Console.Write("Conexion iniciada");
    }

    public DataSet buscar(string query) {
        try
        {
            adapter = new SqlDataAdapter(query, conexion);
            SqlCommandBuilder execute = new SqlCommandBuilder(adapter);
            data = new DataSet();
            adapter.Fill(data, "datos");
            Console.Write("Consulta Exitosa!");
            return data;
        }
        catch (Exception e)
        {
            Console.Write("Error en consulta" + e.Message);
            conexion.Close();
            return null;
        }
        finally {
            conexion.Close();
        }
        }
    public DataTable search(string query)
    {
        try
        {
            adapter = new SqlDataAdapter(query, conexion);
            SqlCommandBuilder execute = new SqlCommandBuilder(adapter);
            DataTable result = new DataTable();
            adapter.Fill(result);
            Console.Write("Consulta Exitosa!");
            return result;
        }
        catch (Exception e)
        {
            Console.Write("Error en consulta" + e.Message);
            conexion.Close();
            return null;
        }
        finally
        {
            conexion.Close();
        }
    }

    public bool insert(string query) {
        bool pass = false;
        try {
           comando = new SqlCommand(query, conexion);

            if (comando.ExecuteNonQuery() > 0) {
                pass = true;
            }
            return pass;
        } catch (Exception e) {
            Console.WriteLine(e.Message);
            return false;
        } finally {
            conexion.Close();
           
        }
        }

    public bool update(string query)
    {
        bool pass = false;
        try
        {
            comando = new SqlCommand(query, conexion);

            if (comando.ExecuteNonQuery() > 0)
            {
                pass = true;
            }
            return pass;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        finally
        {
            conexion.Close();

        }
    }

    public bool delete(string query)
    {
        bool pass = false;
        try
        {
            comando = new SqlCommand(query, conexion);

            if (comando.ExecuteNonQuery() > 0)
            {
                pass = true;
            }
            return pass;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        finally
        {
            conexion.Close();

        }
    }

    public SqlCommand guardar(string query) {
        comando = new SqlCommand(query, conexion);
        return comando;
    }

    public void close() {
        conexion.Close();
    }

    public SqlCommand Comando {
        get { return this.comando; }
        set { value = comando; }
    }

}