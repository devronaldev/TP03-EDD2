using TP03_EDD2.Models;

namespace TP03_EDD2.Controllers;

public class Escola
{
    private Curso[] _cursos = new Curso[5];
    private int _numCursos = 0;

    public string Nome { get; private set; }
        
    public Curso[] GetCursos() => _cursos;
    public int GetNumCursos() => _numCursos;

    public Escola(string nome)
    {
        Nome = nome;
    }

    public bool AdicionarCurso(Curso curso)
    {
        if (_numCursos < 5)
        {
            _cursos[_numCursos] = curso;
            _numCursos++;
            return true;
        }
        return false;
    }

    public Curso PesquisarCurso(int idCurso)
    {
        for (int i = 0; i < _numCursos; i++)
        {
            if (_cursos[i].Id == idCurso)
            {
                return _cursos[i];
            }
        }
        return null;
    }

    public bool RemoverCurso(Curso curso)
    {
        if (curso.GetNumDisciplinas() > 0)
        {
            return false; // Não pode remover se tiver disciplinas
        }

        int index = -1;
        for (int i = 0; i < _numCursos; i++)
        {
            if (_cursos[i].Id == curso.Id)
            {
                index = i;
                break;
            }
        }

        if(index != -1)
        {
            for (int i = index; i < _numCursos - 1; i++)
            {
                _cursos[i] = _cursos[i + 1];
            }
            _numCursos--;
            _cursos[_numCursos] = null;
            return true;
        }
        return false;
    }
}