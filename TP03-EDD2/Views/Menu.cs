namespace TP03_EDD2.Views;
using Models;
using Controllers;


public class Menu
{
    // Instâncias estáticas para serem acessadas por todos os métodos do menu
    private static Escola escola = new Escola("Escola de Tecnologia .NET");
    private static Aluno[] todosOsAlunos = new Aluno[100]; // Array para armazenar todos os alunos
    private static int numTotalAlunos = 0;

    public int MaxOpt = 9;

    public void Init()
    {
        while(true)
        {
             Options();
        }
    }

    public void Options()
    {
        Console.Clear();
        Console.WriteLine($"--- Bem-vindo à {escola.Nome} ---\n");
        Console.WriteLine("Opções:\n");
        Console.WriteLine("0. Sair.");
        Console.WriteLine("1. Adicionar curso.");
        Console.WriteLine("2. Pesquisar curso.");
        Console.WriteLine("3. Remover curso.");
        Console.WriteLine("4. Adicionar Disciplina no curso.");
        Console.WriteLine("5. Pesquisar Disciplina.");
        Console.WriteLine("6. Remover Disciplina do curso.");
        Console.WriteLine("7. Matricular Aluno na disciplina.");
        Console.WriteLine("8. Remover aluno da disciplina.");
        Console.WriteLine("9. Pesquisar Aluno.\n");
        
        Console.Write("Digite o número da opção: ");
        var opt = Console.ReadLine();

        if (int.TryParse(opt, out int num) && num >= 0 && num <= MaxOpt)
        {
            SelectOption(num);
        }
        else
        {
            Console.WriteLine($"\nOpção inválida. Por favor, digite um número de 0 a {MaxOpt}.");
        }
        
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
    
    public void SelectOption(int option)
    {
        switch (option)
        {
            case 0: Environment.Exit(0); break;
            case 1: AddCurso(); break; 
            case 2: SearchCurso(); break;
            case 3: DeleteCurso(); break;
            case 4: AddDisciplina(); break;
            case 5: SearchDisciplina(); break; 
            case 6: DeleteDisciplina(); break;
            case 7: EnrollAluno(); break;
            case 8: DeleteAlunoFromDisciplina(); break;
            case 9: SearchAluno(); break;
        }
    }
    
    // --- MÉTODOS DE LEITURA AUXILIARES ---
    private int LerId(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            if (int.TryParse(Console.ReadLine(), out int id) && id > 0)
            {
                return id;
            }
            Console.WriteLine("ID inválido. Por favor, insira um número inteiro positivo.");
        }
    }

    // --- IMPLEMENTAÇÃO DOS MÉTODOS ---

    public void AddCurso()
    {
        Console.Clear();
        Console.WriteLine("--- Adicionar Novo Curso ---\n");
        if (escola.GetNumCursos() >= 5)
        {
            Console.WriteLine("Erro: A escola já atingiu o limite máximo de 5 cursos.");
            return;
        }
        Console.Write("Digite a descrição do novo curso: ");
        string descCurso = Console.ReadLine();
        Curso novoCurso = new Curso(descCurso);
        if(escola.AdicionarCurso(novoCurso))
        {
            Console.WriteLine($"\nSucesso: Curso '{novoCurso.Descricao}' adicionado com ID {novoCurso.Id}.");
        }
    }

    public void SearchCurso()
    {
        Console.Clear();
        Console.WriteLine("--- Pesquisar Curso ---\n");
        int idCurso = LerId("Digite o ID do curso a ser pesquisado: ");
        Curso curso = escola.PesquisarCurso(idCurso);
        if (curso != null)
        {
            Console.WriteLine($"\nID: {curso.Id}, Descrição: {curso.Descricao}");
            if (curso.GetNumDisciplinas() > 0)
            {
                Console.WriteLine("Disciplinas associadas:");
                for (int i = 0; i < curso.GetNumDisciplinas(); i++)
                {
                    Disciplina d = curso.GetDisciplinas()[i];
                    Console.WriteLine($"  - ID: {d.Id}, Descrição: {d.Descricao}");
                }
            }
            else
            {
                Console.WriteLine("Nenhuma disciplina associada a este curso.");
            }
        }
        else
        {
            Console.WriteLine("Erro: Curso não encontrado.");
        }
    }

    public void DeleteCurso()
    {
        Console.Clear();
        Console.WriteLine("--- Remover Curso ---\n");
        int idCurso = LerId("Digite o ID do curso a ser removido: ");
        Curso curso = escola.PesquisarCurso(idCurso);
        if (curso != null)
        {
            if (escola.RemoverCurso(curso))
            {
                Console.WriteLine($"Sucesso: Curso '{curso.Descricao}' removido.");
            }
            else
            {
                Console.WriteLine("Erro: Não é possível remover o curso. Verifique se ele não possui disciplinas associadas.");
            }
        }
        else
        {
            Console.WriteLine("Erro: Curso não encontrado.");
        }
    }
    
    public void AddDisciplina()
    {
        Console.Clear();
        Console.WriteLine("--- Adicionar Disciplina em Curso ---\n");
        int idCurso = LerId("Digite o ID do curso para adicionar a disciplina: ");
        Curso curso = escola.PesquisarCurso(idCurso);
        if (curso != null)
        {
            if (curso.GetNumDisciplinas() >= 12)
            {
                Console.WriteLine("Erro: Este curso já atingiu o limite máximo de 12 disciplinas.");
                return;
            }
            Console.Write("Digite a descrição da nova disciplina: ");
            string descDisciplina = Console.ReadLine();
            Disciplina novaDisciplina = new Disciplina(descDisciplina, curso.Id);
            curso.AdicionarDisciplina(novaDisciplina);
            Console.WriteLine($"\nSucesso: Disciplina '{novaDisciplina.Descricao}' (ID: {novaDisciplina.Id}) adicionada ao curso '{curso.Descricao}'.");
        }
        else
        {
            Console.WriteLine("Erro: Curso não encontrado.");
        }
    }

    public void SearchDisciplina()
    {
        Console.Clear();
        Console.WriteLine("--- Pesquisar Disciplina ---\n");
        int idCurso = LerId("Digite o ID do curso da disciplina: ");
        Curso curso = escola.PesquisarCurso(idCurso);
        if (curso != null)
        {
            int idDisciplina = LerId("Digite o ID da disciplina a ser pesquisada: ");
            Disciplina disciplina = curso.PesquisarDisciplina(idDisciplina);
            if (disciplina != null)
            {
                Console.WriteLine($"\nID: {disciplina.Id}, Descrição: {disciplina.Descricao}");
                if (disciplina.GetNumAlunos() > 0)
                {
                    Console.WriteLine("Alunos matriculados:");
                    for (int i = 0; i < disciplina.GetNumAlunos(); i++)
                    {
                        Aluno a = disciplina.GetAlunos()[i];
                        Console.WriteLine($"  - ID: {a.Id}, Nome: {a.Nome}");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum aluno matriculado nesta disciplina.");
                }
            }
            else
            {
                Console.WriteLine("Erro: Disciplina não encontrada neste curso.");
            }
        }
        else
        {
            Console.WriteLine("Erro: Curso não encontrado.");
        }
    }

    public void DeleteDisciplina()
    {
        Console.Clear();
        Console.WriteLine("--- Remover Disciplina do Curso ---\n");
        int idCurso = LerId("Digite o ID do curso da disciplina: ");
        Curso curso = escola.PesquisarCurso(idCurso);
        if (curso != null)
        {
            int idDisciplina = LerId("Digite o ID da disciplina a ser removida: ");
            Disciplina disciplina = curso.PesquisarDisciplina(idDisciplina);
            if (disciplina != null)
            {
                if (curso.RemoverDisciplina(disciplina))
                {
                    Console.WriteLine($"Sucesso: Disciplina '{disciplina.Descricao}' removida do curso.");
                }
                else
                {
                    Console.WriteLine("Erro: Não é possível remover. Verifique se a disciplina não possui alunos matriculados.");
                }
            }
            else
            {
                Console.WriteLine("Erro: Disciplina não encontrada neste curso.");
            }
        }
        else
        {
            Console.WriteLine("Erro: Curso não encontrado.");
        }
    }

    public void EnrollAluno()
    {
        Console.Clear();
        Console.WriteLine("--- Matricular Aluno em Disciplina ---\n");
        
        // Passo 1: Obter o aluno (ou criar um novo)
        int idAluno = LerId("Digite o ID do aluno: ");
        Aluno aluno = null;
        for(int i = 0; i < numTotalAlunos; i++)
        {
            if(todosOsAlunos[i].Id == idAluno)
            {
                aluno = todosOsAlunos[i];
                break;
            }
        }

        if (aluno == null)
        {
            Console.WriteLine("Aluno não encontrado. Criando um novo cadastro...");
            Console.Write("Digite o nome do novo aluno: ");
            string nomeAluno = Console.ReadLine();
            int idCursoAluno = LerId($"Digite o ID do curso para o aluno '{nomeAluno}': ");

            if (escola.PesquisarCurso(idCursoAluno) == null)
            {
                Console.WriteLine("Erro: O curso informado não existe. Matrícula cancelada.");
                return;
            }
            aluno = new Aluno(nomeAluno, idCursoAluno);
            todosOsAlunos[numTotalAlunos] = aluno;
            numTotalAlunos++;
            Console.WriteLine($"\nSucesso: Aluno '{aluno.Nome}' criado com ID {aluno.Id} e associado ao curso ID {aluno.CursoId}.");
        }
        
        Console.WriteLine($"\nMatriculando o aluno: {aluno.Nome}");

        if (!aluno.PodeMatricularEmDisciplina())
        {
            Console.WriteLine("Erro: Este aluno já está matriculado no máximo de 6 disciplinas.");
            return;
        }

        // Passo 2: Encontrar a disciplina e matricular
        int idCursoDisciplina = LerId("Digite o ID do curso que contém a disciplina desejada: ");
        
        if (idCursoDisciplina != aluno.CursoId)
        {
            Console.WriteLine("Erro: O aluno só pode se matricular em disciplinas do seu próprio curso.");
            return;
        }

        Curso curso = escola.PesquisarCurso(idCursoDisciplina);
        if (curso != null)
        {
            int idDisciplina = LerId("Digite o ID da disciplina: ");
            Disciplina disciplina = curso.PesquisarDisciplina(idDisciplina);
            if (disciplina != null)
            {
                if (disciplina.MatricularAluno(aluno))
                {
                    Console.WriteLine($"Sucesso: Aluno '{aluno.Nome}' matriculado na disciplina '{disciplina.Descricao}'.");
                }
                else
                {
                    Console.WriteLine("Erro: Não foi possível matricular. A disciplina pode estar cheia ou o aluno já está matriculado.");
                }
            }
            else
            {
                Console.WriteLine("Erro: Disciplina não encontrada.");
            }
        }
        else
        {
            Console.WriteLine("Erro: Curso não encontrado.");
        }
    }

    // Renomeei o método para ser mais claro
    public void DeleteAlunoFromDisciplina()
    {
        Console.Clear();
        Console.WriteLine("--- Remover Aluno da Disciplina ---\n");
        int idAluno = LerId("Digite o ID do aluno: ");
        Aluno aluno = null;
        for(int i = 0; i < numTotalAlunos; i++)
        {
            if(todosOsAlunos[i].Id == idAluno)
            {
                aluno = todosOsAlunos[i];
                break;
            }
        }
        
        if (aluno != null)
        {
            if (aluno.GetNumDisciplinasMatriculadas() == 0)
            {
                Console.WriteLine("Este aluno não está matriculado em nenhuma disciplina.");
                return;
            }

            Console.WriteLine("O aluno está matriculado nas seguintes disciplinas:");
            for (int i = 0; i < aluno.GetNumDisciplinasMatriculadas(); i++)
            {
                var d = aluno.GetDisciplinasMatriculadas()[i];
                Console.WriteLine($"  - ID: {d.Id}, Descrição: {d.Descricao}");
            }

            int idDisciplinaRemover = LerId("\nDigite o ID da disciplina para remover o aluno: ");
            
            Disciplina disciplinaEncontrada = null;
            for(int i = 0; i < aluno.GetNumDisciplinasMatriculadas(); i++)
            {
                if(aluno.GetDisciplinasMatriculadas()[i].Id == idDisciplinaRemover)
                {
                    disciplinaEncontrada = aluno.GetDisciplinasMatriculadas()[i];
                    break;
                }
            }
            
            if (disciplinaEncontrada != null)
            {
                if (disciplinaEncontrada.DesmatricularAluno(aluno))
                {
                    Console.WriteLine($"\nSucesso: Aluno '{aluno.Nome}' removido da disciplina '{disciplinaEncontrada.Descricao}'.");
                }
                else
                {
                    Console.WriteLine("\nErro: Falha ao tentar remover o aluno.");
                }
            }
            else
            {
                Console.WriteLine("\nErro: O aluno não está matriculado na disciplina com o ID informado.");
            }
        }
        else
        {
            Console.WriteLine("Erro: Aluno não encontrado.");
        }
    }
    
    public void SearchAluno()
    {
        Console.Clear();
        Console.WriteLine("--- Pesquisar Aluno ---\n");
        int idAluno = LerId("Digite o ID do aluno a ser pesquisado: ");
        Aluno aluno = null;
        for(int i = 0; i < numTotalAlunos; i++)
        {
            if(todosOsAlunos[i].Id == idAluno)
            {
                aluno = todosOsAlunos[i];
                break;
            }
        }
        
        if (aluno != null)
        {
            Console.WriteLine($"\nID: {aluno.Id}");
            Console.WriteLine($"Nome: {aluno.Nome}");
            Curso cursoAluno = escola.PesquisarCurso(aluno.CursoId);
            Console.WriteLine($"Curso: {(cursoAluno != null ? cursoAluno.Descricao : "Não definido")}");
            
            if (aluno.GetNumDisciplinasMatriculadas() > 0)
            {
                Console.WriteLine("Disciplinas em que está matriculado:");
                for (int i = 0; i < aluno.GetNumDisciplinasMatriculadas(); i++)
                {
                    Disciplina d = aluno.GetDisciplinasMatriculadas()[i];
                    Console.WriteLine($"  - ID: {d.Id}, Descrição: {d.Descricao}");
                }
            }
            else
            {
                Console.WriteLine("O aluno não está matriculado em nenhuma disciplina.");
            }
        }
        else
        {
            Console.WriteLine("Erro: Aluno não encontrado.");
        }
    }
}