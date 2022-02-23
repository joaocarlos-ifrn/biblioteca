using System;

class Disciplina {
  private string nome;

  public Disciplina(string nome){
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