namespace TP03_EDD2.Models;

public class Curso
{
    public int IdCurso {get; set;}
    public string Descricao {get; set;}
    public Disciplina[] Disciplina {get; set;}

    public Curso(int id = -1)
    {
        Descricao = "";
        Disciplina = new Disciplina[12];
        for (int i = 0; i < 12; i++)
        {
            Disciplina[i] = new Disciplina();
        }

        id = -1;
    }

    public bool AdicionarDisciplina(Disciplina d)
    {
        return true;
    }

    public Disciplina PesquisarDisciplina(Disciplina d)
    {
        return new Disciplina();
    }

    public bool RemoverDisciplina(Disciplina d)
    {
        return true;
    }

    public bool Equals(Curso c)
    {
        if (Descricao == c.Descricao)
        {
            return true;
        }
        return false;
    }

    public bool IsEmpty()
    {
        return true;
    }
}