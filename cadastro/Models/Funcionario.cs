namespace cadastro.Models;

public class Funcionario
{
    //atributos = caracteristicas
    private string? nome;
    //métodos = comportamentos
     public string? Nome
    {
        get { return nome; }
        set { nome = value; }
    }
     public int? Idade
    {
        get { return Idade; }
        set { Idade = value; }
    }
}