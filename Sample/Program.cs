using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public class CodeGenerator
    {
        public CodeCompileUnit GenerateCSharpCode()
        {
            CodeCompileUnit compileUnit = new CodeCompileUnit();

            CodeNamespace codeNamespace = new CodeNamespace("MyNamespace");

            CodeNamespaceImport[] imports =
            {
                new CodeNamespaceImport("System"),
                new CodeNamespaceImport("System.Collections.Generic")
            };

            codeNamespace.Imports.AddRange(imports);

            CodeTypeDeclaration newType = new CodeTypeDeclaration("MyClass");
            newType.Attributes = MemberAttributes.Public;

            CodeEntryPointMethod mainMethod = new CodeEntryPointMethod();

            CodeMethodInvokeExpression mainExpression = new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("Console"),
                "WriteLine", new CodePrimitiveExpression("Hello World!"));
            mainMethod.Statements.Add(mainExpression);

            CodeStatement cs = new CodeVariableDeclarationStatement(typeof(CodeGenerator), "cs", new CodeObjectCreateExpression(new CodeTypeReference(typeof(CodeGenerator))));
            mainMethod.Statements.Add(cs);

            //CodeGenerator cs = new CodeGenerator();

            CodeConstructor constructor = new CodeConstructor();
            constructor.Attributes = MemberAttributes.Public;

            CodeMethodInvokeExpression constructorExpression = new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("Console"), "WriteLine",
                new CodePrimitiveExpression("Instatnce created"));

            constructor.Statements.Add(constructorExpression);
            newType.Members.Add(constructor);
            newType.Members.Add(mainMethod);

            codeNamespace.Types.Add(newType);

            compileUnit.Namespaces.Add(codeNamespace);
            return compileUnit;
        }


        public void GenerateCode(CodeCompileUnit ccu, string codeProvider)
        {
            CompilerParameters cp = new CompilerParameters();
            string sourceFile;
            CompilerResults cr;

            switch (codeProvider)
            {
                case "CSHARP":
                    {
                        CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider();
                        if (cSharpCodeProvider.FileExtension[0] == '.')
                        {
                            sourceFile = "CSharpSample" + cSharpCodeProvider.FileExtension;   // CSharpSample.exe
                        }
                        else
                        {
                            sourceFile = "CSharpSample." + cSharpCodeProvider.FileExtension;
                        }
                        IndentedTextWriter tw1 = new IndentedTextWriter(new StreamWriter(sourceFile, false), "   ");
                        cSharpCodeProvider.GenerateCodeFromCompileUnit(ccu, tw1, new CodeGeneratorOptions());
                        tw1.Close();
                        cp.GenerateExecutable = true;
                        cp.OutputAssembly = "CSharpSample.exe";
                        cp.GenerateInMemory = false;
                        break;
                    }
            }
        }
        public void CSharpCodeExample()
        {
            String sourcecode = 
                "" +
                "\nusing System;" +
                "\n using System.Collections;" +
                "\npublic class Sample " +
                "\n" +
                "{\n  " +
                "  static void Main()\n " +
                "   {\n    " +
                "    Console.WriteLine(\"This is a test\");" +
                "Action act = () => {Console.WriteLine(\"1234567890\");};"+
                " act();"+
                "\n\t" +
                "Console.ReadKey();" +
                "\n   }" +
                "\n}";
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters cp = new CompilerParameters();
            cp.GenerateExecutable = true;
            cp.OutputAssembly = "Result.exe";
            cp.GenerateInMemory = false;
            CompilerResults cr = provider.CompileAssemblyFromSource(cp, sourcecode);
            if (cr.Errors.Count > 0)
            {
                Console.WriteLine("Errors building {0} into {1}", sourcecode, cr.PathToAssembly);
                foreach (CompilerError ce in cr.Errors)
                {
                    Console.WriteLine("  {0}", ce.ToString());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Source \n \n {0} \n \n \n built into {1} successfully.", sourcecode, cr.PathToAssembly);
            }
            return;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CodeGenerator cg = new CodeGenerator();
            cg.CSharpCodeExample();
            CodeCompileUnit ccu = cg.GenerateCSharpCode();
            cg.GenerateCode(ccu, "CSHARP");
        }
    }
}
