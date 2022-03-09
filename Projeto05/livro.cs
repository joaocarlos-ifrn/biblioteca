using System;

class Livro {
  private int id;
  private string nome;
  private string isbn;
  private int idDisciplina;
  
  public Livro(int id) {
    this.id = id;
  }
  public Livro(int id, string nome, string isbn, int idDisciplina) {
    this.id = id;
    this.nome = nome;
    this.isbn = isbn;
    this.idDisciplina = idDisciplina;
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
  public override string ToString() {
    return $"{id} - {nome} - {isbn} - Disciplina {idDisciplina}";
  }
}