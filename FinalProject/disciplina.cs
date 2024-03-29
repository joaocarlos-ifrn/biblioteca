using System;

public class Disciplina {
  private int id;
  private string descricao;

  public int Id{
    get => id;
    set => id = value;
  }

  public string Descricao{
    get => descricao;
    set => descricao = value;
  }

  public Disciplina(){ }
  
  public Disciplina(int id, string descricao) {
    this.id = id;
    this.descricao = descricao;
  }
  public void SetId(int id) {
    this.id = id;
  }
  public void SetDescricao(string descricao) {
    this.descricao = descricao;
  }
  public int GetId() {
    return id;
  }
  public string GetDescricao() {
    return descricao;
  }
  public override string ToString() {
    return $"{id} - {descricao}";
  }
}