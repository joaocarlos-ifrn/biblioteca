using System;
using System.Globalization;
using System.Threading;

class Program {

  private static Aluno alunoLogin = null;

  public static void Main() {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

    Console.WriteLine("Bem-vindo à biblioteca");
    int op = 0;
    int perfil = 0;
    do {
      try {
        if (perfil == 0) {
          op = 0;
          perfil = MenuUsuario();
        }
        if (perfil == 1) {
          op = MenuAdmin();
          switch(op) {
            case 1 : DisciplinaInserir(); break;
            case 2 : DisciplinaListar(); break;
            case 3 : DisciplinaAtualizar(); break;
            case 4 : DisciplinaExcluir(); break;
            case 5 : LivroInserir(); break;
            case 6 : LivroListar(); break;
            case 7 : LivroAtualizar(); break;
            case 8 : LivroExcluir(); break;
            case 9 : AlunoInserir(); break;
            case 10: AlunoListar(); break;
            case 11: AlunoAtualizar(); break;
            case 12: AlunoExcluir(); break;
            case 13: OperacaoInserir(); break;
            case 14: OperacaoListar(); break;
            case 15: OperacaoAtualizar(); break;
            case 16: OperacaoExcluir(); break;
            case 17: ConsultaAbrirDiario(); break;
            case 18: ConsultaVerDiario(); break;
            case 99: perfil = 0; break;
          }
        }
        if (perfil == 2 && alunoLogin == null) {
          op = MenuAlunoLogin();
          switch(op) {
            case 1 : AlunoLogin(); break;
            case 99: perfil = 0; break;
          }
        }
        if (perfil == 2 && alunoLogin != null) {
          op = MenuAlunoLogout();
          switch(op) {
            case 1 : AlunoListarHorariosDisponiveis(); break;
            case 2 : AlunoAgendarConsulta(); break;
            case 3 : AlunoListarConsultas(); break;
            case 4 : AlunoListarLivros(); break;
            case 99: AlunoLogout(); break;
          }
        }
      }
      catch (Exception erro) {
        op = -1;
        Console.WriteLine("Erro: " + erro.Message);
      }
    } while (op != 0);
  }

  public static void AlunoLogin() {
    Console.WriteLine("----- Login do Aluno -----");
    AlunoListar();
    Console.Write("Informe o código do aluno para logar: ");
    int id = int.Parse(Console.ReadLine());
    // Procurar o cliente com o id informado
    alunoLogin = Sistema.AlunoListar(id);
  }
  public static void AlunoLogout() { 
    Console.WriteLine("----- Logout do Aluno -----");
    alunoLogin = null;
  }
  public static void AlunoAgendarConsulta() { 
    Console.WriteLine("----- Horários Disponíveis -----");
    foreach(Consulta obj in Sistema.ConsultaListar(DateTime.Today)) 
      Console.WriteLine(obj);
    Console.WriteLine("------------------------------------------");
    Console.Write("Informe o id do horário para consulta: ");
    int idConsulta = int.Parse(Console.ReadLine());

    Console.WriteLine("----- Listar os livros cadastrados -----");
    foreach(Livro obj in Sistema.LivroListar(alunoLogin)) { 
      Disciplina e = Sistema.DisciplinaListar(obj.GetIdDisciplina());
      Aluno c = Sistema.AlunoListar(obj.GetIdAluno());
      Console.WriteLine($"{obj} {e.GetDescricao()} {c.Nome}");
    }
    Console.Write("Informe o id do livro: ");
    int idLivro = int.Parse(Console.ReadLine());

    Console.WriteLine("----- Listar os serviços cadastrados -----");
    foreach(Operacao obj in Sistema.OperacaoListar()) 
      Console.WriteLine(obj);
    Console.Write("Informe o id do serviço: ");
    int idOperacao = int.Parse(Console.ReadLine());

    Consulta consulta = new Consulta {
      Id = idConsulta, IdAluno = alunoLogin.Id, IdLivro = idLivro, IdOperacao = idOperacao
    };

    Sistema.ConsultaAtualizar(consulta);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  
  public static void AlunoListarHorariosDisponiveis() {
    Console.WriteLine("----- Horários Disponíveis -----");
    foreach(Consulta obj in Sistema.ConsultaListar(DateTime.Today)) 
      Console.WriteLine(obj);
    Console.WriteLine("------------------------------------------");
  }

  public static void AlunoListarConsultas() {
    Console.WriteLine("----- Minhas consultas -----");
    foreach(Consulta obj in Sistema.ConsultaListar(alunoLogin)) 
      Console.WriteLine(obj);
    Console.WriteLine("------------------------------------------");
  }
  
  public static void AlunoListarLivros(){
    Console.WriteLine("----- Meus livros -----");
    foreach(Livro obj in Sistema.LivroListar(alunoLogin)) { 
      Disciplina e = Sistema.DisciplinaListar(obj.GetIdDisciplina());
      Aluno c = Sistema.AlunoListar(obj.GetIdAluno());
      Console.WriteLine($"{obj} {e.GetDescricao()} {c.Nome}");
    }
  }

  public static int MenuUsuario() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("1 - Entrar como Administrador");
    Console.WriteLine("2 - Entrar como Aluno");
    Console.WriteLine("0 - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op; 
  }

  public static int MenuAdmin() {
    Console.WriteLine();
    Console.WriteLine("----- Escolha uma opção! -----");
    Console.WriteLine("01 - Inserir uma nova disciplina");
    Console.WriteLine("02 - Listar as disciplina cadastradas");
    Console.WriteLine("03 - Atualizar uma disciplina");
    Console.WriteLine("04 - Excluir uma disciplina");
    Console.WriteLine("05 - Inserir um novo livro");
    Console.WriteLine("06 - Listar os livros cadastrados");
    Console.WriteLine("07 - Atualizar um livro");
    Console.WriteLine("08 - Excluir um livro");
    Console.WriteLine("09 - Inserir um novo aluno");
    Console.WriteLine("10 - Listar os alunos cadastrados");
    Console.WriteLine("11 - Atualizar um aluno");
    Console.WriteLine("12 - Excluir um aluno");
    Console.WriteLine("13 - Inserir uma nova operação");
    Console.WriteLine("14 - Listar as operações cadastrados");
    Console.WriteLine("15 - Atualizar uma operação");
    Console.WriteLine("16 - Excluir uma operação");
    Console.WriteLine("17 - Abrir Diário");
    Console.WriteLine("18 - Consultar Diário");
    Console.WriteLine("99 - Voltar ao menu anterior");
    Console.WriteLine("00 - Finalizar o sistema");
    Console.WriteLine("------------------------------");
    Console.Write("Opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static int MenuAlunoLogin() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("01 - Login");
    Console.WriteLine("99 - Voltar");
    Console.WriteLine("00 - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op; 
  }

  public static int MenuAlunoLogout() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("Bem vindo(a), " + alunoLogin.Nome);
    Console.WriteLine("----------------------------------");
    Console.WriteLine("01 - Consultar horários disponíveis");
    Console.WriteLine("02 - Agendar uma consulta");
    Console.WriteLine("03 - Listar minhas consultas");
    Console.WriteLine("04 - Listar meus livros");
    Console.WriteLine("99 - Logout");
    Console.WriteLine("0  - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op; 
  }

  public static void DisciplinaInserir() {
    Console.WriteLine("----- Inserir uma nova disciplina -----");
    // Dados da disciplina
    Console.Write("Informe o id: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a descrição: ");
    string descricao = Console.ReadLine();
    // Instanciar a classe Disciplina
    Disciplina obj =  new Disciplina(id, descricao);
    // Inserir a disciplina no sistema
    Sistema.DisciplinaInserir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void DisciplinaListar() {
    Console.WriteLine("----- Listar as disciplinas cadastradas -----");
    foreach(Disciplina obj in Sistema.DisciplinaListar()) 
      Console.WriteLine(obj);
    Console.WriteLine("------------------------------------------");
  }
  public static void DisciplinaAtualizar() {
    Console.WriteLine("----- Atualizar uma disciplina -----");
    // Dados da disciplina
    Console.Write("Informe o id da disciplina a ser atualizada: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a nova descrição: ");
    string descricao = Console.ReadLine();
    // Instanciar a classe Disciplina
    Disciplina obj =  new Disciplina(id, descricao);
    // Atualizar a disciplina no sistema
    Sistema.DisciplinaAtualizar(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void DisciplinaExcluir() {
    Console.WriteLine("----- Excluir uma disciplina -----");
    // Dados da disciplina
    Console.Write("Informe o id da disciplina a ser excluída: ");
    int id = int.Parse(Console.ReadLine());
    string descricao = "";
    // Instanciar a classe Disciplina
    Disciplina obj =  new Disciplina(id, descricao);
    // Excluir a disciplina no sistema
    Sistema.DisciplinaExcluir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }

  public static void LivroInserir() {
    Console.WriteLine("----- Inserir um novo livro -----");
    // Dados do livro
    Console.Write("Informe o id: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a isbn: ");
    string isbn = Console.ReadLine();
    // Lista as disciplinas
    DisciplinaListar();
    Console.Write("Informe a id da Disciplina: ");
    int idDisciplina = int.Parse(Console.ReadLine());
    // Lista os alunos
    AlunoListar();
    Console.Write("Informe a id do aluno: ");
    int idAluno = int.Parse(Console.ReadLine());
    // Instanciar a classe Livro
    Livro obj =  new Livro(id, nome, isbn, idDisciplina, idAluno);
    // Inserir o pet no sistema
    Sistema.LivroInserir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void LivroListar() {
    Console.WriteLine("----- Listar os livros cadastrados -----");
    foreach(Livro obj in Sistema.LivroListar()) { 
      Disciplina e = Sistema.DisciplinaListar(obj.GetIdDisciplina());
      Aluno c = Sistema.AlunoListar(obj.GetIdAluno());
      Console.WriteLine($"{obj} {e.GetDescricao()} {c.Nome}");
    }
    Console.WriteLine("------------------------------------------");
  }
  public static void LivroAtualizar() {
    Console.WriteLine("----- Atualizar um livro -----");
    // Dados do livro
    Console.Write("Informe o id do livro a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe o isbn: ");
    string isbn = Console.ReadLine();
    // Lista as disciplinas
    DisciplinaListar();
    Console.Write("Informe a id da disciplina: ");
    int idDisciplina = int.Parse(Console.ReadLine());
    // Lista os clientes
    AlunoListar();
    Console.Write("Informe a id do aluno: ");
    int idAluno = int.Parse(Console.ReadLine());
    // Instanciar a classe Livro
    Livro obj =  new Livro(id, nome, isbn, idDisciplina, idAluno);
    // Atualizar o livro no sistema
    Sistema.LivroAtualizar(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void LivroExcluir() {
    Console.WriteLine("----- Excluir um livro -----");
    // Dados do livro
    Console.Write("Informe o id do livro a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    // Instanciar a classe Livro
    Livro obj =  new Livro(id);
    // Excluir o livro do sistema
    Sistema.LivroExcluir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }

  public static void AlunoInserir() {
    Console.WriteLine("----- Inserir um novo aluno -----");
    // Dados do aluno
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a matricula: ");
    string matricula = Console.ReadLine();
    // Instanciar a classe Aluno
    Aluno obj =  new Aluno { Nome = nome, Matricula = matricula };
    // Inserir o aluno no sistema
    Sistema.AlunoInserir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void AlunoListar() {
    Console.WriteLine("----- Listar os alunos cadastrados -----");
    foreach(Aluno obj in Sistema.AlunoListar()) 
      Console.WriteLine(obj);
    Console.WriteLine("------------------------------------------");
  }
  public static void AlunoAtualizar() {
    Console.WriteLine("----- Atualizar um aluno -----");
    // Dados do aluno
    Console.Write("Informe o id do aluno a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a matrícula: ");
    string matricula = Console.ReadLine();
    // Instanciar a classe Cliente
    Aluno obj =  new Aluno { Id = id, Nome = nome, Matricula = matricula };
    // Atualizar o aluno no sistema
    Sistema.AlunoAtualizar(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void AlunoExcluir() {
    Console.WriteLine("----- Excluir um aluno -----");
    // Dados do aluno
    Console.Write("Informe o id do aluno a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    // Instanciar a classe Cliente
    Aluno obj =  new Aluno { Id = id };
    // Excluir o aluno do sistema
    Sistema.AlunoExcluir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }

  public static void OperacaoInserir() {
    Console.WriteLine("----- Inserir uma nova operação -----");
    // Dados da operação
    Console.Write("Informe a descrição: ");
    string desc = Console.ReadLine();
    // Instanciar a classe Operacao
    Operacao obj =  new Operacao { Descricao = desc };
    // Inserir a operacao no sistema
    Sistema.OperacaoInserir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void OperacaoListar() {
    Console.WriteLine("----- Listar os serviços cadastrados -----");
    foreach(Operacao obj in Sistema.OperacaoListar()) 
      Console.WriteLine(obj);
    Console.WriteLine("------------------------------------------");
  }
  public static void OperacaoAtualizar() {
    Console.WriteLine("----- Atualizar uma operação -----");
    // Dados do aluno
    Console.Write("Informe o id da operação a ser atualizada: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a descrição: ");
    string desc = Console.ReadLine();
    // Instanciar a classe Operacao
    Operacao obj =  new Operacao { Id = id, Descricao = desc };
    // Atualizar a operacao no sistema
    Sistema.OperacaoAtualizar(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void OperacaoExcluir() {
    Console.WriteLine("----- Excluir uma operação -----");
    // Dados da operação
    Console.Write("Informe o id da operação a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    // Instanciar a classe Operacao
    Operacao obj =  new Operacao { Id = id };
    // Excluir a operacao do sistema
    Sistema.OperacaoExcluir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }

  public static void ConsultaAbrirDiario() {
    Console.WriteLine("----- Abrir Diario -----");
    // Dia do diario para Abrir
    DateTime data = DateTime.Today;
    Console.Write("Informe a data <enter para hoje>: ");
    string s = Console.ReadLine();
    if (s != "") data = DateTime.Parse(s);
    // Abrir Diario
    Sistema.ConsultaAbrirDiario(data);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void ConsultaVerDiario() {
    Console.WriteLine("----- Consultar Diario -----");
    foreach(Consulta obj in Sistema.ConsultaListar()) {
      Aluno c = Sistema.AlunoListar(obj.IdAluno);
      Livro p = Sistema.LivroListar(obj.IdLivro);
      Operacao s = Sistema.OperacaoListar(obj.IdOperacao);
      if (c != null)
        Console.WriteLine(obj + " - " + c.Nome + " - " + p.GetNome() + " - " + s.Descricao);
      else
        Console.WriteLine(obj);
    }
    Console.WriteLine("------------------------------------------");
  }


}