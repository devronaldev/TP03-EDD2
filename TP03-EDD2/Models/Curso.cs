namespace TP03_EDD2.Models;

public class Curso
{
    private static int proximoId = 1;

    private Disciplina[] _disciplinas = new Disciplina[12];
    private int _numDisciplinas = 0;
    
    public int Id { get; private set; }
    public string Descricao { get; set; }

    public Disciplina[] GetDisciplinas() => _disciplinas;
    public int GetNumDisciplinas() => _numDisciplinas;


    public Curso(string descricao)
    {
        Id = proximoId++;
        Descricao = descricao;
    }

    public bool AdicionarDisciplina(Disciplina disciplina)
    {
        if (_numDisciplinas < 12)
        {
            _disciplinas[_numDisciplinas] = disciplina;
            _numDisciplinas++;
            return true;
        }
        return false;
    }

    public Disciplina PesquisarDisciplina(int idDisciplina)
    {
        for (int i = 0; i < _numDisciplinas; i++)
        {
            if (_disciplinas[i].Id == idDisciplina)
            {
                return _disciplinas[i];
            }
        }
        return null;
    }

    public bool RemoverDisciplina(Disciplina disciplina)
    {
        if (disciplina.GetNumAlunos() > 0)
        {
            return false;
        }

        int index = -1;
        for (int i = 0; i < _numDisciplinas; i++)
        {
            if (_disciplinas[i].Id == disciplina.Id)
            {
                index = i;
                break;
            }
        }
        
        if(index != -1)
        {
             for (int i = index; i < _numDisciplinas - 1; i++)
            {
                _disciplinas[i] = _disciplinas[i + 1];
            }
            _numDisciplinas--;
            _disciplinas[_numDisciplinas] = null;
            return true;
        }
        return false;
    }
}