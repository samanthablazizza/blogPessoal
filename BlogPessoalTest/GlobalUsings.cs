global using Xunit;
[assembly: CollectionBehavior(DisableTestParallelization = true)] //desabilitar execu��o de testes em paralelo (ao mesmo tempo)

[assembly: TestCaseOrderer("Xunit.Extensions.Ordering.TestCaseOrderer", "Xunit.Extensions.Ordering")]//habilitar a ordena��o de testes