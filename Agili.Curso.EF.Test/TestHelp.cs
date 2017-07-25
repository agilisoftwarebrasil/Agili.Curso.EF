using Agili.Curso.EF.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agili.Curso.EF.Tests
{
    public static class TestHelp
    {
        public static string Add { get { return nameof(Add); } }
        public static string SaveChanges
        {
            get
            {
                return nameof(SaveChanges);
            }
        }
        private static Stopwatch _stopwatch;
        public static Stopwatch Stopwatch
        {
            get
            {
                if (_stopwatch == null)
                    _stopwatch = new Stopwatch();
                return _stopwatch;
            }
        }

        public static List<PessoaJuridica> GetPessoasJuridicas(int contatdor, int qtde = 2000)
        {
            var listaPessoa = new List<PessoaJuridica>();
            for (int i = 0; i < qtde; i++)
            {
                var valor = contatdor++.ToString().PadLeft(10, '0');
                listaPessoa.Add(new PessoaJuridica { Nome = "Tânia Jurídica", CNPJ = valor });
            }
            return listaPessoa;
        }

        public static List<PessoaJuridica> GetPessoasJuridicasComTelefone(int contatdor = 0, int qtde = 200)
        {
            var listaPessoa = new List<PessoaJuridica>();
            for (int i = 0; i < qtde; i++)
            {
                var valor = contatdor++.ToString().PadLeft(10, '0');
                listaPessoa.Add(GetPessoasJuridicaComTelefone(valor));
            }
            return listaPessoa;
        }

        public static PessoaJuridica GetPessoasJuridicaComTelefone(string cnpj = "00001")
        {
            return new PessoaJuridica
            {
                Nome = "Tânia Jurídica",
                CNPJ = cnpj,
                Telefones = GetTelefones()
            };
        }

        private static List<Telefone> GetTelefones()
        {
            var rnd = new Random();
            var telefones = new List<Telefone>();
            for (int i = 0; i < 50; i++)
                telefones.Add(new Telefone { Numero = rnd.Next(0, 9999999).ToString(), TipoTelefoneId = rnd.Next(1, 3) });
            return telefones;
        }

        public static List<PessoaFisica> GetPessoasFisica(int contatdor = 20000)
        {
            var listaPessoa = new List<PessoaFisica>();
            for (int i = 0; i < contatdor; i++)
            {
                var valor = i++.ToString().PadLeft(10, '0');
                listaPessoa.Add(new PessoaFisica { Nome = "Tânia Física", CPF = valor });
            }
            return listaPessoa;
        }
        public static void Stop(string category = "Testes")
        {
            Stopwatch.Stop();
            var ts = Stopwatch.Elapsed;
            var elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                   ts.Hours, ts.Minutes, ts.Seconds,
                   ts.Milliseconds / 10);
            Debug.WriteLine("Tempo: " + elapsedTime, category);
            System.IO.File.WriteAllText($"C:\\caidtemp\\{Guid.NewGuid().ToString()}.txt", $"Tempo: {elapsedTime} {category}");
        }

        public static void Restart()
        {
            Stopwatch.Restart();
        }
    }
}
