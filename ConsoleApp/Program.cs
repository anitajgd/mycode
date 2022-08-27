// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using testJuego.Domain;


// Iniciamos propiedades 
Response response = null;
string name1 = string.Empty;
string name2 = string.Empty;

Console.WriteLine("Empezamos");


// Creomos jugadores
Console.Write("Nombre de jugador 1: ");
name1 = Console.ReadLine();

var player1 = new Player()
{
    Name = name1,
};


Console.Write("Nombre de jugador 2: ");
name2 = Console.ReadLine();

var player2 = new Player()
{
    Name = name2,
};


// Empezamos a tirar "dado"
int index = 2;

do
{
    // Par
    if ((index % 2) == 0)
    {
        Console.WriteLine(" ");
        Console.Write(player1.Name + " Pulsa enter para tirar");
        Console.ReadLine();

        response = CallApi(player1);
        player1.CurrentPosition = response.player.CurrentPosition;

        Console.WriteLine("Valor del dado " + response.DiceValue);
        Console.WriteLine(response.player.Name + " Estas en la casilla: " + response.player.CurrentPosition);
    }
    else
    {
        Console.WriteLine(" ");
        Console.Write(player2.Name + " Pulsa enter para tirar");
        Console.WriteLine(" ");
        Console.ReadLine();

        response = CallApi(player2);
        player2.CurrentPosition = response.player.CurrentPosition;

        Console.WriteLine("Valor del dado " + response.DiceValue);
        Console.WriteLine(response.player.Name + " Estas en la casilla: " + response.player.CurrentPosition);
    }

    index++;

} while (response.Status == 0);

Console.WriteLine(response.player.Name + " " + response.Message);


static Response CallApi(Player player)
{
    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("https://localhost:7111/game/play");
    client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


    var json = JsonConvert.SerializeObject(player);
    var data = new StringContent(json, Encoding.UTF8, "application/json");
    var response = client.PostAsync(client.BaseAddress, data).Result;

    string result = response.Content.ReadAsStringAsync().Result;

    Response rs = JsonConvert.DeserializeObject<Response>(result);

    return rs;
}

