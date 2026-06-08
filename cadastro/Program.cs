// Cria um objeto responsável por configurar a aplicação ASP.NET
using System.Reflection.Metadata.Ecma335;
using cadastro.Models;

var builder = WebApplication.CreateBuilder(args);

// Define o endereço e a porta em que a aplicação irá escutar requisições HTTP
builder.WebHost.UseUrls("http://localhost:8000");

// Constrói a aplicação web a partir das configurações definidas no builder
var app = builder.Build();

Funcionario[] funcionarios = new Funcionario[100];
int contador = 0;
// Definição de rotas HTTP do tipo GET 
app.MapGet("/", () =>
{
    return Results.Ok("API funcionando com ASP.NET!");
});
app.MapGet("/for", () => {
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(i);
}});
app.MapGet("/while", () =>
{
    int i = 0;
    while(i < 5)
    {
        Console.WriteLine(i++);
    }
});
app.MapGet("/objeto", () =>
{
    Funcionario funcionario = new Funcionario();

    funcionario.Nome = "Pedro";

    Console.WriteLine("Nome: " + funcionario.Nome);
});
app.MapGet("/objeto/{nome1}", ( string nome1) =>{
   string resultado = nome1;
     return Results.Ok(new
    {
        resultado
    });
    });
    app.MapGet("/vetor",() =>{
 int[] numeros = new int[3]; 

     numeros[0] = 10;
     numeros[1] = 55;
     numeros[2] = 77;

     Console.WriteLine("valor 1: " + numeros[0]);
     Console.WriteLine("valor 2: " + numeros[1]);
     Console.WriteLine("valor 3: " + numeros[2]);

     // mostra o valor no site
     return Results.Ok(new {
        mensagem = "numeros: ", 
        numeros}
      );

});

app.MapGet("/vetor/funcionario/{nome}", (string nome) => {

  Funcionario funcionario = new Funcionario();

  funcionario.Nome = nome;
  funcionario.Idade = 45;

  funcionarios[contador] = funcionario;
  contador++;
   return Results.Ok(new {
        mensagem = "funcionario: ",
        contador,
        funcionarios}
      );


});
app.MapGet("/vetor/funcionarios", () =>{
    
   for (int i = 0; i < contador; i++)
    {
        Console.WriteLine("Funcionario:" + funcionarios[i].Nome);
        Console.WriteLine("Funcionario:" + funcionarios[i].Idade);
    }
});
app.MapGet("/vetor/funcionarios/json", () =>{
    
    Funcionario[] funcionarios_cadastrados = new Funcionario[contador];
    for (int i = 0; i < contador; i++)
    {
       funcionarios_cadastrados[i] = funcionarios[i];
    }
    return Results.Ok(
        new{ funcionarios_cadastrados}
    );

});
// Inicia o servidor web é iniciado e passa a aguardar requisições HTTP dos clientes
app.Run();