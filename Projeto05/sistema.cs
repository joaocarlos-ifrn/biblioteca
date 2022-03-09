using System; 
using System.Collections.Generic;

class Sistema {
  private static Disciplina[] disciplinas = new Disciplina[10];
  private static int nDisciplina;
  private static List<Livro> livros = new List<Livro>();
  public static void DisciplinaInserir(Disciplina obj) {
    // Verifica o tamanho vetor
    if (nDisciplina == disciplinas.Length)
      Array.Resize(ref disciplinas, 2 * disciplinas.Length);
    // Insere o objeto no vetor
    disciplinas[nDisciplina] = obj;
    // Incrementa o contador
    nDisciplina++;
  }
  public static Disciplina[] DisciplinaListar() {
    // Retorna os objetos cadastrados
    Disciplina[] aux = new Disciplina[nDisciplina];
    Array.Copy(disciplinas, aux, nDisciplina);
    return aux;
  }
  public static Disciplina DisciplinaListar(int id) {
    // Percorre o vetor de disciplinas e retorna a espécie com o id informado
    foreach(Disciplina obj in disciplinas)
      if (obj != null && obj.GetId() == id) return obj;
    return null;  
  }
  public static void DisciplinaAtualizar(Disciplina obj) {
    // Localiza a disciplina com o id informado
    Disciplina aux = DisciplinaListar(obj.GetId());
    // Atualiza a descrição da disciplina
    if (aux != null)
      aux.SetDescricao(obj.GetDescricao());
  }
  public static void DisciplinaExcluir(Disciplina obj) {
    // Localiza no vetor o índice desse objeto
    int aux = DisciplinaIndice(obj.GetId());
    // Remove a espécie se o índice for encontrado
    if (aux != -1) {
      for (int i = aux; i < nDisciplina - 1; i++)
        disciplinas[i] = disciplinas[i + 1];
      // decrementa o contador de disciplinas
      nDisciplina--;  
    }
  }
  private static int DisciplinaIndice(int id) {
    // Percorre o vetor com as disciplinas e retorna o índice do elemento com o id informado    
    for(int i = 0; i < nDisciplina; i++) {
      // Cada objeto espécie no vetor
      Disciplina obj = disciplinas[i];
      if (obj.GetId() == id) return i;
    }
    return -1;
  }
  
  public static void LivroInserir(Livro obj) {
    // Insere o objeto na lista
    livros.Add(obj);
  }
  public static List<Livro> LivroListar() {
    // Retorna os objetos cadastrados
    return livros;
  }
  public static Livro LivroListar(int id) {
    // Percorre a lista de pets e retorna o pet com o id informado
    foreach(Livro obj in livros)
      if (obj.GetId() == id) return obj;
    return null;  
  }
  public static void LivroAtualizar(Livro obj) {
    // Localiza o pet com o id informado
    Livro aux = LivroListar(obj.GetId());
    // Atualiza os demais atributos do pet
    if (aux != null) {
      aux.SetNome(obj.GetNome());
      aux.SetIsbn(obj.GetIsbn());
      aux.SetIdDisciplina(obj.GetIdDisciplina());
    }  
  }
  public static void LivroExcluir(Livro obj) {
    // Localiza o pet com o id informado
    Livro aux = LivroListar(obj.GetId());
    // Remove o pet da lista
    if (aux != null) livros.Remove(aux);
  }
}