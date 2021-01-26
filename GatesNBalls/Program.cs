using GatesNBalls.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GatesNBalls
{
    class Program
    {
        static void Main(string[] args)
        {



            var serviceProvider = new ServiceCollection()
        .AddSingleton<ITreeService, TreeService>()
        .BuildServiceProvider();

            var treeService = serviceProvider.GetService<ITreeService>();

            Console.WriteLine("Enter the depth of the tree:");

            string sDepth = Console.ReadLine();
            // 4
        

            Console.WriteLine("Enter the initial state of the gates as comma separated values:");
            string sGates = Console.ReadLine();
            // L,R,R,L,L,L,L,R,L,R,R,L,L,R,L

            var tree = treeService.FormTree(sDepth, sGates);

            if (tree.Error)
            {
                Console.WriteLine(tree.ErrorMessage);
                return;
            }

            var predictedEmpty = treeService.PredictEmpty(tree.Depth, tree.Gates);
            var empty = treeService.WhichOneEmpty(tree.Depth, tree.Gates);


            Console.WriteLine($"Predicted empty contaner is at position {predictedEmpty} in the rows of contaners");

            Console.WriteLine($"Actual empty contaner is at position {empty} in the rows of contaners");

            Console.ReadLine();
        }
    }
}
