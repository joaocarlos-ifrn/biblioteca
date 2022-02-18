using System;

class Program {
  public static void Main(){

  Console.WriteLine("Bem-vindo à Biblioteca");

  //objetos de Especie
    Genero g1 = new Genero("Aventura");
    Genero g2 = new Genero("Romance");

    Console.WriteLine(g1);
    Console.WriteLine(g2);
  }
}