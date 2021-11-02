using System;

namespace Paulflix
{
public class Serie : Entidadebase
{
    // Atributos

private  Genero Genero {get; set;}
private string Titulo {get; set;}
private string Descricao {get; set;}
private int Ano {get; set;}
private bool Excluido {get; set;}
    

    //Métodos
    public Serie(int id, Genero genero, string Titulo, string Descricao, int Ano)
    {
      this.Id = id;
      this.Genero = genero;
      this.Titulo =Titulo;
      this.Descricao = Descricao;
      this.Ano = Ano;
      this.Excluido = false;
    }
    
    public override string ToString()
   {
    string retorno = "";
    retorno += "Gender: " + this.Genero + ("/n");
    retorno += "Title: " + this.Titulo + ("/n");
    retorno += "Description: " + this.Descricao + ("/n");
    retorno += "Year of production: " + this.Ano + ("/n");
    retorno += "Delete: " + this.Excluido;
    return retorno;
   } 
    public string retornaTitulo()
    {
        return this.Titulo;
    }
     public int retornaId()
     {
      return this.Id;   
     }
     public bool retornaExcluido()
     {
      return this.Excluido;   
     }
      public void Excluir(){
          this.Excluido = true;
        }
    }

}