using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;

namespace CodeCracker.CSharp.Refactoring
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class BodiedMethodFromExpressionBodiedAnalyzer : DiagnosticAnalyzer
    {
        internal const string Title = "Convert expression bodied method for block bodied.";
        internal const string MessageFormat = "Convert an expression bodied method to a block bodied method";
        internal const string Category = SupportedCategories.Refactoring;

        internal static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(
            DiagnosticId.ConversionToBodiedMethod.ToDiagnosticId(),
            Title,
            MessageFormat,
            Category,
            DiagnosticSeverity.Hidden, 
            false);

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(LanguageVersion.CSharp6, AnalyzeBaseMethodNode, SyntaxKind.MethodDeclaration, SyntaxKind.OperatorDeclaration, SyntaxKind.ConversionOperatorDeclaration);
            context.RegisterSyntaxNodeAction(LanguageVersion.CSharp6, AnalyzeBasePropertyNode, SyntaxKind.IndexerDeclaration, SyntaxKind.PropertyDeclaration);

        }

        private static void AnalyzeBasePropertyNode(SyntaxNodeAnalysisContext context)
        {
            if (context.IsGenerated()) return;
        }

        private static void AnalyzeBaseMethodNode(SyntaxNodeAnalysisContext context)
        {
            if(context.IsGenerated()) return;
        }

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);
    }
}
