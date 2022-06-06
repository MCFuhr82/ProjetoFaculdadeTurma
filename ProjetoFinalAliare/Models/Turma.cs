using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalAliare.Models
{
    [Table("Turma", Schema = "public")]
    public class Turma
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Semestre { get; private set; }
        [Required]
        public string Periodo { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual ICollection<Aluno> Alunos { get; private set; }
        
        public Turma() { }

        public Turma(string nome, int semestre)
        {
            Nome = nome;
            Semestre = semestre;
        }

        public void SetNome(string nome)
        {
            Nome = nome;
        }

        public void SetSemestre(int semestre)
        {
            Semestre = semestre;
        }

        public void SetPeriodo(string periodo)
        {
            Periodo = periodo;
        }

        public override string ToString()
        {
            return Nome + " " + Periodo;
        }

    }
}
