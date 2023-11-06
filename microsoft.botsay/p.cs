using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Bonjour et bienvenu. Que souhaitez vous faire?");
        Console.WriteLine("1. Corriger les fautes");
        Console.WriteLine("2. Traduire le texte");
        Console.WriteLine("3. Faire une application en react");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1 :
                await CorrectWord();
                break;

            case 2 :
                await Traduct();
                break;

            case 3 :
                await Create();
                break;  

            default:
                Console.WriteLine("Choix Invalide");
                break;
        }

    } 

    static async Task CorrectWord()
    {
        string keyAPI = "f639bfb9e778e791cae62cc2b19032808a9f9b17";
        
        var httpClient = new HttpClient();

        string URL = "https://api.nlpcloud.io/v1/gpu/finetuned-llama-2-70b/gs-correction";

        Console.WriteLine("Ecrivez quelque chose...");
        string textWithFault = Console.ReadLine();

            var texte = new
        {
            text = textWithFault
        };

            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(texte), Encoding.UTF8, "application/json");
          httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {keyAPI}");

          var reponse = await httpClient.PostAsync(URL,content);
    
        if(reponse.IsSuccessStatusCode)

        {
            var reponsecontent = await reponse.Content.ReadAsStringAsync();
            Console.WriteLine("Voici la correction:");
            Console.WriteLine(reponsecontent);
        }
        else
        {
            Console.WriteLine("Erreur : {reponse.StatusCode}");
        }
    }

    static async Task Traduct()
     {
        string keyAPI = "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";
        string URL = "";

        Console.WriteLine("Que voulez-vous traduire ?");
        string textNotTraduct = Console.ReadLine();

        using (HttpClient client = new HttpClient());
        var texteTrad = textNotTraduct;
        Console.WriteLine("texteTrad" +texteTrad);
     }

     static async Task Create()
     {
        string create = Console.ReadLine();
        // Process.Start();
     }
}