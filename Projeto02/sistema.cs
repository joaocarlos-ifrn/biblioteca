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
}