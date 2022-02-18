using System;

class Genero {
  private string nome;

  public Genero(string nome){
    this.nome = nome;
  }

  public void SetNome(string nome){
    this.nome = nome;
  }

  public string GetNome(){
    return nome;
  }

  public override string ToString(){
    return $"{nome}";
  }
}