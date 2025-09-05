namespace TP03_EDD2.Models;

public class Disciplina
{
    private static int proximoId = 1;
        
    private Aluno[] _alunos = new Aluno[15];
    private int _numAlunos = 0;

    public int Id { get; private set; }
    public string Descricao { get; private set; }
    public int CursoId { get; private set; }
        
    public Aluno[] GetAlunos() => _alunos;
    public int GetNumAlunos() => _numAlunos;

    public Disciplina(string descricao, int cursoId)
    {
        Id = proximoId++;
        Descricao = descricao;
        CursoId = cursoId;
    }

    public bool MatricularAluno(Aluno aluno)
    {
        if (_numAlunos < 15)
        {
            for(int i = 0; i < _numAlunos; i++)
            {
                if (_alunos[i].Id == aluno.Id)
                {
                    return false;
                }
            }

            _alunos[_numAlunos] = aluno;
            _numAlunos++;
            aluno.AdicionarDisciplina(this);
            return true;
        }
        return false;
    }

    public bool DesmatricularAluno(Aluno aluno)
    {
        int index = -1;
        for (int i = 0; i < _numAlunos; i++)
        {
            if (_alunos[i].Id == aluno.Id)
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            for (int i = index; i < _numAlunos - 1; i++)
            {
                _alunos[i] = _alunos[i + 1];
            }
            _numAlunos--;
            _alunos[_numAlunos] = null;
            aluno.RemoverDisciplina(this);
            return true;
        }
        return false;
    }
}