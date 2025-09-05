namespace TP03_EDD2.Models;

public class Aluno
{
    private static int proximoId = 1;
    private Disciplina[] _disciplinasMatriculadas = new Disciplina[6];
    private int _numDisciplinasMatriculadas = 0;

    public int Id { get; private set; }
    public string Nome { get; set; }
    public int CursoId { get; private set; }
    
    public Disciplina[] GetDisciplinasMatriculadas() => _disciplinasMatriculadas;
    public int GetNumDisciplinasMatriculadas() => _numDisciplinasMatriculadas;

    public Aluno(string nome, int cursoId)
    {
        Id = proximoId++;
        Nome = nome;
        CursoId = cursoId;
    }

    public bool PodeMatricularEmDisciplina()
    {
        return _numDisciplinasMatriculadas < 6;
    }

    public void AdicionarDisciplina(Disciplina disciplina)
    {
        if (_numDisciplinasMatriculadas < _disciplinasMatriculadas.Length)
        {
            _disciplinasMatriculadas[_numDisciplinasMatriculadas] = disciplina;
            _numDisciplinasMatriculadas++;
        }
    }

    public void RemoverDisciplina(Disciplina disciplina)
    {
        int index = -1;
        for (int i = 0; i < _numDisciplinasMatriculadas; i++)
        {
            if (_disciplinasMatriculadas[i].Id == disciplina.Id)
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            for (int i = index; i < _numDisciplinasMatriculadas - 1; i++)
            {
                _disciplinasMatriculadas[i] = _disciplinasMatriculadas[i + 1];
            }
            _numDisciplinasMatriculadas--;
            _disciplinasMatriculadas[_numDisciplinasMatriculadas] = null;
        }
    }
}