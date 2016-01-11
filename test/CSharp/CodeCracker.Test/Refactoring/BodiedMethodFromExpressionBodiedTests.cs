using System.Threading.Tasks;
using CodeCracker.CSharp.Refactoring;
using Microsoft.CodeAnalysis;
using Xunit;

namespace CodeCracker.Test.CSharp.Refactoring
{
    public class BodiedMethodFromExpressionBodiedTests : CodeFixVerifier<BodiedMethodFromExpressionBodiedAnalyzer, BodiedMethodFromExpressionBodiedCodeFixProvider>
    {
        [Fact]
        public async Task ExpressionBodyShouldCreateDiagnostic()
        {
            const string expected = @"
                                    using System;

                                    namespace ConsoleApplication1
                                    {
                                        class TypeName
                                        {
                                            public override string ToString()
                                            {
                                                return ""Teste"";
                                            }
                                        }
                                    }";

            const string wihtNoRefactoring = @"
                                        using System;

                                        namespace ConsoleApplication1
                                        {
                                            class TypeName
                                            {
                                                public override string ToString() =>  ""Teste"";
                                            }
                                        }";

            await VerifyCSharpFixAsync(wihtNoRefactoring, expected);
        }
    }
}
