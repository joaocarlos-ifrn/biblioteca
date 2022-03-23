using System; 
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;

class Sistema {
  private static Disciplina[] disciplinas = new Disciplina[10];
  private static int nDisciplina;
  private static List<Livro> livros = new List<Livro>();
  private static List<Aluno> alunos = new List<Aluno>();
  private static List<Operacao> operacoes = new List<Operacao>();
  private static List<Consulta> consultas = new List<Consulta>();

  public static void ArquivosAbrir() {

    Arquivo<Disciplina[]> f1 = new Arquivo<Disciplina[]>();
    disciplinas = f1.Abrir("./disciplinas.xml");
    nDisciplina = disciplinas.Length;

    Arquivo<List<Livro>> f2 = new Arquivo<List<Livro>>();
    livros = f2.Abrir("./livros.xml");

    Arquivo<List<Aluno>> f3 = new Arquivo<List<Aluno>>();
    alunos = f3.Abrir("./alunos.xml");

    Arquivo<List<Operacao>> f4 = new Arquivo<List<Operacao>>();
    operacoes = f4.Abrir("./operacoes.xml");

    Arquivo<List<Consulta>> f5 = new Arquivo<List<Consulta>>();
    consultas = f5.Abrir("./consultas.xml");

    /*
    XmlSerializer xml = new XmlSerializer(typeof(Disciplina[]));
    StreamReader f = new StreamReader("./disciplinas.xml", Encoding.Default);
    disciplinas = (Disciplina[]) xml.Deserialize(f);
    nDisciplina = disciplinas.Length;
    f.Close();
    */
  }

  public static void ArquivosSalvar() {

    Arquivo<Disciplina[]> f1 = new Arquivo<Disciplina[]>();
    f1.Salvar("./disciplinas.xml", DisciplinaListar());

    Arquivo<List<Livro>> f2 = new Arquivo<List<Livro>>();
    f2.Salvar("./livros.xml", livros);

    Arquivo<List<Aluno>> f3 = new Arquivo<List<Aluno>>();
    f3.Salvar("./alunos.xml", alunos);

    Arquivo<List<Operacao>> f4 = new Arquivo<List<Operacao>>();
    f4.Salvar("./operacoes.xml", operacoes);

    Arquivo<List<Consulta>> f5 = new Arquivo<List<Consulta>>();
    f5.Salvar("./consultas.xml", consultas);
    
    /*
    XmlSerializer xml = new XmlSerializer(typeof(Disciplina[]));
    StreamWriter f = new StreamWriter("./disciplinas.xml", false, Encoding.Default);
    xml.Serialize(f, DisciplinaListar());
    f.Close();
    */
  }

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
    // Percorre o vetor de disciplinas e retorna a disciplina com o id informado
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
    // Remove a disciplina se o índice for encontrado
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
      // Cada objeto disciplina no vetor
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
  public static List<Livro> LivroListar(Aluno aluno) {
    // Retorna os objetos cadastrados para um aluno
    List<Livro> r = new List<Livro>();
    // Percorre a lista de livros e retorna os livros do aluno informado
    foreach(Livro obj in livros)
      if (obj.GetIdAluno() == aluno.Id) 
        r.Add(obj);
    return r;
  }
  public static Livro LivroListar(int id) {
    // Percorre a lista de livros e retorna o livro com o id informado
    foreach(Livro obj in livros)
      if (obj.GetId() == id) return obj;
    return null;  
  }
  public static void LivroAtualizar(Livro obj) {
    // Localiza o livro com o id informado
    Livro aux = LivroListar(obj.GetId());
    // Atualiza os demais atributos do livro
    if (aux != null) {
      aux.SetNome(obj.GetNome());
      aux.SetIsbn(obj.GetIsbn());
      aux.SetIdDisciplina(obj.GetIdDisciplina());
    }  
  }
  public static void LivroExcluir(Livro obj) {
    // Localiza o livro com o id informado
    Livro aux = LivroListar(obj.GetId());
    // Remove o livro da lista
    if (aux != null) livros.Remove(aux);
  }

  public static void AlunoInserir(Aluno obj) {
    // Calcular o id do aluno a ser incluído
    int id = 0;
    foreach(Aluno aux in alunos)
      if (aux.Id > id) id = aux.Id;
    obj.Id = id + 1;  
    // Insere o objeto na lista
    alunos.Add(obj);
  }
  public static List<Aluno> AlunoListar() {
    // Retorna os objetos cadastrados
    return alunos;
  }
  public static Aluno AlunoListar(int id) {
    // Percorre a lista de alunos e retorna o aluno com o id informado
    foreach(Aluno obj in alunos)
      if (obj.Id == id) return obj;
    return null;  
  }
  public static void AlunoAtualizar(Aluno obj) {
    // Localiza o aluno com o id informado
    Aluno aux = AlunoListar(obj.Id);
    // Atualiza as demais propriedades do aluno
    if (aux != null) {
      aux.Nome = obj.Nome;
      aux.Matricula = obj.Matricula;
    }  
  }
  public static void AlunoExcluir(Aluno obj) {
    // Localiza o aluno com o id informado
    Aluno aux = AlunoListar(obj.Id);
    // Remove o aluno da lista
    if (aux != null) alunos.Remove(aux);
  }


  public static void OperacaoInserir(Operacao obj) {
    // Calcular o id do operacao a ser incluído
    int id = 0;
    foreach(Operacao aux in operacoes)
      if (aux.Id > id) id = aux.Id;
    obj.Id = id + 1;  
    // Insere o objeto na lista
    operacoes.Add(obj);
  }
  public static List<Operacao> OperacaoListar() {
    // Retorna os objetos cadastrados
    return operacoes;
  }
  public static Operacao OperacaoListar(int id) {
    // Percorre a lista de operacoes e retorna a operacao com o id informado
    foreach(Operacao obj in operacoes)
      if (obj.Id == id) return obj;
    return null;  
  }
  public static void OperacaoAtualizar(Operacao obj) {
    // Localiza a operacao com o id informado
    Operacao aux = OperacaoListar(obj.Id);
    // Atualiza as demais propriedades da operacao
    if (aux != null) {
      aux.Descricao = obj.Descricao;
    }  
  }
  public static void OperacaoExcluir(Operacao obj) {
    // Localiza a operacao com o id informado
    Operacao aux = OperacaoListar(obj.Id);
    // Remove a operacao da lista
    if (aux != null) operacoes.Remove(aux);
  }

  public static void ConsultaAbrirDiario(DateTime data) {
    // Dia e horários de atendimento
    int[] horas = { 8, 9, 10, 11, 14, 15, 16, 17 };
    DateTime hoje = data.Date;
    foreach (int h in horas) {
      TimeSpan horario = new TimeSpan(0, h, 0, 0);
      Consulta obj = new Consulta { DataHora = hoje + horario };
      ConsultaInserir(obj);
    }
  }
  public static void ConsultaInserir(Consulta obj) {
    // Calcular o id da consulta a ser incluído
    int id = 0;
    foreach(Consulta aux in consultas)
      if (aux.Id > id) id = aux.Id;
    obj.Id = id + 1;  
    // Insere o objeto na lista
    consultas.Add(obj);
  }
  public static List<Consulta> ConsultaListar() {
    // Retorna os objetos cadastrados
    return consultas;
  }
  public static List<Consulta> ConsultaListar(Aluno aluno) {
    // Retorna os objetos cadastrados para um aluno
    List<Consulta> r = new List<Consulta>();
    // Percorre a lista de agendamentos e retorna as consultas do cliente informado
    foreach(Consulta obj in consultas)
      if (obj.IdAluno == aluno.Id) 
        r.Add(obj);
    return r;
  }
  public static List<Consulta> ConsultaListar(DateTime data) {
    // Retorna as consultas disponíveis em uma data
    List<Consulta> r = new List<Consulta>();
    // Percorre a lista de consultas 
    foreach(Consulta obj in consultas)
      if (obj.IdAluno == 0 && obj.DataHora.Date == data.Date) 
        r.Add(obj);
    return r;
  }
  public static Consulta ConsultaListar(int id) {
    // Percorre a lista de consultas e retorna a consulta com o id informado
    foreach(Consulta obj in consultas)
      if (obj.Id == id) return obj;
    return null;  
  }
  public static void ConsultaAtualizar(Consulta obj) {
    // Localiza a consulta com o id informado
    Consulta aux = ConsultaListar(obj.Id);
    // Atualiza as demais propriedades da consulta
    if (aux != null) {
      //aux.DataHora = obj.DataHora;
      aux.IdAluno = obj.IdAluno;
      aux.IdLivro = obj.IdLivro;
      aux.IdOperacao = obj.IdOperacao;
    }  
  }
  public static void ConsultaExcluir(Consulta obj) {
    // Localiza a consulta com o id informado
    Consulta aux = ConsultaListar(obj.Id);
    // Remove a consulta da lista
    if (aux != null) consultas.Remove(aux);
  }


}