using System;    
using System.Collections.Generic;    
using System.Data;    
using System.Data.SqlClient;    
using System.Linq;    
using System.Threading.Tasks;        

namespace MVCAdoDemo.Models    
{        
    public class EmpregadoDataAccessLayer        
    {            
        string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=TecWeb";                
        //Para ver todos os detalhes do empregado              
        public IEnumerable<Empregado> GetAllEmpregados()            
        {                
            List<Empregado> lstempregado = new List<Empregado>();                    
            using (SqlConnection con = new SqlConnection(connectionString))                
            {                    
                SqlCommand cmd = new SqlCommand("spGetAllEmpregados", con);                    
                cmd.CommandType = CommandType.StoredProcedure;                        
                con.Open();                    
                SqlDataReader rdr = cmd.ExecuteReader();                        
                while (rdr.Read())                    
                {                        
                    Empregado empregado = new Empregado();                            
                    empregado.ID = Convert.ToInt32(rdr["empregadoID"]);                        
                    empregado.Nome = rdr["Nome"].ToString();                        
                    empregado.Genero = rdr["Genero"].ToString();                        
                    empregado.Departamento = rdr["Departamento"].ToString();                        
                    empregado.Cidade = rdr["Cidade"].ToString();                            
                    lstempregado.Add(empregado);                    
                }                    
                con.Close();                
            }                
            return lstempregado;            
        }                
        //Para adicionar um novo empregado              
        public void AddEmpregado(Empregado empregado)            
        {                
            using (SqlConnection con = new SqlConnection(connectionString))                
            {                    
                SqlCommand cmd = new SqlCommand("spAddEmpregado", con);                    
                cmd.CommandType = CommandType.StoredProcedure;                        
                cmd.Parameters.AddWithValue("@Nome", empregado.Nome);                   
                cmd.Parameters.AddWithValue("@Genero", empregado.Genero);                    
                cmd.Parameters.AddWithValue("@Departamento", empregado.Departamento);                    
                cmd.Parameters.AddWithValue("@Cidade", empregado.Cidade);                        
                con.Open();                    
                cmd.ExecuteNonQuery();                    
                con.Close();                
            }            
        }                
        //Para atualizar os dados de um empregado especifico          
        public void UpdateEmpregado(Empregado empregado)            
        {                
            using (SqlConnection con = new SqlConnection(connectionString))                
            {                    
                SqlCommand cmd = new SqlCommand("spUpdateEmpregado", con);                    
                cmd.CommandType = CommandType.StoredProcedure;                        
                cmd.Parameters.AddWithValue("@EmpId", empregado.ID);     //Conferir EmpId               
                cmd.Parameters.AddWithValue("@Nome", empregado.Nome);                    
                cmd.Parameters.AddWithValue("@Genero", empregado.Genero);                    
                cmd.Parameters.AddWithValue("@Departamento", empregado.Departamento);                    
                cmd.Parameters.AddWithValue("@Cidade", empregado.Cidade);                        
                con.Open();                    
                cmd.ExecuteNonQuery();                    
                con.Close();                
            }            
        }                
        //Mostra os detalhes um empregado especifico            
        public Empregado GetEmpregadoData(int id)            
        {                
            Empregado empregado = new Empregado();                    
            using (SqlConnection con = new SqlConnection(connectionString))                
            {                    
                string sqlQuery = "SELECT * FROM tblEmpregado WHERE EmpregadoID= " + id;                    
                SqlCommand cmd = new SqlCommand(sqlQuery, con);                        
                con.Open();                    
                SqlDataReader rdr = cmd.ExecuteReader();                        
                while (rdr.Read())                    
                {                        
                    empregado.ID = Convert.ToInt32(rdr["EmpregadoID"]);                        
                    empregado.Nome = rdr["Nome"].ToString();                        
                    empregado.Genero = rdr["Genero"].ToString();                        
                    empregado.Departamento = rdr["Departamento"].ToString();                        
                    empregado.Cidade = rdr["Cidade"].ToString();                    
                }                
            }                
            return empregado;            
        }                
        //Para deletar um empregado especifico            
        public void DeleteEmpregado(int id)            
        {                    
            using (SqlConnection con = new SqlConnection(connectionString))                
            {                    
                SqlCommand cmd = new SqlCommand("spDeleteEmpregado", con);                    
                cmd.CommandType = CommandType.StoredProcedure;                        
                cmd.Parameters.AddWithValue("@EmpId", id);                        
                con.Open();                    
                cmd.ExecuteNonQuery();                    
                con.Close();                
            }            
        }        
    }    
}
