using System;

class Program {
  public static void Main() {
    Console.WriteLine("Bem-vindo ao IFPet");
    int op = 0;
    do {
      try {
        op = Menu();
        switch(op) {
          case 1 : DisciplinaInserir(); break;
          case 2 : DisciplinaListar(); break;
          case 3 : DisciplinaAtualizar(); break;
          case 4 : DisciplinaExcluir(); break;
          case 5 : LivroInserir(); break;
          case 6 : LivroListar(); break;
          case 7 : LivroAtualizar(); break;
          case 8 : LivroExcluir(); break;
        }
      }
      catch (Exception erro) {
        op = -1;
        Console.WriteLine("Erro: " + erro.Message);
      }
    } while (op != 0);
  }
  public static int Menu() {
    Console.WriteLine();
    Console.WriteLine("----- Escolha uma opção! -----");
    Console.WriteLine("01 - Inserir uma nova disciplina");
    Console.WriteLine("02 - Listar as disciplinas cadastradas");
    Console.WriteLine("03 - Atualizar uma disciplina");
    Console.WriteLine("04 - Excluir uma disciplina");
    Console.WriteLine("05 - Inserir um novo livro");
    Console.WriteLine("06 - Listar os livros cadastrados");
    Console.WriteLine("07 - Atualizar um livro");
    Console.WriteLine("08 - Excluir um livro");
    Console.WriteLine("00 - Finalizar o sistema");
    Console.WriteLine("------------------------------");
    Console.Write("Opção: ");
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
    // Atualizar a espécie no sistema
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
    Console.Write("Informe o isbn: ");
    string isbn = Console.ReadLine();
    

    DisciplinaListar();
    Console.Write("Informe a id da disciplina: ");
    int idDisciplina = int.Parse(Console.ReadLine());

    // Instanciar a classe Livro
    Livro obj =  new Livro(id, nome, isbn, idDisciplina);
    // Inserir o livro no sistema
    Sistema.LivroInserir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void LivroListar() {
    Console.WriteLine("----- Listar os livros cadastrados -----");
    foreach(Livro obj in Sistema.LivroListar()) 
      Console.WriteLine(obj);
    Console.WriteLine("------------------------------------------");
  }
  public static void LivroAtualizar() {
    Console.WriteLine("----- Atualizar um livro -----");
    // Dados da disciplina
    Console.Write("Informe o id do livro a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe o isbn: ");
    string isbn = Console.ReadLine();

    DisciplinaListar();
    Console.Write("Informe a id da disciplina: ");
    int idDisciplina = int.Parse(Console.ReadLine());
    // Instanciar a classe Livro
    Livro obj =  new Livro(id, nome, isbn, idDisciplina);
    // Atualizar o livro no sistema
    Sistema.LivroAtualizar(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  public static void LivroExcluir() {
    Console.WriteLine("----- Excluir um livro -----");
    // Dados da disciplina
    Console.Write("Informe o id do livro a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    // Instanciar a classe Livro
    Livro obj =  new Livro(id);
    // Excluir o pet do sistema
    Sistema.LivroExcluir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }

}