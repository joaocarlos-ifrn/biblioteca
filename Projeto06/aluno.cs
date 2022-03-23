using System;

class Aluno {
  public int Id { get; set; }
  public string Nome { get; set; }
  public string Matricula { get; set; }
  public override string ToString() {
    return $"{Id} - {Nome} - {Matricula}";
  }
}