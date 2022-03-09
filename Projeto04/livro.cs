using System;

class Livro {
  private int id;
  private string nome;
  private string raca;
  private DateTime nasc;
  private int idDisciplina;
  public Livro(int id) {
    this.id = id;
  }
  public Livro(int id, string nome, string raca, DateTime nasc, int idDisciplina) {
    this.id = id;
    this.nome = nome;
    this.raca = raca;
    this.nasc = nasc;
    this.idDisciplina = idDisciplina;
  }
  public void SetId(int id) {
    this.id = id;
  }
  public void SetNome(string nome) {
    this.nome = nome;
  }
  public void SetRaca(string raca) {
    this.raca = raca;
  }
  public void SetNasc(DateTime nasc) {
    this.nasc = nasc;
  }
  public void SetIdDisciplina(int idEspecie) {
    this.idDisciplina = idDisciplina;
  }
  public int GetId() {
    return id;
  }
  public string GetNome() {
    return nome;
  }
  public string GetRaca() {
    return raca;
  }
  public DateTime GetNasc() {
    return nasc;
  }
  public int GetIdDisciplina() {
    return idDisciplina;
  }
  public override string ToString() {
    return $"{id} - {nome} - {raca} - {nasc:dd/MM/yyyy}";
  }
}