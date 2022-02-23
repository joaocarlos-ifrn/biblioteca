using System;

class Program {
  public static void Main() {
    Console.WriteLine("Bem-vindo à biblioteca");
    int op = 0;

    do {
      op = Menu();
      switch(op) {
        case 1 : DisciplinaInserir(); break;
        case 2 : DisciplinaListar(); break;
        case 3 : DisciplinaAtualizar(); break;
      }
    } while(op != 0);
  }
    
  public static int Menu(){
    Console.WriteLine();
    Console.WriteLine("----- Escolha uma opção! -----");
    Console.WriteLine("01 - Inserir uma nova disciplina");
    Console.WriteLine("02 - Listar as disciplinas cadastrados");
    Console.WriteLine("03 - Atualizar as disciplinas cadastradas"); 
    Console.WriteLine("00 - Finalizar o sistema");
    Console.WriteLine("--------------------------------");
    Console.WriteLine("Opção: ");
    int op = int.Parse(Console.ReadLine());      
    Console.WriteLine();
    return op;
  }

  public static void DisciplinaInserir(){
    Console.WriteLine("----- Inserir uma nova disciplina -----");
    //dados da disciplina;
    Console.Write("Informe o id: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome da disciplina: ");
    string nome = Console.ReadLine();
    //instanciar a classe Disciplina
    Disciplina obj = new Disciplina(id, nome);
    //inserir a disciplina no sistema
    Sistema.DisciplinaInserir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }

  public static void DisciplinaListar(){
      Console.WriteLine("----- Listar os gêneros cadastrados -----");
      foreach(Disciplina obj in Sistema.DisciplinaListar())
      Console.WriteLine(obj);
      Console.WriteLine("-------------------------------------------");
    }

  public static void DisciplinaAtualizar(){
      Console.WriteLine("----- Atualizar Disciplina -----");
      //dados da disciplina;
      Console.Write("Informe o id da disciplina a ser atualizada: ");
      int id = int.Parse(Console.ReadLine());
      Console.Write("Informe a nova disciplina: ");
      string nome = Console.ReadLine();
      //instanciar a classe Especie
      Disciplina obj = new Disciplina(id, nome);
      //inserir a especie no sistema
      Sistema.DisciplinaAtualizar(obj);
      Console.WriteLine("----- Operação realizada com sucesso -----");
    }
}
