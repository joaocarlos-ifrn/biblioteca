using System;

class Livro {
  private int id;
  private string nome;
  private string isbn;
  private int idDisciplina;
  private int idAluno;
  public Livro(int id) {
    this.id = id;
  }
  public Livro(int id, string nome, string isbn, int idDisciplina, int idAluno) {
    this.id = id;
    this.nome = nome;
    this.isbn = isbn;
    this.idDisciplina = idDisciplina;
    this.idAluno = idAluno;
  }
  public void SetId(int id) {
    this.id = id;
  }
  public void SetNome(string nome) {
    this.nome = nome;
  }
  public void SetIsbn(string isbn) {
    this.isbn = isbn;
  }
  public void SetIdDisciplina(int idDisciplina) {
    this.idDisciplina = idDisciplina;
  }
  public void SetIdAluno(int idAluno) {
    this.idAluno = idAluno;
  }
  public int GetId() {
    return id;
  }
  public string GetNome() {
    return nome;
  }
  public string GetIsbn() {
    return isbn;
  }
  public int GetIdDisciplina() {
    return idDisciplina;
  }
  public int GetIdAluno() {
    return idAluno;
  }
  public override string ToString() {
    return $"{id} - {nome} - {isbn}";
  }
}