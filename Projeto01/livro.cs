using System;

class Livro {
  private string nome;
  private string isbn;
  
  public Livro(string nome, string isbn){
    this.nome = nome;
    this.isbn = isbn;
  }

  public void SetNome(string nome){
    this.nome = nome;
  }

  public void SetIsbn(string isbn){
    this.isbn = isbn;
  }

  public string GetNome(){
    return nome;
  }

  public string GetIsbn(){
    return isbn;
  }

  public override string ToString(){
    return $"{nome} - {isbn}";
  }
}