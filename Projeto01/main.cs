using System;

class Program {
  public static void Main(){

  Console.WriteLine("Bem-vindo à Biblioteca");

  //objetos de Genero
    Genero g1 = new Genero("Aventura");
    Genero g2 = new Genero("Romance");

  //objetos de Livro
    Livro l1 = new Livro("Apple", "1");
    Livro l2 = new Livro("Meta", "2");

    Console.WriteLine(g1);
    Console.WriteLine(g2);

    Console.WriteLine(l1);
    Console.WriteLine(l2);
  }
}