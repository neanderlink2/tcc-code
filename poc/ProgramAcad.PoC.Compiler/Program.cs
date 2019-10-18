using ProgramAcad.Common.Enums;
using ProgramAcad.PoC.Compiler.JDoodle.Models;
using System;
using System.Threading.Tasks;

namespace ProgramAcad.PoC.Compiler
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Começando a compilação dos códigos...");
            var client = new CompilerClient();

            var csharp = await CompilarCSharp(client);
            var java = await CompilarJava(client);
            var python = await CompilarPython(client);

            Console.WriteLine("E os resultados das compilações são: ");

            Console.WriteLine(@$"
C# : Tempo de CPU - {csharp.CpuTime}
Saída: {csharp.Output}");

            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine(@$"
Java : Tempo de CPU - {java.CpuTime}
Saída: {java.Output}");

            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine(@$"
Python : Tempo de CPU - {python.CpuTime}
Saída: {python.Output}");

            Console.ReadKey();
        }

        private static async Task<CompilerResponse> CompilarCSharp(CompilerClient client)
        {
            return await client.Compile(@"
                using System;
                public class Program {
                    public static void Main(string[] args) {
                        Console.WriteLine(""Olá mundo"");
                        var resposta = Console.ReadLine();
                        Console.WriteLine($""{resposta}"");
                        var resposta2 = Console.ReadLine();
                        Console.WriteLine($""{resposta2}"");
                    }
                }", new string[] { "C#", "Muito amor <3" }, LinguagensProgramacao.CSharp);
        }

        private static async Task<CompilerResponse> CompilarJava(CompilerClient client)
        {
            return await client.Compile(@"
                import java.util.*;
                public class Main {
                    public static void main(String[] args) {
                        Scanner leitor = new Scanner(System.in);
                        System.out.println(""Primeira linha"");
                        String resposta = leitor.nextLine();
                        System.out.println(resposta);
                        String resposta2 = leitor.nextLine();
                        System.out.println(resposta2);
                    }
                }", new string[] { "Java", "É pesado" }, LinguagensProgramacao.Java);
        }

        private static async Task<CompilerResponse> CompilarPython(CompilerClient client)
        {
            return await client.Compile(@"print('Ola mundo');
resposta = input('');
print(resposta);
resposta2 = input('');
print(resposta2);", new string[] { "Python", "Pq nao?" }, LinguagensProgramacao.Python);
        }
    }
}
