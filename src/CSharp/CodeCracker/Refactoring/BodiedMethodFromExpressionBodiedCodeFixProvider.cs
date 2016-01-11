using System.Collections.Immutable;
using System.Composition;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;

namespace CodeCracker.CSharp.Refactoring
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(BodiedMethodFromExpressionBodiedCodeFixProvider)), Shared]
    public class BodiedMethodFromExpressionBodiedCodeFixProvider : CodeFixProvider
    {
        public override Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            throw new System.NotImplementedException();
        }

        public override ImmutableArray<string> FixableDiagnosticIds { get; }
    }
}
