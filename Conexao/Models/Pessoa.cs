using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;


namespace Conexao.Models
{
    public class Pessoa
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }


        public List<Pessoa> Mostrar()
        {
            var strQuery = "";
            strQuery += "SELECT * FROM CRUD ";
            SqlConnection minhaConexao = new SqlConnection
                (ConfigurationManager.ConnectionStrings["InscricaoConfig"].ConnectionString);
            minhaConexao.Open();
            var cmdComando = new SqlCommand(strQuery, minhaConexao);

            var RetornoSQL = cmdComando.ExecuteReader();
            var inscritos = new List<Pessoa>();
            while (RetornoSQL.Read())
            {
                var temObjeto = new Pessoa()
                {
                    //Id = int.Parse(RetornoSQL["InscrisaoId"].ToString()),
                    Id = RetornoSQL["Id"].ToString(),
                    Nome = RetornoSQL["Nome"].ToString(),
                    Email = RetornoSQL["Email"].ToString()
                };
                inscritos.Add(temObjeto);

            }
            RetornoSQL.Close();
            minhaConexao.Close();
            return inscritos;
        }

        public void Insert(Pessoa pessoa)
        {
            //pessoa.Nome = "Ana";
            //pessoa.Email = "ana@email";
            var strQuery = "";
                strQuery += "INSERT INTO CRUD (Nome, Email)";
                strQuery += string.Format("VALUES ('{0}','{1}')", pessoa.Nome, pessoa.Email);
            SqlConnection minhaConexao = new SqlConnection
                (ConfigurationManager.ConnectionStrings["InscricaoConfig"].ConnectionString);
            minhaConexao.Open();
            var cmdComando = new SqlCommand(strQuery, minhaConexao);
            cmdComando.ExecuteNonQuery();
            minhaConexao.Close();
        }

        public void Delete(Pessoa pessoa)
        {
            //id = "6";
            var strQuery = "";
            strQuery += "DELETE FROM CRUD ";
            strQuery += string.Format("WHERE Id = ('{0}')", pessoa.Id);

            SqlConnection minhaConexao = new SqlConnection
                (ConfigurationManager.ConnectionStrings["InscricaoConfig"].ConnectionString);
            minhaConexao.Open();
            var cmdComando = new SqlCommand(strQuery, minhaConexao);
            cmdComando.ExecuteNonQuery();
            minhaConexao.Close();
        }

        public Pessoa Details(string id)
        {
            //strQuery += string.Format("WHERE Id = ('{0}')", id);
            var strQuery = "";
            strQuery += "SELECT * FROM CRUD ";
            strQuery += string.Format("WHERE Id = ('{0}')", id);
            SqlConnection minhaConexao = new SqlConnection
                (ConfigurationManager.ConnectionStrings["InscricaoConfig"].ConnectionString);
            minhaConexao.Open();
            var cmdComando = new SqlCommand(strQuery, minhaConexao);

            var RetornoSQL = cmdComando.ExecuteReader();
            var inscritos = new Pessoa();
            while (RetornoSQL.Read())
            {
                var temObjeto = new Pessoa()
                {
                    //Id = int.Parse(RetornoSQL["InscrisaoId"].ToString()),
                    Id = RetornoSQL["Id"].ToString(),
                    Nome = RetornoSQL["Nome"].ToString(),
                    Email = RetornoSQL["Email"].ToString()
                };
                inscritos=temObjeto;
               
            }
            RetornoSQL.Close();
            minhaConexao.Close();
            return inscritos;
        }

        public void Update(Pessoa pessoa)
        {
            //pessoa.Id = "45";
            var strQuery = "";
            strQuery += "UPDATE CRUD SET ";
            strQuery += string.Format("Nome = ('{0}'), Email = ('{1}') WHERE Id = ('{2}')", pessoa.Nome, pessoa.Email, pessoa.Id);

            SqlConnection minhaConexao = new SqlConnection
                (ConfigurationManager.ConnectionStrings["InscricaoConfig"].ConnectionString);
            minhaConexao.Open();
            var cmdComando = new SqlCommand(strQuery, minhaConexao);
            cmdComando.ExecuteNonQuery();
            minhaConexao.Close();
        }
    }
}