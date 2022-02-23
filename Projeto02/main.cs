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
      }
    } while(op != 0);
  }
    
  public static int Menu(){
    Console.WriteLine();
    Console.WriteLine("----- Escolha uma opção! -----");
    Console.WriteLine("01 - Inserir um novo gênero");
    Console.WriteLine("02 - Listar os gêneros cadastrados");  
    Console.WriteLine("00 - Finalizar o sistema");
    Console.WriteLine("--------------------------------");
    Console.WriteLine("Opção: ");
    int op = int.Parse(Console.ReadLine());      
    Console.WriteLine();
    return op;
  }

  public static void DisciplinaInserir(){
    Console.WriteLine("----- Inserir um novo Gênero -----");
    //dados da disciplina;
    Console.Write("Informe o nome do gênero: ");
    string nome = Console.ReadLine();
    //instanciar a classe Disciplina
    Disciplina obj = new Disciplina(nome);
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
}
