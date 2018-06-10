using System;
namespace KursachAttemp2.Models
{
    public interface ILoadable
    {
        string  Path_ { get; set; }
    }
    public interface IGraph : ILoadable
    {
        void BuildGraph();
        Graph Graph { get; set; }
    }
}
