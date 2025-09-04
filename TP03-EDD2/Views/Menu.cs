namespace TP03_EDD2.Views;

public class Menu
{
    public int MaxOpt = 9;
    public void Init()
    {
        Options();
    }

    public void Options()
    {
        // O loop fará o menu continuar a ser exibido até que o usuário escolha uma opção válida.
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Opções:\n");
            Console.WriteLine("0. Sair.");
            Console.WriteLine("1. Adicionar curso.");
            Console.WriteLine("2. Pesquisar curso.");
            Console.WriteLine("3. Remover curso.");
            Console.WriteLine("4. Adicionar Disciplina no curso.");
            Console.WriteLine("5. Pesquisar Disciplina.");
            Console.WriteLine("6. Remover Disciplina do curso.");
            Console.WriteLine("7. Matricular Aluno.");
            Console.WriteLine("8. Remover aluno da disciplina.");
            Console.WriteLine("9. Pesquisar Aluno.\n");

            //Extras
            /*
             * 10. Mostrar todos Alunos
             * 11. Mostrar todos Cursos
             * 12. Mostrar todas Disciplinas
             */
            Console.Write("Digite o número da opção: ");
            var opt = Console.ReadLine();

            if (int.TryParse(opt, out int num) && num >= 0 && num <= MaxOpt)
            {
                SelectOption(num);
                break; 
            }
            else
            {
                Console.WriteLine($"\nOpção inválida. Por favor, digite um número de 0 a {MaxOpt}.");
                Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
                Console.ReadKey();
            }
        }
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
            case 7: EnrrollAluno(); break;
            case 8: DeleteAluno(); break;
            case 9: SearchAluno(); break;
        }
    }

    public void AddCurso()
    {
        
    }

    public void SearchCurso()
    {
        
    }

    public void DeleteCurso()
    {
        
    }
    
    public void AddDisciplina()
    {
        
    }

    public void SearchDisciplina()
    {
        
    }

    public void DeleteDisciplina()
    {
        
    }

    public void EnrrollAluno()
    {
        
    }

    public void DeleteAluno()
    {
        
    }
    
    public void SearchAluno()
    {
        
    }
}