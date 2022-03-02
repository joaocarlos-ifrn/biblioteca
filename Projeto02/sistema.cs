using System;

class Sistema {
  private static Disciplina[] disciplinas = new Disciplina[10];
  private static int nDisciplina;
  
  public static void DisciplinaInserir(Disciplina obj){
    //verifica o tamanho do vetor
    if (nDisciplina == disciplinas.Length)
      Array.Resize(ref disciplinas, 2 * disciplinas.Length);

    //inserir o objeto no vetor
    disciplinas[nDisciplina] = obj;
    nDisciplina++; 
  }

  public static Disciplina[] DisciplinaListar(){
    //retornar os objetos cadastrados
    Disciplina[] aux = new Disciplina[nDisciplina];
    Array.Copy(disciplinas, aux, nDisciplina);

    return aux;
  }

  public static Disciplina DisciplinaListar(int id){
    //percorrer o vetor das disciplinas e retornar a disciplina com o id informado
    foreach(Disciplina obj in disciplinas)
      if(obj != null && obj.GetId() == id) return obj;
    return null;
  }

  public static void DisciplinaAtualizar(Disciplina obj){
    //localizar a especie com o id informado
    Disciplina aux = DisciplinaListar(obj.GetId());
    //atualiza a descricao da especie
    if (aux != null)
      aux.SetNome(obj.GetNome());
  }

    public static void DisciplinaExcluir(Disciplina obj){
    //localizar o índice do objeto no vetor
    int aux = DisciplinaIndice(obj.GetId());
    //remove a espécie se o índice for encontrado
    if (aux != -1){
      for (int i = aux; i < nDisciplina - 1; i++)
        disciplinas[i] = disciplinas[i + 1];
        nDisciplina--;
      
    }
    
  }

  private static int DisciplinaIndice(int id){
    //percorrer o vetor com as especies e retornar o indice do elemento com o id informado
    for (int i = 0; i < nDisciplina; i++){
      //cada objeto especie no vetor
      Disciplina obj = disciplinas[i];
      if (obj.GetId() == id) return i;
    }
  return -1;
  }
}