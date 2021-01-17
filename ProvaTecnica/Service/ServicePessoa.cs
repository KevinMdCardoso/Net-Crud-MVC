using ProvaTecnica.Models;
using System;
using System.IO;
using System.Web.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace ProvaTecnica.Service
{
    public class ServicePessoa
    {
        private string pathFile = @"c:\temp\Pessoa.txt";
        private Context db = new Context();

        public Pessoa CriaPessoa(Pessoa pessoa)
        {
            List<Pessoa> pessoas = ListaTodos();
            int novoId = 1;
            if (pessoas.Count() > 0)
                novoId = pessoas.Max(item => item.Id) + 1;            
           
            pessoa.Id = novoId; 
            pessoas.Add(pessoa);
            RegistraLog("Pessoa Criada", "" , JsonSerializer.Serialize(pessoa));
            gravaBancoTXT(pessoas);
            return pessoa;
        }

        public List<Pessoa> ListaTodos()
        {
            string jsonString = File.ReadAllText(pathFile);
            List<Pessoa> Pessoas = new List<Pessoa>();
            if (jsonString != "")
            {
                Pessoas = JsonSerializer.Deserialize<List<Pessoa>>(jsonString);
            }

            Pessoas.Sort(delegate (Pessoa x, Pessoa y)
            {
                if (x.Nome == null && y.Nome == null)
                    return 0;
                else if (x.Nome == null)
                    return -1;
                else if (y.Nome == null)
                    return 1;
                else
                    return x.Nome.CompareTo(y.Nome);
            });

            return Pessoas;
        }

        public Pessoa BuscaPessoa(int? id)
        {
            Pessoa pessoa = new Pessoa();
            List<Pessoa> pessoas = ListaTodos();
            if (pessoas.Count() > 0)
                pessoa = pessoas.Find(item => item.Id == id);

            return pessoa;
        }

        public Pessoa EditarPessoa(Pessoa pessoa)
        {
            List<Pessoa> pessoas = ListaTodos();
            Pessoa AuxPessoa = pessoas.FirstOrDefault(item => item.Id == pessoa.Id);
            RegistraLog("Pessoa Alterada", JsonSerializer.Serialize(AuxPessoa), JsonSerializer.Serialize(pessoa));
            if (AuxPessoa != null)
            {
                AuxPessoa.Nome  = pessoa.Nome;
                AuxPessoa.Email = pessoa.Email;
                AuxPessoa.Cpf   = pessoa.Cpf;
                AuxPessoa.Cidade = pessoa.Cidade;
                AuxPessoa.Estado = pessoa.Estado;
                AuxPessoa.DataNascimento = pessoa.DataNascimento;
            }           
            gravaBancoTXT(pessoas);
            return pessoa;
        }

        public Pessoa DeletarPessoa(Pessoa pessoa)
        {   
            List<Pessoa> pessoas = ListaTodos();
            pessoas.RemoveAt(pessoas.FindIndex(item => item.Id == pessoa.Id));
            RegistraLog("Pessoa Deletada", JsonSerializer.Serialize(pessoa), "");
            gravaBancoTXT(pessoas);
            return pessoa;
        }

        private void gravaBancoTXT(List<Pessoa> pessoas)
        {
            string jsonString = JsonSerializer.Serialize(pessoas);
            File.WriteAllText(pathFile, jsonString);
        }

        private void RegistraLog(string acao, string antes, string depois) 
        {
            Log log = new Log() { Momento = DateTime.Now, Acao = acao,  Antes = antes, Depois = depois };
            db.Logs.Add(log);
            db.SaveChanges();
        }
    }
}