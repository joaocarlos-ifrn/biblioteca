using System;

class Consulta {
  public int Id { get; set; }
  public DateTime DataHora { get; set; }
  public int IdAluno { get; set; }
  public int IdLivro { get; set; }
  public int IdOperacao { get; set; }
  public override string ToString() {
    string s = $"{Id} {DataHora:dd/MM/yyyy HH:mm}";
    if (IdAluno == 0) s += " - Disponível";
    return s;
  }
}