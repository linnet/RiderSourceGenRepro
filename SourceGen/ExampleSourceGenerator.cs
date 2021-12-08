using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace SourceGenReproFirst
{
    [Generator]
    public class ExampleSourceGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
        }

        public void Execute(GeneratorExecutionContext context)
        {
            var assemblyName = context.Compilation.AssemblyName;
            var sourceText =
                SourceText.From(
                    $"namespace {assemblyName}.SourceGenerated {{ public class {assemblyName}Generated {{ public static string Foo = \"Bar\"; }} }}", Encoding.UTF8);
            context.AddSource("Generated.cs", sourceText);
        }
    }
}