using TP03_EDD2.Models;

namespace TP03_EDD2.Controllers;

public class Escola
{
    public Curso[] cursos = new Curso[5];

    public Escola()
    {
        for (int i = 0; i < 5; i++)
        {
            cursos[i] = new Curso();
        }
    }
    
    public bool adicionarCurso(Curso c)
    {
        int newId = 1;
        if (cursos.Any(curso => curso.IdCurso != -1))
        {
            newId = cursos.Where(curso => curso.IdCurso != -1).Max(curso => curso.IdCurso) + 1;
        }
        
        c.IdCurso = newId;
        
        for (int i = 0; i < cursos.Length; i++)
        {
            if (cursos[i].IdCurso == -1)
            {
                cursos[i] = c;
                return true;
            }
        }
        return false;
    }

    public Curso? PesquisarCurso(Curso c)
    {
        for (int i = 0; i < cursos.Length; i++)
        {
            if (cursos[i].Equals(c))
            {
                return cursos[i];
            }
        }
        return null;
    }

    public bool RemoverCurso(Curso c)
    {
        for (int i = 0; i < cursos.Length; i++)
        {
            if (cursos[i].Equals(c))
            {
                cursos[i] = new Curso();
                return true;
            }
        }
        return false;
    }
}