using ProjetoFinalAliare.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalAliare
{
    public static class TurmaController
    {
        
        //Select Turmas
        public static List<Turma> SelecionarTurmas()
        {
            using (var context = new Context())
            {
                var Turmas = context.Turma.Include(c => c.Curso).ToList();

                return Turmas;
            }
        }

        //Select Turma por Id
        public static Turma SelectTurmaPorId(int id)
        {
            using (var context = new Context())
            {
                var Turma = context.Turma.Where(x => x.Id == id).FirstOrDefault();

                return Turma;
            }
        }

        //Select Turma por Nome
        public static Turma SelectTurmaPorNome(string nome)
        {
            using (var context = new Context())
            {
                var Turma = context.Turma.Where(x => x.Nome == nome).FirstOrDefault();

                return Turma;
            }
        }

        //Delete Turma
        public static void DeleteTurma(int idTurma)
        {
            try
            {
                using (var context = new Context())
                {
                    var Turma = context.Turma.Where(x => x.Id == idTurma).FirstOrDefault();

                    context.Turma.Remove(Turma);
                    context.SaveChanges();
                }

            }
            catch (DbUpdateException)
            {
                throw;             
            }
        }

        //Inserir Turma
        public static void InserirTurma(Turma Turma)
        {
            using (var context = new Context())
            {
                context.Turma.Add(Turma);
                context.SaveChanges();
            }
        }

        //Update Turma
        public static void UpdateTurma(Turma Turma)
        {
            using (var context = new Context())
            {
                context.Entry(Turma).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        //Retorna uma lista de Alunos por Turma e Periodo
        public static List<Aluno> ListaAlunos(string nomeTurma, string periodo)
        {
            using (var context = new Context())
            {
                var Turma = context.Turma.Where(x => x.Nome == nomeTurma).Where(x => x.Periodo == periodo).FirstOrDefault();
                var alunos = Turma.Alunos.ToList();
                return alunos;
            }
        }

    }
}
