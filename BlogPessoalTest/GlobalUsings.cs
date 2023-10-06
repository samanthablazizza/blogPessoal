global using Xunit;
[assembly: CollectionBehavior(DisableTestParallelization = true)] //desabilitar execução de testes em paralelo (ao mesmo tempo)

[assembly: TestCaseOrderer("Xunit.Extensions.Ordering.TestCaseOrderer", "Xunit.Extensions.Ordering")]//habilitar a ordenação de testes