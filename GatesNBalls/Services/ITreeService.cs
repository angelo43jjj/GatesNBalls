using GatesNBalls.Models;

namespace GatesNBalls.Services
{
    public interface ITreeService
    {
        Tree FormTree(string sDepth, string sGates);
        int PredictEmpty(int depth, string[] gates);
        int WhichOneEmpty(int depth, string[] gates);
    }
}