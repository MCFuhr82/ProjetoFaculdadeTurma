namespace ProjetoFinalAliare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FaculdadeTurma : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Aluno",
                c => new
                    {
                        Matricula = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        CPF = c.String(nullable: false),
                        Celular = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        CEP = c.String(nullable: false),
                        Endereco = c.String(nullable: false),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(),
                        Cidade = c.String(nullable: false),
                        Estado = c.String(nullable: false),
                        Curso_Id = c.Int(),
                        Turma_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Matricula)
                .ForeignKey("public.Curso", t => t.Curso_Id)
                .ForeignKey("public.Turma", t => t.Turma_Id)
                .Index(t => t.Curso_Id)
                .Index(t => t.Turma_Id);
            
            CreateTable(
                "public.Curso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        CargaHoraria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Turma",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Semestre = c.Int(nullable: false),
                        Periodo = c.String(nullable: false),
                        Curso_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Curso", t => t.Curso_Id)
                .Index(t => t.Curso_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.Turma", "Curso_Id", "public.Curso");
            DropForeignKey("public.Aluno", "Turma_Id", "public.Turma");
            DropForeignKey("public.Aluno", "Curso_Id", "public.Curso");
            DropIndex("public.Turma", new[] { "Curso_Id" });
            DropIndex("public.Aluno", new[] { "Turma_Id" });
            DropIndex("public.Aluno", new[] { "Curso_Id" });
            DropTable("public.Turma");
            DropTable("public.Curso");
            DropTable("public.Aluno");
        }
    }
}
